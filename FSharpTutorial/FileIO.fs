module fileIO

open System
//open Microsoft.FSharp.Reflection
open System.Reflection

type Poop(poopSmell) = 
    member this.smell = poopSmell

let convertDataRow (csvLine:string) = 
  let cells = List.ofSeq(csvLine.Split(',')) // split the csv and convert the sequence to a list
  match cells with
  | title::number::_ ->
    let parsedNumber = Int32.Parse(number) 
    (title,parsedNumber) //return a tuple of title and parsed number
  | _ -> failwith "Incorrect data format."
  ;;


let enumerateResources =
  let currentAssembly:Assembly = typeof<Poop>.GetTypeInfo().Assembly
  let resourceNames = List.ofArray(currentAssembly.GetManifestResourceNames())
  resourceNames
    |> List.iter (fun r -> printfn "%A" r)
  



type Exec (args) = 
  member x.Run () =
    printf "test."

    enumerateResources

    1