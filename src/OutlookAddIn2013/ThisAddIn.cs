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
using System.Threading;

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

        public bool IsAutomaticThreadRunning { get; set; }
        private Thread MainThread { get; set; }

        public Ribbon Ribbon { get; set; }

        private void fixLocalIdStore() {
            try {
                var s = Settings.Default;
                var keys = new List<string>(s._KeysProcessed ?? (new string[] { }));
                var ids = new List<string>(s._IdsCreated ?? (new string[] { }));

                foreach( var item in stor.tasks ) {
                    try {
                        var task = item as Outlook.TaskItem;
                        if ( task == null ) continue;
                        var subject = task.Subject;
                        if (subject.StartsWith("#")) {
                            var key = UI.getKeyFromTaskSubject(subject);
                            keys.Add(key);
                            ids.Add(task.EntryID);
                        }
                    } catch ( Exception ex ) {
                        Log.warn("fixLocalIdStore item", ex);
                    }
                }

                s._KeysProcessed = keys.ToArray();
                s._IdsCreated = ids.ToArray();
                s.Save();
            } catch ( Exception ex ) {
                Log.warn("fixLocalIdStore Global", ex);
            }
        }

        public void StopAutomaticSync()
        {
            IsAutomaticThreadRunning = false;
            try { if (MainThread != null) MainThread.Abort(); }
            catch (System.Exception) { }
        }

        public void StartAutomaticSync()
        {
            StopAutomaticSync();

            IsAutomaticThreadRunning = true;

            var s = Settings.Default;

            MainThread = new Thread(delegate ()
            {

                while (true)
                {
                    if (!Ribbon.IsThreadRunning && DateTime.Now > s.LastSynchronizationEnd.AddMinutes(s.TimerInterval))
                    {
                        //start
                        Globals.ThisAddIn.Ribbon.Button_SyncNow_Click(null);
                    }

                    Globals.ThisAddIn.Ribbon.InvalidateRibbon();
                    Thread.Sleep(30000);
                }
            });

            MainThread.Start();
        }

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

            var oThread = new Thread(new ThreadStart(fixLocalIdStore));
            oThread.Start();

            var s = Settings.Default;
            if (s.TimerEnabled) StartAutomaticSync();

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
            this.Ribbon = new Ribbon();
            return this.Ribbon;
        }

        internal static Unit createNewTask(Types.Outlook.OutlookTask muster)
        {
            var idItemCreated = String.Empty;
            var myItem = stor.application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem) as Outlook.TaskItem;
            myItem.Subject = muster.Subject;
            myItem.Complete = muster.Completed;
            myItem.Body = muster.Body;
            myItem.Save();

            idItemCreated = myItem.EntryID;

            Marshal.ReleaseComObject(myItem);

            var s = Settings.Default;
            var keys = new List<string>(s._KeysProcessed ?? (new string[] { }));
            var ids = new List<string>(s._IdsCreated ?? (new string[] { }));
            keys.Add(muster.Key);
            ids.Add(idItemCreated);
            s._KeysProcessed = keys.ToArray();
            s._IdsCreated = ids.ToArray();
            s.Save();

            return (Unit)Activator.CreateInstance(typeof(Unit), true);
        }

        internal static Unit updateExistingTask(Types.Outlook.OutlookTask corresponding)
        {
            var s = Settings.Default;
            if ( s._KeysProcessed == null  ) throw new ArgumentNullException( "KeysProcessed" );
            if ( s._IdsCreated == null  ) throw new ArgumentNullException( "IdsCreated" );
            if ( s._KeysProcessed.Length != s._IdsCreated.Length  )
                throw new ArgumentOutOfRangeException ( 
                    String.Format("KeysProcessed.Length ({0}) != IdsCreated.Length ({1})", s._KeysProcessed.Length, s._IdsCreated.Length )
                );

            var keysAndIds = new Hashtable();            
            for ( var i = 0; i < s._KeysProcessed.Length; i++ ) {
                var key = s._KeysProcessed[i];
                if (keysAndIds.ContainsKey(key)) continue;

                keysAndIds.Add( key, s._IdsCreated[i] );
            }

            var ns = stor.application.Session;
            var entryID = keysAndIds[ corresponding.Key ] as string;
            var myItem = ns.GetItemFromID(entryID) as Outlook.TaskItem;

            myItem.Subject = corresponding.Subject;
            myItem.Complete = corresponding.Completed;
            myItem.Body = corresponding.Body;
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
