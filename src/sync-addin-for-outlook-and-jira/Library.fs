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
    module JIRA =
        open Types.JIRA

        let downloadByAssignee (server:string) (userName:string) (password:string) = 
            let convert (root:Issues.Root) : Issue [] = 
                root.Issues |> Array.map( fun p -> { Key = p.Key; Summary = p.Fields.Summary } ) 

            Http.RequestString( 
                ( sprintf "%s/rest/api/2/search?jql=assignee=%s" server userName), httpMethod = HttpMethod.Get,
                headers = [ HttpRequestHeaders.Accept("application/json"); HttpRequestHeaders.ContentType("application/json");  
                    ( HttpRequestHeaders.BasicAuth userName password )
                ]
            )
            |> Issues.Parse
            |> convert
