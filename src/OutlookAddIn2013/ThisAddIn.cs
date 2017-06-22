using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using OutlookAddin.Func;
using Microsoft.FSharp.Core;
using sync_addin_for_outlook_and_jira;
using System.Runtime.InteropServices;

namespace OutlookAddIn2013
{
    internal static class stor
    {
        public static Outlook.Application application;
        public static Outlook.Items tasks;
    }

    public partial class ThisAddIn
    {
        public static ThisAddIn Instance = null;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Instance = this;

            Log.view("ThisAddIn_Startup");

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            currentDomain.SetData("DataDirectory",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            stor.application = this.Application;
            var ns = stor.application.Session;
            var tasksFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks);

            stor.tasks = tasksFolder.Items;
        }

        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as System.Exception;

            Log.applicationError("UnhandledExceptionHandler", "Unexpected error occured", ex);
            Ribbon.Message_InternalLoadingError(ex.Message);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }

        internal static Unit createNewTask(Types.Outlook.OutlookTask muster)
        {
            var myItem = stor.application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem) as Outlook.TaskItem;
            myItem.Subject = muster.Subject;
            myItem.Save();

            Marshal.ReleaseComObject(myItem);

            return (Unit)Activator.CreateInstance(typeof(Unit), true);
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
