#if UNITY_EDITOR
using SOSXR.EnhancedLogger;
using UnityEditor;


namespace SOSXR.BuildIncrementer
{
    /// <summary>
    ///     Automatically set the Version number (semantic)
    ///     When building for Android, we're also needing the AutoIncreaseAndroidBundleVersionCodeOnBuild.cs
    ///     With help from ChatGPT
    /// </summary>
    public static class SemanticVersion
    {
        private static string _oldVersion;
        private static string _newVersion;


        public static void Change(bool increment)
        {
            _oldVersion = PlayerSettings.bundleVersion;

            _newVersion = ChangeVersionNumber(_oldVersion, increment);

            PlayerSettings.bundleVersion = _newVersion;

            Log.Success(nameof(SemanticVersion), "Incremented SemVer from", _oldVersion, "to", _newVersion);
        }


        private static string ChangeVersionNumber(string version, bool increment)
        {
            // Split the version string into parts
            var parts = version.Split('_');

            // Extract the last part (current number to increment)
            var lastNumberIndex = parts.Length - 1;
            var currentNumber = int.Parse(parts[lastNumberIndex]);

            currentNumber = increment ? currentNumber + 1 : currentNumber - 1;

            // Replace the last part with the incremented number
            parts[lastNumberIndex] = currentNumber.ToString();

            // Join all parts back into a single string
            return string.Join("_", parts);
        }
    }
}
#endif