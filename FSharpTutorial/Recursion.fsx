let rec factorial number =
  if number <= 1 then
    1I
  else
    bigint number * factorial( number - 1 );;

factorial 235;;


// recursion can also be hidden inside a function, making a nice package:
let factorialAsString number =
  let rec factorial number =
    if number <= 1 then
      1I
    else
      bigint number * factorial(number-1)
  string(factorial number)

factorialAsString 5;;