namespace OutlookAddin.Func

module UI = 

    open System
    open System.Drawing

    let Button_SyncNow_GetEnabled () = true
    let Button_StopSync_GetEnabled () = true
    let GetSyncNowButtonImage () : Bitmap = unbox null
    let GetStopSyncButtonImage () : Bitmap = unbox null
    let GetSettingsButtonImage () : Bitmap = unbox null
    let GetLogButtonImage () : Bitmap = unbox null
    let GetLabel_label_TasksState () = ""
    let GetLabel_label_State () = ""
    let GetLabel_label_Version (link:DateTime) = ""