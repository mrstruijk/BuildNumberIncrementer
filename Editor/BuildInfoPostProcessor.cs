#if UNITY_EDITOR

using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;


namespace SOSXR.BuildIncrementer
{
    public class BuildInfoPostProcessor : IPostprocessBuildWithReport
    {
        public int callbackOrder { get; }


        public void OnPostprocessBuild(BuildReport report)
        {
            WriteBuildInfoFile.UpdatePostBuildInfo();

            SemanticVersion.Change(true);
            AndroidBundleVersionCode.Change(true);

            Debug.LogFormat(nameof(BuildInfoPostProcessor), "Incremented build numbers and logged in .csv");
        }
    }
}
#endif