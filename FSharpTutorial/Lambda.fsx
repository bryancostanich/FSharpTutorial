// Lambdas are just functions that you can pass around.

// create list
let numbers = [5; 2; 8; 9; 3; 29; 65; 44; 64]
// call the List.filter method and pass a lambda (like a predicate in LINQ)
let evens = List.filter(fun n -> n % 2 = 0) numbers
let odds = List.filter(fun n -> n % 2 = 1) numbers


//===== comparison of let binding vs. lamda syntax

// let binding syntax:
let square(a) = a * a

// lamdba syntax
let square2 = fun a -> a * a

printfn "%d" (square 9)
printfn "%d" (square2 9)


//==== combining and specifying type
let sayHello =
  (fun(str:string) -> 
  let message = str.Insert(0,"Hello, ")  
  printfn "%A" message
  )

sayHello("Bryan")