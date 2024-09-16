#if UNITY_EDITOR
using SOSXR.EnhancedLogger;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;


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

            Log.Success(nameof(BuildInfoPostProcessor), "Incremented build numbers and logged in .csv");
        }
    }
}
#endif