
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