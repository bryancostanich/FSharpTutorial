// create a sequence of numbers 1 through ten
let numbers = [1..10]
// function that returns true if the number is odd
let isOdd n =
    (n % 2 = 1)
// simple square function
let square (n) = 
    n * n
   

// Filter the numbers sequence by odd only
List.filter isOdd numbers;;

// filter by odd and then square them
List.map square (List.filter isOdd numbers);;


// Alternative here is "Pipelineing"
let squared 
    = numbers
    |> List.filter isOdd
    |> List.map square;;
