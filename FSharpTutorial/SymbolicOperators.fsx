
// Operators can be created that act exactly like functions except that they can be used in 
// "infix" notation, which means in between. e.g. `a * b` as opposed to `mulitply a b`

// overloads the ! symbol to be a factorial operator    
let rec (!) x = 
    if x <= 1 then 1
    else x * !(x-1);;


!5;;