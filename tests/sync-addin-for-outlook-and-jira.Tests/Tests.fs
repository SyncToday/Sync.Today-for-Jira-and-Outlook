module sync_addin_for_outlook_and_jira.Tests

open sync_addin_for_outlook_and_jira
open NUnit.Framework
open TestSecrets

[<Test>]
let ``download by assignee works`` () =
    System.Net.ServicePointManager.ServerCertificateValidationCallback <- (fun _ _ _ _ -> true)
    let result = Library.JIRA.downloadByAssignee JIRA.server JIRA.userName JIRA.password
    Assert.IsTrue( result.Length > 0 )
