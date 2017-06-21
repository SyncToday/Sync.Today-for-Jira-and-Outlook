namespace sync_addin_for_outlook_and_jira

open FSharp.Data

/// Documentation for my library
///
/// ## Example
///
///     let h = Library.hello 1
///     printfn "%d" h
///
module Library = 
  
  /// Returns 42
  ///
  /// ## Parameters
  ///  _ `num` _ whatever
  let hello num = 42

  module JIRA =
    let downloadByAssignee (server:string) (userName:string) (password:string) = 
      Http.RequestString( 
        ( sprintf "%s/rest/api/2/search?jql=assignee=%s" server userName), httpMethod = HttpMethod.Get,
        headers = [ HttpRequestHeaders.Accept("application/json"); HttpRequestHeaders.ContentType("application/json");  
          ( HttpRequestHeaders.BasicAuth userName password )
        ]
      )
