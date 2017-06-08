module sync_addin_for_outlook_and_jira.Tests

open sync_addin_for_outlook_and_jira
open NUnit.Framework

[<Test>]
let ``hello returns 42`` () =
  let result = Library.hello 42
  printfn "%i" result
  Assert.AreEqual(42,result)
