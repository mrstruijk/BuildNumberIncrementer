#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;


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

            Debug.LogFormat(nameof(AndroidBundleVersionCode), "Incremented the Android BundleVersionCode from", _oldBundleVersionCode, "to", _newBundleVersionCode);
        }
    }
}
#endif