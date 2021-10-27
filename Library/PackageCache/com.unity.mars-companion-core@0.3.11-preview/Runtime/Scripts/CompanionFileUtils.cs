using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    static class CompanionFileUtils
    {
        static void PreparePathForWrite(string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            var directory = Path.GetDirectoryName(path);
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        public static IEnumerator<string> ReadFileAsyncString(string path, Action<bool, string, string> callback = null)
        {
            string converted = null;
            void ConvertToString(bool success, string callbackPath, byte[] contents)
            {
                if (success)
                    converted = Encoding.UTF8.GetString(contents);

                callback?.Invoke(success, callbackPath, converted);
            }

            var enumerator = ReadFileAsyncBytes(path, ConvertToString);
            while (enumerator.MoveNext())
            {
                yield return null;
            }

            if (enumerator.Current == null)
                yield break;

            yield return converted;
        }

        static IEnumerator<byte[]> ReadFileAsyncBytes(string path, Action<bool, string, byte[]> callback)
        {
            Task task;
            FileStream file;
            byte[] contents = null;
            try
            {
                file = new FileStream(path, FileMode.Open);
                var length = (int)file.Length;
                contents = new byte[length];
                task = file.ReadAsync(contents, 0, length);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                callback?.Invoke(false, path, contents);
                yield break;
            }

            while (!task.IsCanceled && !task.IsCompleted)
            {
                yield return contents;
            }

            Exception exception = task.Exception;
            if (exception != null)
                Debug.LogException(exception);

            try
            {
                file.Close();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                exception = e;
            }

            callback?.Invoke(exception == null, path, contents);
        }

        public static IEnumerator WriteFileAsync(string path, string contents, Action<bool, string> callback = null)
        {
            Task task;
            StreamWriter file;
            try
            {
                PreparePathForWrite(path);

                file = File.CreateText(path);
                task = file.WriteAsync(contents);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                callback?.Invoke(false, path);
                yield break;
            }

            while (!task.IsCanceled && !task.IsCompleted)
            {
                yield return null;
            }

            Exception exception = task.Exception;
            if (exception != null)
                Debug.LogException(exception);

            try
            {
                file.Close();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                exception = e;
            }

            callback?.Invoke(exception == null, path);
        }

        public static IEnumerator WriteFileAsync(string path, byte[] contents, Action<bool, string> callback = null)
        {
            Task task;
            FileStream file;
            try
            {
                PreparePathForWrite(path);

                file = File.Create(path);
                task = file.WriteAsync(contents, 0, contents.Length);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                callback?.Invoke(false, path);
                yield break;
            }

            while (!task.IsCanceled && !task.IsCompleted)
            {
                yield return null;
            }

            Exception exception = task.Exception;
            if (exception != null)
                Debug.LogException(exception);

            try
            {
                file.Close();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                exception = e;
            }

            callback?.Invoke(exception == null, path);
        }

        // From https://www.somacon.com/p576.php
        public static string GetReadableFileSize(long fileSize)
        {
            // File sizes < 0 are invalid
            if (fileSize < 0)
                return string.Empty;

            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (fileSize >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = fileSize >> 50;
            }
            else if (fileSize >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = fileSize >> 40;
            }
            else if (fileSize >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = fileSize >> 30;
            }
            else if (fileSize >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = fileSize >> 20;
            }
            else if (fileSize >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = fileSize >> 10;
                readable /= 1024;
                return readable.ToString("0.# ") + suffix;
            }
            else if (fileSize >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = fileSize;
                readable /= 1024;
                return readable.ToString("0 ") + suffix;
            }
            else
            {
                return fileSize.ToString("0 B"); // Byte
            }

            readable /= 1024;
            return readable.ToString("0.## ") + suffix;
        }
    }
}
