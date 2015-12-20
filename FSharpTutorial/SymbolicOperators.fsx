
// overloads the ! symbol to be a factorial operator    
let rec (!) x = 
    if x <= 1 then 1
    else x * !(x-1);;


!5;;