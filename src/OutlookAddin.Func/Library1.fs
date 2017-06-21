namespace OutlookAddin.Func

open System

module Common = 
    open Microsoft.ApplicationInsights
    open Serilog
    let tc : TelemetryClient = TelemetryClient()
    let logFileName = "%TMP%\sync-addin-for-outlook-and-jira-%s.txt"
    let log = 
        LoggerConfiguration().MinimumLevel.Debug().WriteTo.RollingFile( sprintf (Printf.StringFormat<string->string>(logFileName)) "{Date}" ).CreateLogger()

module UI = 

    open System.Drawing
    open System.IO
    open Common

    let yymmdd1 (date:DateTime) = date.ToString("yy.MM.dd")

    do
        tc.InstrumentationKey <- "7eff79da-c80d-4309-ba2a-69a2f128e55c"
        tc.Context.User.Id <- Environment.UserName
        tc.Context.Session.Id <- sprintf "%s-%s" Environment.MachineName (yymmdd1 DateTime.Now)
        tc.Context.Device.OperatingSystem <- Environment.OSVersion.ToString()

    let Button_SyncNow_GetEnabled () = true
    let Button_StopSync_GetEnabled () = true
    let GetSyncNowButtonImage () : Bitmap = unbox null
    let GetStopSyncButtonImage () : Bitmap = unbox null
    let GetSettingsButtonImage () : Bitmap = unbox null
    let GetLogButtonImage () : Bitmap = unbox null
    let GetLabel_label_TasksState () = ""
    let GetLabel_label_State () = ""
    let GetLabel_label_Version (link:DateTime) = ""
    let Button_SyncNow_Click() = ()
    let Button_StopSync_Click() = ()
    let Button_Settings_Click() = ()
    let Button_Log_Click() = ()

module Log = 
    open Common

    let fatal (ex:Exception, source:string) =
        log.Fatal(ex, sprintf "Unhandled exception in %A" source)
        tc.TrackException(ex)
        tc.Flush()
    let view (ident:string) = 
        log.Information(sprintf "Form %s opened" ident )
        tc.TrackPageView(ident)
        tc.Flush()
