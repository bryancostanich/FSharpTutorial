
// array:
let fooA = [|1..10|] //simple
let fooB = [| for i = 0 to 10 do yield 10 * i |] //0, 10, 20, 30...

// list:
let gooA = [1..10]
let gooB = [ for i = 0 to 10 do yield 10 * i ]

// IEnumerable:
let hooA = seq {1..10}
let hooB = seq { for i = 0 to 10 do yield 10 * i }