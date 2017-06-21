module sync_addin_for_outlook_and_jira.Tests2

open OutlookAddin.Func
open NUnit.Framework

[<Test>]
let ``hello returns 42`` () =
  let result = Library.hello 42
  printfn "%i" result
  Assert.AreEqual(42,result)

[<Test>]
let ``log logs`` () =
  "log logs" |> Log.view
  Assert.IsTrue( Log.findLatestLogFile().IsSome )
