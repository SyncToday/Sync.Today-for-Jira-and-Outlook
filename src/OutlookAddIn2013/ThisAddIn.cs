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
using System.Configuration;
using System.Collections;

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

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            Log.usingConfigFrom(config.FilePath);      
            
            stor.application = this.Application;
            var ns = stor.application.Session;
            var tasksFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks);

            stor.tasks = tasksFolder.Items;

            var now = DateTime.UtcNow;
            var build = Functions.RetrieveLinkerTimestamp();            
            if ( now - build > TimeSpan.FromDays(6*30) )
            {
                var msg = "This version was not expected to run so long. Please upgrade by running setup.exe from https://github.com/hsharpsoftware/publish/raw/master/sync-addin-for-outlook-and-jira/ (this was written to the log too).";
                Log.info( msg );
                System.Windows.Forms.MessageBox.Show(msg);
            }
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
            var idItemCreated = String.Empty;
            var myItem = stor.application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem) as Outlook.TaskItem;
            myItem.Subject = muster.Subject;
            myItem.Complete = muster.Completed;
            myItem.Save();

            idItemCreated = myItem.EntryID;

            Marshal.ReleaseComObject(myItem);

            var s = Settings.Default;
            var keys = new List<string>(s.KeysProcessed ?? (new string[] { }));
            var ids = new List<string>(s.IdsCreated ?? (new string[] { }));
            keys.Add(muster.Key);
            ids.Add(idItemCreated);
            s.KeysProcessed = keys.ToArray();
            s.IdsCreated = ids.ToArray();
            s.Save();

            return (Unit)Activator.CreateInstance(typeof(Unit), true);
        }

        internal static Unit updateExistingTask(Types.Outlook.OutlookTask corresponding)
        {
            var s = Settings.Default;
            if ( s.KeysProcessed == null  ) throw new ArgumentNullException( "KeysProcessed" );
            if ( s.IdsCreated == null  ) throw new ArgumentNullException( "IdsCreated" );
            if ( s.KeysProcessed.Length != s.IdsCreated.Length  ) throw new ArgumentOutOfRangeException ( "KeysProcessed.Length != IdsCreated.Length" );

            var keysAndIds = new Hashtable();            
            for ( var i = 0; i < s.KeysProcessed.Length; i++ ) {
                keysAndIds.Add( s.KeysProcessed[i], s.IdsCreated[i] );
            }

            var ns = stor.application.Session;
            var entryID = keysAndIds[ corresponding.Key ] as string;
            var myItem = ns.GetItemFromID(entryID) as Outlook.TaskItem;

            myItem.Subject = corresponding.Subject;
            myItem.Complete = corresponding.Completed;
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
