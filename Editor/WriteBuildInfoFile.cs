#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;


namespace SOSXR.BuildIncrementer
{
    /// <summary>
    ///     Write build information to a .csv file
    /// </summary>
    public static class WriteBuildInfoFile
    {
        public const string FilePath = "Assets/Resources/build_info.csv";
        private const string InitialBuildStatus = "Failed";
        private const string SuccessBuildStatus = "Success";


        public static void UpdatePreBuildInfo()
        {
            var buildDate = DateTime.Now.ToString("yyyy-MM-dd");
            var buildTime = DateTime.Now.ToString("HH:mm");
            var isDevelopmentalBuild = EditorUserBuildSettings.development; // Debug.isDebugBuild doesn't work in Editor
            var semVer = PlayerSettings.bundleVersion;
            var bundleCode = PlayerSettings.Android.bundleVersionCode.ToString();

            CreateFileIfNeeded();

            using var sw = File.AppendText(FilePath);

            sw.Write($"{buildDate},{buildTime},{isDevelopmentalBuild},{semVer},{bundleCode},{InitialBuildStatus}");

            sw.Write("\n"); // New line 

            Debug.LogFormat(nameof(UpdatePreBuildInfo) + "Appended new build information to build_info.csv at", FilePath);
        }


        public static void UpdatePostBuildInfo()
        {
            CreateFileIfNeeded();

            var lines = File.ReadAllLines(FilePath);

            if (lines.Length <= 1) // 1st line is the header
            {
                return;
            }

            var lastLine = lines[^1];

            if (lastLine.EndsWith(InitialBuildStatus))
            {
                lastLine = lastLine.Substring(0, lastLine.LastIndexOf(InitialBuildStatus, StringComparison.Ordinal)) + SuccessBuildStatus;

                lines[^1] = lastLine;
            }

            File.WriteAllLines(FilePath, lines);

            Debug.LogFormat(nameof(UpdatePostBuildInfo) + "Updated last build status to Success in build_info.csv at" + FilePath);
        }


        private static void CreateFileIfNeeded()
        {
            if (File.Exists(FilePath))
            {
                return;
            }

            using var sw = File.CreateText(FilePath);

            sw.WriteLine("BuildDate,BuildTime,DevBuild,SemVer,BundleCode,BuildStatus");

            Debug.LogFormat("AutoStoreBuildInfo" + "Created new build_info.csv with headers at" + FilePath);
        }
    }
}
#endif