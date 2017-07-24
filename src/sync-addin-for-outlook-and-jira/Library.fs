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
    module Common =
        type Result<'TSuccess,'TFailure> = 
            | Success of 'TSuccess
            | Failure of 'TFailure

    module JIRA =
        open Types.JIRA
        open System
        open Common

        let downloadByAssignee (server:string) (userName:string) (password:string) = 
            try
                let convert (root:Issues.Root) : Issue [] = 
                    root.Issues 
                    |> Array.map( 
                        fun p -> 
                            { Key = p.Key; Summary =  p.Fields.Summary;
                              Resolved = p.Fields.Resolution.IsSome; 
                              Description = 
                                match p.Fields.Description  with
                                | Some(x) -> x
                                | _ -> System.String.Empty
                              } 
                    ) 

                Http.RequestString( 
                    ( sprintf "%s/rest/api/2/search?jql=assignee=%s&fields=comment,summary,resolution,description" server userName), httpMethod = HttpMethod.Get,
                    headers = [ HttpRequestHeaders.Accept("application/json"); HttpRequestHeaders.ContentType("application/json");  
                        ( HttpRequestHeaders.BasicAuth userName password )
                    ]
                )
                |> Issues.Parse
                |> convert
                |> Success
            with
            | ex -> Failure ex
