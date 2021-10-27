using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    static class CompanionProjectUtils
    {
        public const string InvalidIDErrorTitle = "Invalid project ID";
        public const string InvalidIDErrorBody = "Sorry, either the project ID is invalid, or you do not have access to this project. Make sure you are scanning the project ID, and not the API key.";

        const string k_FileName = "projects.json";
        const string k_UntitledProjectName = "Untitled Project";
        const string k_UnlinkedProjectIDFormat = "unlinked-{0}";
        const string k_AlreadyImportedErrorBodyFormat = "You can't import this project because it has already been imported. Return to the project list and tap {0}";
        const string k_AlreadyImportedErrorTitle = "Project Already Imported";
        const string k_InvalidLocalProjectErrorTitle = "Invalid local project";
        const string k_InvalidLocalProjectErrorBody = "Sorry, something went wrong trying to link this local project";

        static string projectListFilePath { get { return Path.Combine(Application.persistentDataPath, k_FileName); } }

        public static event Action<ProjectList> ProjectListSaved;

        public static ProjectList LoadProjects()
        {
            var filePath = projectListFilePath;
            try
            {
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    if (!string.IsNullOrEmpty(jsonData))
                        return SceneSerialization.FromJson<ProjectList>(jsonData);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return new ProjectList();
        }

        static void SaveProjects(ProjectList projectList)
        {
            var jsonData = SceneSerialization.ToJson(projectList);
            File.WriteAllText(projectListFilePath, jsonData);

            ProjectListSaved?.Invoke(projectList);
        }

        public static CompanionProject AddNewProject(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = k_UntitledProjectName;

            var projectList = LoadProjects();
            var projects = projectList.projects;
            var unlinkedCount = 0;
            foreach (var project in projects)
            {
                if (!project.linked)
                    unlinkedCount++;
            }

            var id = string.Format(k_UnlinkedProjectIDFormat, unlinkedCount);
            var projectData = new CompanionProject(id, name, false);
            projectList.projects.Add(projectData);
            SaveProjects(projectList);

            return projectData;
        }

        public static bool TryImportProject(string id, string name, out string errorTitle, out string errorBody)
        {
            if (string.IsNullOrEmpty(id))
            {
                errorTitle = InvalidIDErrorTitle;
                errorBody = InvalidIDErrorBody;
                return false;
            }

            var projectList = LoadProjects();
            foreach (var project in projectList.projects)
            {
                if (project.index == id)
                {
                    errorTitle = k_AlreadyImportedErrorTitle;
                    errorBody = string.Format(k_AlreadyImportedErrorBodyFormat, project.name);
                    return false;
                }
            }

            projectList.projects.Add(new CompanionProject(id, name, true));
            SaveProjects(projectList);
            errorTitle = null;
            errorBody = null;
            return true;
        }

        public static bool TryLinkProject(string id, string name, string localIndex, out string errorTitle, out string errorBody)
        {
            if (string.IsNullOrEmpty(id))
            {
                errorTitle = InvalidIDErrorTitle;
                errorBody = InvalidIDErrorBody;
                return false;
            }

            if (string.IsNullOrEmpty(localIndex))
            {
                errorTitle = k_InvalidLocalProjectErrorTitle;
                errorBody = k_InvalidLocalProjectErrorBody;
                return false;
            }

            var projectList = LoadProjects();
            CompanionProject localProject = null;
            foreach (var project in projectList.projects)
            {
                if (project.index == id)
                {
                    errorTitle = k_AlreadyImportedErrorTitle;
                    errorBody = string.Format(k_AlreadyImportedErrorBodyFormat, project.name);
                    return false;
                }

                if (project.index == localIndex)
                    localProject = project;
            }

            if (localProject == null)
            {
                errorTitle = k_InvalidLocalProjectErrorTitle;
                errorBody = k_InvalidLocalProjectErrorBody;
                return false;
            }

            try
            {
                if (!MoveProjectFolder(localIndex, id, out errorTitle, out errorBody))
                    return false;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                errorTitle = "Failed to move project folder";
                errorBody = $"Project save failed with the following message {e.Message}";
                return false;
            }

            localProject.Link(id, name);

            SaveProjects(projectList);
            errorTitle = null;
            return true;
        }

        public static void UnlinkProject(string cloudId)
        {
            var projectList = LoadProjects();
            var projects = projectList.projects;
            CompanionProject cloudProject = null;
            foreach (var project in projects)
            {
                if (project.index == cloudId)
                    cloudProject = project;
            }

            if (cloudProject == null)
            {
                Debug.LogError($"Cloud project with ID {cloudId} now found");
                return;
            }

            var newProjectId = GetNewProjectId(projects);
            try
            {
                if (!MoveProjectFolder(cloudId, newProjectId, out var errorTitle, out var errorBody))
                {
                    Debug.Log($"{errorTitle}\n{errorBody}");
                    return;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Debug.LogError("Failed to move project folder");
                return;
            }

            cloudProject.Unlink(newProjectId);
            SaveProjects(projectList);
        }

        static string GetNewProjectId(List<CompanionProject> projects)
        {
            var max = 0;
            foreach (var project in projects)
            {
                if (project.linked)
                    continue;

                var parts = project.index.Split('-');
                var num = int.Parse(parts[1]);
                if (max < num)
                    max = num;
            }

            return string.Format(k_UnlinkedProjectIDFormat, max + 1);
        }

        static bool MoveProjectFolder(string oldId, string newId, out string errorTitle, out string errorBody)
        {
            var localPath = CompanionProject.GetProjectPath(oldId);
            // If local project doesn't exist, do not prevent the link--this shouldn't ever happen, though
            if (!Directory.Exists(localPath))
            {
                errorTitle = null;
                errorBody = null;
                return true;
            }

            var linkedPath = CompanionProject.GetProjectPath(newId);
            if (Directory.Exists(linkedPath))
            {
                errorTitle = "Cannot move project folder";
                errorBody = "Sorry, it appears that another project folder already exists at the destination. This can happen if an error occurred when trying to link or delete a project with the same ID. Please back up and clear local data to resolve this issue.";
                return false;
            }

            Directory.Move(localPath, linkedPath);
            errorTitle = null;
            errorBody = null;
            return true;
        }

        public static void DeleteProject(CompanionProject projectToDelete)
        {
            try
            {
                var projectFolder = projectToDelete.GetLocalPath();
                if (Directory.Exists(projectFolder))
                    Directory.Delete(projectToDelete.GetLocalPath(), true);
            }
            catch (Exception e)
            {
                // TODO: Error feedback
                Debug.LogException(e);
                return;
            }

            var projectList = LoadProjects();
            // TODO: Error if project not found
            var index = projectToDelete.index;
            foreach (var project in projectList.projects.ToList())
            {
                if (project.index == index)
                {
                    projectList.projects.Remove(project);
                    break;
                }
            }

            SaveProjects(projectList);
        }

        public static void AddOrUpdateProject(CompanionProject currentProject)
        {
            var projectList = LoadProjects();
            var found = false;
            foreach (var project in projectList.projects.ToList())
            {
                if (project.index == currentProject.index)
                {
                    found = true;
                    project.linked = currentProject.linked;
                    project.name = currentProject.name;
                }
            }

            if (!found)
                projectList.AddProject(currentProject.index, currentProject.name, currentProject.linked);

            SaveProjects(projectList);
        }
    }
}
