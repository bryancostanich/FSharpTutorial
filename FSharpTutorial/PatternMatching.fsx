// Simple pattern matching (from the Programming F# 3.0 book)

// c# equivalent
// public bool IsOdd(int x) { 
//  return (x % 2) = 1; 
// }
let isOdd x = (x % 2 = 1)

let describeNumber x =
    match isOdd x with
    | true -> printfn "x is odd"
    | false -> printfn "x is even";;


describeNumber 4;;


//
let isMoreThanHalf number = 
    ( number >= 0.5 )

let describeNumber2 number = 
    match isMoreThanHalf number with
    | true -> printfn "number is > half."
    | false -> printfn "number is < half.";;

describeNumber2 0.38;;
describeNumber2 0.6;;

// truth table for AND operation
let isAnd a b = 
    match a, b with
    | true, true -> true
    | true, false -> false
    | false, false -> false
    | false, true -> false
    | _, _-> false;; //wildcard

isAnd true false;;
isAnd true true;;


//====== Pattern matching on Types
let x = 3

let testObjectMatch (toMatch:obj) = 
  match toMatch with
  | :? string as s -> "it's a string"
  | :? int as i -> "it's an int"
  | _ as w -> "no idea yo."

printfn "%A" (testObjectMatch x)

// Shape Discriminated union
type Shape =
  | Circle of Radius:int
  | Rectangle of Height:int * Width:int
  | Ellipse of (int * int)

// with discriminated unions, you have to match on the _Case Identifier_.
// in this case, the `_` symbol takes on a special meaning. If you pass it 
// the constructor, it kind of returns the enum type?
let determineShapeType shape = 
  match shape with
  | Circle(_) -> printfn "it's a circle"
  | Rectangle(_) -> printfn "it's a rectangle"
  | Ellipse(_) -> printfn "it's an ellipse"

// this won't work because the type here would be `Shape`,
// whereas Cirlce, Rect, etc., are _Case Identifiers_
let determineShapeType2 shape = 
  match shape with
  | :? Circle -> printfn "it's a circle"
  | :? Rectangle -> printfn "it's a rectangle"
  | :? Ellipse -> printfn "it's an ellipse"

// Can also use named fields (note our shape above doesn't have these):
let getShapeHeight shape =
    match shape with
    | Rectangle(height = h) -> h
    | Circle(radius = r) -> 2. * r
    | Prism(height = h) -> h


//let determineNumberType number = 
//  match number x with
//   | :? System.Int32 -> printfn "this is an integer"
//   | :? System.Single -> printfn "this is a float"
//   | _ -> printfn "some other type"




//====== Active Pattern Matching
open System

// Active Patterns are just functions that actually test for matching, that you can use in a match statement.

// first, you define your matching functions. you have to use "banana clips" -> `(|` and `|)` to enclose the
// active pattern (function) name.
// this one is called `Int` (note the upper case start, this is a rule), we could have called it "TestInt" or 
// something, but the general naming convention seems to just use whatever type name

// Note: the |_| wildcard designation means that this pattern returns and Option type. This type of pattern 
// matching is therefore called _Partial Pattern Matching_ because they're not expected to understand all
// types.
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


 