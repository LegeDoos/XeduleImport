using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace XeduleImportHelper.Business
{
    class VersionInfoHelper
    {
        /// <summary>
        /// Returns the assembly version number
        /// </summary>
        public static string VersionNumberAssembly { 
            get {
                Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVersion.FileVersion;                
            } 
        }
    }
}
