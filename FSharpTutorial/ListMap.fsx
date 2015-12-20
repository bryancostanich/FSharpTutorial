
// calls the anonymous function of 'x => x*x' on each item in the list and returns a new list containing the changed values
List.map (fun x -> x * x)[1..100];;

let square x = 
    x * x;;

let square2(x) = x * x;;

for i = 1 to 10 do
    square i |> printfn "%d";;


let ins = [1 .. 10]
ins 
    |> List.map square 
    |> List.iter (fun d -> printfn "%d" d);;


let rec forLoop body times = 
    if times <= 0 then
        ()
    else
        body ()
        forLoop body (times - 1);;

forLoop (fun () -> printfn "looping") 3;;


let double x = x * 2;;

//for i = 1 to 10 do


//2 4 8 16 32 



