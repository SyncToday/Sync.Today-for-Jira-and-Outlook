module sync_addin_for_outlook_and_jira.Tests

open sync_addin_for_outlook_and_jira
open NUnit.Framework
open TestSecrets

[<Test>]
let ``hello returns 42`` () =
  let result = Library.hello 42
  printfn "%i" result
  Assert.AreEqual(42,result)

[<Test>]
let ``download works`` () =
  System.Net.ServicePointManager.ServerCertificateValidationCallback <- (fun _ _ _ _ -> true)
  let result : string = Library.JIRA.download JIRA.userName JIRA.password
  printfn "%A" result
