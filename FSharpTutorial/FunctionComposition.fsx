
// given the following list of tuples
let places = [("Los Angeles", 15000000);
              ("Eugene", 150000);
              ("Seattle", 5000000);
              ("Brightwood", 500)]

// and this categorization function which takes a number
let statusByPopulation (population) =
  match population with
  | n when n > 10000000 -> "Metropolis"
  | n when n > 1000000 -> "City"
  | n when n > 5000 -> "Town"
  | _ -> "Village"

// apply the function to the second tuple value in the list
places |> List.map (fun (_,pop) -> statusByPopulation(pop))

// the composition operator shortcuts by taking the output
// of the first function and passes it to the second, for us.
places |> List.map (snd >> statusByPopulation)

// for reference, this is the definition of >>:
// let (>>) f g x = f(f(x))