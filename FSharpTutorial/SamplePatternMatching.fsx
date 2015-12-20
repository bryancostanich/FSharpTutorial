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