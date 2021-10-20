using System.Diagnostics;
using System.Windows.Forms;

namespace XeduleImportHelper.Business
{
    /// <summary>
    /// Helper class to open the documentation online
    /// </summary>
    class DocumentationHelper
    {
        const string target = "https://legedoos.github.io/XeduleImport/";

        /// <summary>
        /// Open the website
        /// </summary>
        public static void ShowDocsOnline()
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
