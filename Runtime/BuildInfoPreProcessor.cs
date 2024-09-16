#if UNITY_EDITOR
using SOSXR.EnhancedLogger;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;


namespace SOSXR.BuildIncrementer
{
    public class BuildInfoPreProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }


        public void OnPreprocessBuild(BuildReport report)
        {
            WriteBuildInfoFile.UpdatePreBuildInfo();

            Log.Success(nameof(BuildInfoPreProcessor), nameof(WriteBuildInfoFile.UpdatePreBuildInfo));
        }
    }
}
#endif