open System

// Active Patterns are just functions that you can use during matching. 

// first, you define your matching functions. you have to use "banana clips" -> `(|` and `|)` to enclose the
// active pattern (function) name.
// this one is called `Int` (note the upper case start, this is a rule), we could have called it "TestInt" or 
// something, but the general naming convention seems to just use whatever type name
let (|Int|_|) testString =
  match Int32.TryParse(testString) with
  | (true, int) -> Some(int)
  | _ -> None

let (|Bool|_|) testString =
  match bool.TryParse(testString) with
  | (true, bool) -> Some(bool)
  | _ -> None

// once we have our active pattern functions defined, we can use them within a `match with` statement:
let determineBoolOrInt testString =
  match testString with
  | Int i -> printfn "Test string is an integer: %d" i
  | Bool b -> printfn "Test string is a boolean of: %b" b
  | _ -> printfn "It ain't int or bool: %A" testString

determineBoolOrInt "5"
determineBoolOrInt "true"
determineBoolOrInt "hey, f#, wassssup?"




let (|Even|Odd|) i = 
    if i % 2 = 0 then Even else Odd;;

let testNumber i =
    match i with
    | Even -> printfn "%d is even" i
    | Odd -> printfn "%d is odd" i;;

testNumber 5
testNumber 6;;

///-----

let (|DivisibleBy|_|) by n = 
    if n % by = 0 then Some DivisibleBy else None

let fizzBuzz = function 
    | DivisibleBy 3 & DivisibleBy 5 -> "FizzBuzz" 
    | DivisibleBy 3 -> "Fizz" 
    | DivisibleBy 5 -> "Buzz" 
    | i -> string i



