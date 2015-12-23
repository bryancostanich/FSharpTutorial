


let conditionalPrint value test format = 
  if (test(value)) then printfn "%s" (format(value))


conditionalPrint 6 (fun x -> x > 3) (fun n -> ("The number is greater than three. It's " + n.ToString()))
conditionalPrint 3 (fun x -> x > 3) (fun n -> ("The number is greater than three. It's " + n.ToString()))