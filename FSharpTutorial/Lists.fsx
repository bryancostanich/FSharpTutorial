
// Creating lists
let list1 = [];; // [] = nil, or list terminator
let list2 = 1::2::3::4::5::[];; // :: represents a constructed list cell. this is the real way to construct a list
let list3 = [1; 2; 3; 4; 5;];; // this is syntactic sugar
let list4 = [1..5];; // also syntactic sugar to create a sequence
let list5 = 0::list4;; // same syntax as List2, prepends a value to another list and returns a new list from it

let matchListType list = 
  match list with
  | []            -> printfn "Empty List" // nil
  | head::tail    -> printfn "Starting with %d" head //note that 'tail' refers to ALL items after head.

matchListType list1;;
matchListType list2;;

let squareFirst list =
  match list with
  | []          -> 0
  | head::_     -> head * head

printfn "%d" (squareFirst list2);;
printfn "%d" (squareFirst [5; 6; 7;]);; //can create a list right there

// what's the equivalent of this??
//printfn "%d" (squareFirst list2[2]);;

//===== Examples showing the build of of functions actually present in F#

// F# has a built in sum list function, butas an example, if we needed to build one, this is what it would look like
let rec sumList list =
  match list with
  | []          -> 0    //note that because this branch returns zero, the compiler knows the whole thing returns int.
  | head::tail  -> head + (sumList tail)


printfn "%d" (sumList list2);;

// a more generic version of the above
let rec aggregateList (op:int -> int -> int) init list = //operator takes two integers and returns an int
  match list with
  | []          -> init
  | head::tail  ->
    let resultRest = aggregateList op init tail
    op resultRest head
    ;;

let add a b = a + b
let multiply a b = a * b

printf "%d" (aggregateList add 0 list2)
printf "%d" (aggregateList multiply 1 list2)
printf "%d" (aggregateList (+) 0 list2) // can pass an operator as a function!!
printf "%d" (aggregateList (*) 1 list2)

// this is really cool! max is a built in operator that returns the bigger of the two passed in values
// so in this case, we can actually find the biggest value in the list!
printf "%d" (aggregateList max (-1) [6;28;2;35;76;4]) 