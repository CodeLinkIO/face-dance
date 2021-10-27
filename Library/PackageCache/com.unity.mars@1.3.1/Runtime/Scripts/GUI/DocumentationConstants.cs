namespace Unity.MARS
{
    class DocumentationConstants
    {
        // Only use major and minor (x.y) version; for example when docs are published, for any version of 2.3.x the url will contain 2.3
        const string k_CurrentMarsDocsVersion = "1.3";

        const string k_ApiFolder = "api";
        const string k_ManualFolder = "manual";
        const string k_LatestMarsDocs = "https://docs.unity3d.com/Packages/com.unity.mars@" + k_CurrentMarsDocsVersion + "/";

        const string k_ManualLatest = k_LatestMarsDocs + k_ManualFolder + "/";
        const string k_PageAndAnchor = ".html#";

        // These are the .md file names under the docs folder
        const string k_MarsConceptsDocBase = "MARSConcepts";
        const string k_ReferenceGuideConditionsDocBase = "ReferenceGuideConditions";
        const string k_ReferenceGuideTraitsDocBase = "ReferenceGuideTraits";
        const string k_ReferenceGuideActionsDocBase = "ReferenceGuideActions";
        const string k_ReferenceGuideForcesDocBase = "ReferenceGuideForces";
        const string k_ReferenceGuideVisualizersDocBase = "ReferenceGuideVisualizers";
        const string k_ReferenceGuideSyntheticDataDocBase = "ReferenceGuideSyntheticData";
        const string k_ReferenceGuideSimulationEnvComponentsDocBase = "ReferenceGuideSimulationEnvironmentComponents";

        // Sections for MD files
        const string k_ConceptsBase = k_ManualLatest + k_MarsConceptsDocBase + k_PageAndAnchor;
        const string k_SimEnvironmentComponentsBase = k_ManualLatest + k_ReferenceGuideSimulationEnvComponentsDocBase + k_PageAndAnchor;
        const string k_SyntheticDataComponentsBase = k_ManualLatest + k_ReferenceGuideSyntheticDataDocBase + k_PageAndAnchor;
        const string k_ConditionsComponentsBase = k_ManualLatest + k_ReferenceGuideConditionsDocBase + k_PageAndAnchor;
        const string k_TraitsComponentsBase = k_ManualLatest + k_ReferenceGuideTraitsDocBase + k_PageAndAnchor;
        const string k_ActionsComponentsBase = k_ManualLatest + k_ReferenceGuideActionsDocBase + k_PageAndAnchor;
        const string k_ForcesComponentsBase = k_ManualLatest + k_ReferenceGuideForcesDocBase + k_PageAndAnchor;
        const string k_VisualizersComponentsBase = k_ManualLatest + k_ReferenceGuideVisualizersDocBase + k_PageAndAnchor;

        internal static string CurrentDocsVersion => k_CurrentMarsDocsVersion;

        // General links
        internal const string MarsAPI = k_LatestMarsDocs + k_ApiFolder + "/";
        internal const string WorldScaleManualURL = "https://blogs.unity3d.com/2017/11/16/dealing-with-scale-in-ar/";
        internal const string OfficialUnityManual = "http://docs.unity3d.com/Manual";

        // overall
        internal const string ProxyDocs = k_ConceptsBase + "proxy";
        internal const string ProxyGroupDocs = k_ConceptsBase + "proxy-groups";
        internal const string ReplicatorsDocs = k_ConceptsBase + "replicators";
        internal const string SessionDocs = k_ConceptsBase + "the-mars-session-and-the-camera";

        // Simulation environment components
        internal const string IgnoreForEnvironmentPersistenceDocs = k_SimEnvironmentComponentsBase + "ignore-for-environment-persistence-ignoreforenvironmentpersistence";
        internal const string SimulatedObjectDocs = k_SimEnvironmentComponentsBase + "simulated-object-simulatedobject";
        internal const string MarsEnvironmentSettingsDocs = k_SimEnvironmentComponentsBase + "mars-environment-settings-marsenvironmentsettings";
        internal const string PlaneExtractionSettingsDocs = k_SimEnvironmentComponentsBase + "plane-extraction-settings-planeextractionsettings";
        internal const string SimulatedPlayableDocs = k_SimEnvironmentComponentsBase + "simulated-playable-simulatedplayable";
        internal const string XRayColliderDocs = k_SimEnvironmentComponentsBase + "x-ray-collider-xraycollider";
        internal const string XRayRegionDocs = k_SimEnvironmentComponentsBase + "x-ray-region-xrayregion";

        // Synthetic data components
        internal const string SynthesizedBodyDocs = k_SyntheticDataComponentsBase + "synthesized-body-synthesizedbody";
        internal const string SynthesizedMarkerIdDocs = k_SyntheticDataComponentsBase + "synthesized-marker-id-synthesizedmarkerid";
        internal const string SynthesizedMarkerDocs = k_SyntheticDataComponentsBase + "synthesized-marker-synthesizedmarker";
        internal const string SynthesizedObjectDocs = k_SyntheticDataComponentsBase + "synthesized-object-synthesizedobject";
        internal const string SynthesizedPoseDocs = k_SyntheticDataComponentsBase + "synthesized-pose-synthesizedpose";
        internal const string SynthesizedManualPoseDocs = k_SyntheticDataComponentsBase + "synthesized-manual-pose-synthesizedmanualpose";
        internal const string SynthesizedPlaneDocs = k_SyntheticDataComponentsBase + "synthesized-plane-synthesizedplane";
        internal const string SynthesizedSemanticTagDocs = k_SyntheticDataComponentsBase + "synthesized-semantic-tag-synthesizedsemantictag";
        internal const string SynthesizedAlignmentDocs = k_SyntheticDataComponentsBase + "synthesized-alignment-synthesizedalignment";
        internal const string SynthesizedBounds2DDocs = k_SyntheticDataComponentsBase + "synthesized-bounds-2d-synthesizedbounds2d";
        internal const string SynthesizedLightEstimationDocs = k_SyntheticDataComponentsBase + "synthesized-light-estimation-synthesizedlightestimation";

        // Conditions
        internal const string MarkerConditionDocs = k_ConditionsComponentsBase + "marker-condition-markercondition";
        internal const string PlaneSizeConditionDocs = k_ConditionsComponentsBase + "plane-size-condition-planesizecondition";
        internal const string SemanticTagConditionDocs =  k_ConditionsComponentsBase + "semantic-tag-condition-semantictagcondition";
        internal const string FlatFloorConditionDocs = k_ConditionsComponentsBase + "flat-floor-condition-flatfloor-condition";
        internal const string TrackingStateConditionDocs = k_ConditionsComponentsBase + "tracking-state-condition-trackingstatecondition";
        internal const string AlignmentConditionDocs = k_ConditionsComponentsBase + "alignment-condition-alignmentcondition";
        internal const string GeofenceConditionDocs = k_ConditionsComponentsBase + "geo-fence-condition-geofencecondition";
        internal const string HeightAboveFloorConditionDocs = k_ConditionsComponentsBase + "height-above-floor-condition-heightabovefloorcondition";

        // ==> traits
        internal const string HasPoseConditionDocs = k_TraitsComponentsBase + "has-pose-condition-hasposecondition";
        internal const string IsBodyConditionDocs = k_TraitsComponentsBase + "is-body-condition-isbodycondition";
        internal const string IsFaceConditionDocs = k_TraitsComponentsBase + "is-face-condition-isfacecondition";
        internal const string IsMarkerConditionDocs = k_TraitsComponentsBase + "is-marker-condition-ismarkercondition";
        internal const string IsPlaneConditionDocs = k_TraitsComponentsBase + "is-plane-condition-isplanecondition";

        // Actions
        internal const string FaceLandmarksActionDocs = k_ActionsComponentsBase+ "face-landmarks-action-facelandmarksaction";
        internal const string PlaneLandmarksActionDocs = k_ActionsComponentsBase + "plane-landmarks-action-planelandmarksaction";
        internal const string BodyExpressionActionDocs = k_ActionsComponentsBase + "build-surface-action-buildsurfaceaction";
        internal const string MatchBodyPoseActionDocs = k_ActionsComponentsBase + "body-expression-action-bodyexpressionaction";
        internal const string FaceActionDocs = k_ActionsComponentsBase + "face-action-faceaction";
        internal const string FaceExpressionActionDocs = k_ActionsComponentsBase + "face-expression-action-faceexpressionaction";
        internal const string MatchActionDocs = k_ActionsComponentsBase + "match-body-pose-action-matchbodyposeaction";
        internal const string BuildSurfaceActionDocs = k_ActionsComponentsBase + "match-action-matchaction";
        internal const string SetAlignedPoseActionDocs = k_ActionsComponentsBase + "set-aligned-pose-action-setalignedposeaction";
        internal const string SetPoseActionDocs = k_ActionsComponentsBase + "set-pose-action-setposeaction";
        internal const string ShowChildrenOnTrackingActionDocs = k_ActionsComponentsBase + "show-objects-on-tracking-action-showchildrenontrackingaction";
        internal const string ShowChildrenInBoundsActionDocs = k_ActionsComponentsBase + "show-objects-in-bounds-action-showobjectsinboundsaction";
        internal const string StretchToExtentsActionDocs = k_ActionsComponentsBase + "stretch-to-extents-action-stretchtoextentsaction";

        // Forces
        internal const string ProxyForcesDocs = k_ForcesComponentsBase + "forces-proxyforces";
        internal const string ProxyAlignmentForceDocs = k_ForcesComponentsBase + "alignment-proxyalignmentforce";
        internal const string ProxyRegionForceOccupancyDocs = k_ForcesComponentsBase + "region---occupancy-proxyregionforceoccupancy";
        internal const string ProxyRegionForceTowardsDocs = k_ForcesComponentsBase + "region---towards-proxyregionforcetowards";
        internal const string ProxyRegionForcePlane2DDocs = k_ForcesComponentsBase + "region---plane2d-proxyregionforceplane2d";

        //Visualizers
        internal const string MarsPlaneVisualizerDocs =  k_VisualizersComponentsBase + "plane-visualizer-marsplanevisualizer";
        internal const string MarsPointCloudVisualizerDocs = k_VisualizersComponentsBase + "point-cloud-visualizer-marspointcloudvisualizer";
        internal const string FaceLandmarkVisualizerDocs = k_VisualizersComponentsBase + "face-landmark-visualizer-mrfacelandmarkvisualizer";
        internal const string MarsLightEstimationVisualizer = k_VisualizersComponentsBase + "light-estimation-visualizer-marslightestimationvisualizer";
    }
}
