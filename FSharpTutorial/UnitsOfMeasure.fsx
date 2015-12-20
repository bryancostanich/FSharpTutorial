[<Measure>] type km;
[<Measure>] type mile;
[<Measure>] type h;

let maxSpeed = 50.0<km/h>
let actualSpeed = 40.0<mile/h>;;

// won't work, because of units of measure checking
(*
if (actualSpeed > maxSpeed) then
    printfn "Speeding";;
*)

let mphToKmph (speed:float<mile/h>) =
    speed * 1.6<km/mile>;;

if (mphToKmph (actualSpeed) > maxSpeed) then
    printfn "Speeding!";;