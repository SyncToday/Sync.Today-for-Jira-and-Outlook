module sync_addin_for_outlook_and_jira.Tests2

open OutlookAddin.Func
open NUnit.Framework

[<Test>]
let ``log logs`` () =
    "log logs" |> Log.view  
    Assert.IsTrue( Log.findLatestLogFile().IsSome )
