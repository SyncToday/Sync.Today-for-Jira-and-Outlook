namespace OutlookAddin.Func

open System

module Common = 
    open Microsoft.ApplicationInsights
    open Serilog
    let tc : TelemetryClient = TelemetryClient()
    let logFileName = "%%TMP%%\sync-addin-for-outlook-and-jira-%s.txt"
    let logFilePatternSeriLog = sprintf (Printf.StringFormat<string->string>(logFileName)) "{Date}"
    let logFilePatternSearch = sprintf (Printf.StringFormat<string->string>(logFileName)) "*"
    let log = 
        LoggerConfiguration().MinimumLevel.Debug().WriteTo.RollingFile( Environment.ExpandEnvironmentVariables( logFilePatternSeriLog ) ).CreateLogger()
    do 
        System.Net.ServicePointManager.ServerCertificateValidationCallback <- (fun _ _ _ _ -> true)

module Log = 
    open Common
    open System.IO

    let yymmdd1 (date:DateTime) = date.ToString("yy.MM.dd")

    do
        tc.InstrumentationKey <- "7eff79da-c80d-4309-ba2a-69a2f128e55c"
        tc.Context.User.Id <- Environment.UserName
        tc.Context.Session.Id <- sprintf "%s-%s" Environment.MachineName (yymmdd1 DateTime.Now)
        tc.Context.Device.OperatingSystem <- Environment.OSVersion.ToString()

    let fatal (source:string) (ex:Exception)  =
        log.Fatal(ex, sprintf "Unhandled exception in %A" source)
        tc.TrackException(ex)
        tc.Flush()
    
    let warn (source:string) (ex:Exception)  =
        log.Warning(ex, sprintf "Unhandled exception in %A" source)

    let view (ident:string) = 
        log.Information(sprintf "Form %s opened" ident )
        tc.TrackPageView(ident)
        tc.Flush()

    let info (message:string) = 
        log.Information (message)

    let usingConfigFrom (path:string) =
        log.Information(sprintf "Application reading config from %A" path )        

    let applicationError (source:string) (message:string) (ex:Exception) =
        fatal source ex
        System.Windows.Forms.MessageBox.Show(message, "An error occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error) |> ignore

    let findLatestLogFile () = 
        let path = Path.GetDirectoryName( Environment.ExpandEnvironmentVariables( logFilePatternSeriLog ) )
        let di = path |> DirectoryInfo
        di.GetFiles( Path.GetFileName( logFilePatternSearch ) ) 
        |> Array.sortByDescending( fun p -> p.LastWriteTime ) 
        |> Array.tryHead
        |> Option.map( fun p -> p.FullName )

module UI = 

    open System.Drawing    
    open Common
    open System.Diagnostics
    open Log
    open System.Windows.Forms
    open sync_addin_for_outlook_and_jira.Library.Common
    open sync_addin_for_outlook_and_jira.Types.Outlook

    let Button_SyncNow_GetEnabled () = true
    let Button_StopSync_GetEnabled () = true
    let GetSyncNowButtonImage () : Bitmap = unbox null
    let GetStopSyncButtonImage () : Bitmap = unbox null
    let GetSettingsButtonImage () : Bitmap = unbox null
    let GetLogButtonImage () : Bitmap = unbox null
    let GetLabel_label_TasksState () = ""
    let GetLabel_label_State () = "Ready"
    let GetLabel_label_Version (link:DateTime) = sprintf "v%s" (yymmdd1 link)

    let taskSubjectFromIssue server (i:sync_addin_for_outlook_and_jira.Types.JIRA.Issue) =
        sprintf "#%s %s %s/browse/%s" i.Key i.Summary server i.Key

    let Button_SyncNow_Click server userName password  (createNewTask:OutlookTask->unit) (updateExistingTask:OutlookTask->unit) (alreadyProcessed:string array) = 
        view "SyncNow"
        let download = sync_addin_for_outlook_and_jira.Library.JIRA.downloadByAssignee server userName password
        let getSubject = taskSubjectFromIssue server

        let getBody (i:sync_addin_for_outlook_and_jira.Types.JIRA.Issue) : string =
            if String.IsNullOrWhiteSpace(i.Description) then "" else i.Description + Environment.NewLine + "======================================================================" + Environment.NewLine
            + String.Join( 
                Environment.NewLine, i.Comments 
                |> Array.map( fun x -> 
                                x.Author + " " + x.Created.ToLongTimeString() + ":" + Environment.NewLine + x.Body + Environment.NewLine + "--------------------------------------------------------" ) 
              )

        match download with
        | Success(issues) -> 

            // create new issues
            issues 
            |> Array.where( fun p -> alreadyProcessed |> Array.exists( fun a -> a = p.Key ) |> not )
            |> Array.iter( fun i ->  createNewTask { Key = i.Key; Subject= i |> getSubject; Completed = i.Resolved; Body = i |> getBody } )

            // modify already created
            issues 
            |> Array.where( fun p -> alreadyProcessed |> Array.exists( fun a -> a = p.Key ) )
            |> Array.iter( fun i ->  updateExistingTask { Key = i.Key; Subject= i |> getSubject; Completed = i.Resolved; Body = i |> getBody } )

        | Failure(ex) -> ex |> applicationError "downloadByAssignee" "Download from JIRA failed."

    let Button_StopSync_Click() = ()
    let Button_Settings_Click(form:Form) =
        view "Settings"
        form.Show()
    let Button_Log_Click() = 
        view "Log"
        match findLatestLogFile() with
        | Some( s ) -> Process.Start( s ) |> ignore
        | _ -> ()        

    let Button_Test_Click server userName password  = 
        view "Test"
        let download = sync_addin_for_outlook_and_jira.Library.JIRA.downloadByAssignee server userName password
        match download with
        | Success(issues) -> System.Windows.Forms.MessageBox.Show("Connection Succeeded", "Connection Succeeded", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information) |> ignore
        | Failure(ex) -> ex |> applicationError "Connection Test" "Connection to JIRA server failed. Check the connection parameters and try again."

    let getKeyFromTaskSubject (s:string) : string = 
        s.TrimStart('#').Split(' ').[0]

    let Open_JIRA (server:string) (taskSubject:string) =
        let key = taskSubject |> getKeyFromTaskSubject
        System.Diagnostics.Process.Start( sprintf "%s/browse/%s" server key )