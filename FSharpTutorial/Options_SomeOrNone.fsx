open System

// None is kind of like Null in .Net; however, in .Net, only reference types can intrinsically null
// (.Net 4.0 added the ? operator [as in int?]), but this because of pattern matching, using Some
// or None in F# will make sure you check all possible cases.

let readInput() =
  let s = Console.ReadLine()
  match Int32.TryParse(s) with
  | true, parsedNumber  -> Some(parsedNumber)
  | _                   -> None  

let testInput() = 
  let input = readInput()
  match input with
  | Some(number)  -> printfn "You entered %d" number
  | None          -> printfn "not a valid number."


//========
// the Option class also has some neat tricks up it's sleave.
let readAndAdd () =
  match (readInput()) with
  | None        -> None
  // in the following, we match a value to a function that reads the input again 
  // and using the Option.map method, we can act on another valid value (and implicitly
  // ignore (return None) on crap values
  | Some(firstEnteredVal) -> readInput() |> Option.map (fun secondEnteredVal -> firstEnteredVal + secondEnteredVal)
;;
readAndAdd()

// and with the Bind method, we can even simplify, because it does the first matching for us
// because Bind will call the function if the input is valid, otherwise returns None
let readAndAddWithBind () =
  readInput() |> Option.bind(fun num ->
    readInput() |> Option.map ((+) num))
;;
readAndAddWithBind()