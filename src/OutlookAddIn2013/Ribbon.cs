using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using OutlookAddin.Func;
using System.Drawing;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace OutlookAddIn2013
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("OutlookAddIn2013.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public bool Button_SyncNow_GetEnabled(Office.IRibbonControl control)
        {
            return UI.Button_SyncNow_GetEnabled();
        }

        public bool Button_StopSync_GetEnabled(Office.IRibbonControl control)
        {
            return UI.Button_StopSync_GetEnabled();
        }

        public Bitmap GetSyncNowButtonImage(Office.IRibbonControl control)
        {
            return UI.GetSyncNowButtonImage();
        }

        public Bitmap GetStopSyncButtonImage(Office.IRibbonControl control)
        {
            return UI.GetStopSyncButtonImage();
        }

        public Bitmap GetSettingsButtonImage(Office.IRibbonControl control)
        {
            return UI.GetSettingsButtonImage();
        }

        public Bitmap GetLogButtonImage(Office.IRibbonControl control)
        {
            return UI.GetLogButtonImage();
        }

        public string GetLabel_label_TasksState(Office.IRibbonControl control)
        {
            return UI.GetLabel_label_TasksState();
        }

        public string GetLabel_label_State(Office.IRibbonControl control)
        {
            return UI.GetLabel_label_State();
        }

        public string GetLabel_label_Version(Office.IRibbonControl control)
        {
            return UI.GetLabel_label_Version( Functions.RetrieveLinkerTimestamp() );
        }

        public void Button_SyncNow_Click(Office.IRibbonControl control) {
            var s = Settings.Default;
            UI.Button_SyncNow_Click(s.ServerUrl, s.UserName, s.Password);
        }
        public void Button_StopSync_Click(Office.IRibbonControl control) { UI.Button_StopSync_Click(); }
        public void Button_Settings_Click(Office.IRibbonControl control) { UI.Button_Settings_Click(new SettingsForm()); }
        public void Button_Log_Click(Office.IRibbonControl control) { UI.Button_Log_Click(); }

        public static void Message_InternalLoadingError(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "An error occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
