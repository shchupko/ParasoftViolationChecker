using System.IO;

namespace NarrowViol
{
    public static class Config
    {
        public static string SourceFName = "cs_violations.xml";
        public static string ResultFName = "narrow";
        public static string workspacePath = "D:\\PS\\WSpace103"; //WSpace103 / workspace
        public static string path = Path.Combine(workspacePath, ".metadata\\.plugins\\com.parasoft.xtest.common.eclipse.core\\session_results_report_xml"); 
        public static string LogFileName = "NV.log";
    }
}
