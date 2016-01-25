
// array:
let foo = [|1;3;7;20|]
let fooA = [|1..10|] //simple
let fooB = [| for i = 0 to 10 do yield 10 * i |] //0, 10, 20, 30...

// list:
let goo = [1;3;5;9]
let gooA = [1..10]
let gooB = [ for i = 0 to 10 do yield 10 * i ]

// IEnumerable:
let hoo = seq {yield 1; yield 4; yield 66; yield 90} //this valid?
let hooA = seq {1..10}
let hooB = seq { for i = 0 to 10 do yield 10 * i }