﻿module fileIO

open System
open Microsoft.FSharp.Reflection
open System.Reflection
open System.Text

let convertDataRow (csvLine:string) = 
  let cells = List.ofSeq(csvLine.Split(',')) // split the csv and convert the sequence to a list
  match cells with
  | title::number::_ ->
    let parsedNumber = Int32.Parse(number) 
    (title,parsedNumber) //return a tuple of title and parsed number
  | _ -> failwith "Incorrect data format."
  ;;

let rec processLines (lines) =
  match lines with 
  | [] -> []
  | currentLine::remaining ->
    let parsedLine = convertDataRow (currentLine)
    let parsedRest = processLines (remaining)
    parsedLine :: parsedRest

let rec calculatePopulationSum (rows) =
  match rows with
  | [] -> 0
  | (_, value)::tail -> //this is cool, we're decomposing the tuple in the pattern match
    let remainingSum = calculatePopulationSum(tail)
    value + remainingSum

let enumerateResources =
  let currentAssembly = Assembly.GetCallingAssembly()
  let resourceNames = List.ofArray(currentAssembly.GetManifestResourceNames())
  resourceNames
    |> List.iter (fun r -> printfn "%A" r)
  resourceNames


let openResourceStream path =
  let currentAssembly = System.Reflection.Assembly.GetCallingAssembly()
  let stream = currentAssembly.GetManifestResourceStream(path)
  stream

let resourceToString path =
  use stream = openResourceStream (path)
  use reader = new System.IO.StreamReader(stream)
  let resourceString = reader.ReadToEnd()
  resourceString
  

type Exec (args) = 
  member x.Run () =
    printfn "test."

    // enumerate the embedded resources
    let foo = enumerateResources

    let csvText = resourceToString "ContinentalPopulations.csv"

    // why the parens?
    let popData = processLines(List.ofArray(csvText.Split '\n'))
    printfn "%d" popData.Length

    let sum = float (calculatePopulationSum(popData))
    printfn "Total World Population: %f" sum

    for (title, value) in popData do // pattern matching!
      let percentage = int((float(value)) / sum * 100.0)
      Console.WriteLine("{0,-18} - {1,8} ({2}%)", title, value, percentage)


    1 // exit