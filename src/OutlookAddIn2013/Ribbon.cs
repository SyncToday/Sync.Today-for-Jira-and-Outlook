﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using OutlookAddin.Func;
using System.Drawing;
using sync_addin_for_outlook_and_jira;
using Microsoft.FSharp.Core;
using OutlookAddIn2013.Properties;

namespace OutlookAddIn2013
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        public static bool IsThreadRunning { get; private set; }

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

        private object selectedItem
        {
            get
            {
                var selection = stor.application.ActiveExplorer().Selection;
                return selection.Count == 0 ? null : selection[1];
            }
        }

        private Microsoft.Office.Interop.Outlook.TaskItem selectedTask
        {
            get
            {
                var item = selectedItem;
                var task = item as Microsoft.Office.Interop.Outlook.TaskItem;
                if (task != null && task.Subject.StartsWith("#"))
                {
                    return task;
                }
                return null;
            }
        }

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
            return Resources.Refresh;
        }

        public Bitmap GetStopSyncButtonImage(Office.IRibbonControl control)
        {
            return Resources.Stop;
        }

        public Bitmap GetSettingsButtonImage(Office.IRibbonControl control)
        {
            return Resources.Log;
        }

        public Bitmap GetLogButtonImage(Office.IRibbonControl control)
        {
            return Resources.Log;
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
            var createNewTaskFS = Microsoft.FSharp.Core.FSharpFunc<Types.Outlook.OutlookTask, Unit>.FromConverter(new Converter<Types.Outlook.OutlookTask, Unit>(ThisAddIn.createNewTask));
            var updateExistingTaskFS = Microsoft.FSharp.Core.FSharpFunc<Types.Outlook.OutlookTask, Unit>.FromConverter(new Converter<Types.Outlook.OutlookTask, Unit>(ThisAddIn.updateExistingTask));
            UI.Button_SyncNow_Click(s.ServerUrl, s.UserName, s.Password, createNewTaskFS, updateExistingTaskFS, s._KeysProcessed??(new string[] { }) );
            s.LastSynchronizationEnd = DateTime.Now;
            s.Save();
        }
        public void Button_StopSync_Click(Office.IRibbonControl control) { UI.Button_StopSync_Click(); }
        public void Button_Settings_Click(Office.IRibbonControl control) { UI.Button_Settings_Click(new SettingsForm()); }
        public void Button_Log_Click(Office.IRibbonControl control) { UI.Button_Log_Click(); }

        public static void Message_InternalLoadingError(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "An error occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public void Button_Open_Click(Office.IRibbonControl control)
        {
            var s = Settings.Default;
            var task = selectedTask;
            if (task == null) return;
            UI.Open_JIRA(s.ServerUrl, task.Subject);
        }

        public bool Button_Open_GetEnabled(Office.IRibbonControl control)
        {
            return selectedTask != null;
        }

        public Bitmap GetOpenButtonImage(Office.IRibbonControl control)
        {
            return Resources.Open;
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

        public void InvalidateRibbon()
        {
            if (ribbon != null) { this.ribbon.Invalidate(); }
        }

    }
}
