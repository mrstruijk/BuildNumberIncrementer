#if UNITY_EDITOR

using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;


namespace SOSXR.BuildIncrementer
{
    public class BuildInfoPreProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }


        public void OnPreprocessBuild(BuildReport report)
        {
            WriteBuildInfoFile.UpdatePreBuildInfo();

            Debug.LogFormat(nameof(BuildInfoPreProcessor), nameof(WriteBuildInfoFile.UpdatePreBuildInfo));
        }
    }
}
#endif