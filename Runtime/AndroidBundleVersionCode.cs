#if UNITY_EDITOR

using SOSXR.EnhancedLogger;
using UnityEditor;


namespace SOSXR.BuildIncrementer
{
    /// <summary>
    ///     Automatically increase the BundleVersionCode that is required by Android
    /// </summary>
    public static class AndroidBundleVersionCode
    {
        private static int _oldBundleVersionCode;
        private static int _newBundleVersionCode;


        public static void Change(bool increment)
        {
            _oldBundleVersionCode = PlayerSettings.Android.bundleVersionCode;

            _newBundleVersionCode = increment ? PlayerSettings.Android.bundleVersionCode + 1 : PlayerSettings.Android.bundleVersionCode - 1;

            PlayerSettings.Android.bundleVersionCode = _newBundleVersionCode;

            Log.Success(nameof(AndroidBundleVersionCode), "Incremented the Android BundleVersionCode from", _oldBundleVersionCode, "to", _newBundleVersionCode);
        }
    }
}
#endif