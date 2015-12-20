

// create a tuple
let someLocation = (50.5, 20.3, 12.5) //parentheses are optional, and just make it clearer that it's a single piece of data

let getXY locationXYZ = 
    let X,Y,_ = locationXYZ // note that the underscore denotes that we can skip a value in the tuple
    (X,Y) // return our X and Y coords. note that we can return them in any order. so we could return (Y,X)

printfn "%A" (getXY someLocation)
printfn "%A" (fst (getXY someLocation)) // fst = first. get's the first item
printfn "%A" (snd (getXY someLocation)) // snd = Second. 



// we can do this because of inference.
let printCityAndPopulation cityInfo =
    printf "Population of %s is %d" (fst cityInfo) (snd cityInfo)

let printCityStuff (cityInfo : string * int * string) = 
    let city, pop, _ = cityInfo
    printf "Population of %s is %d" city pop

let prague = ("Prague", 11101000)
let seattle = ("Seattle", 600000, "some other value")

printCityAndPopulation prague;;
printCityStuff seattle;;



//=======

// returns a new tuple with the new population matched into it
// if the first item in the tuple matches "New York" we increment
// the passed in population by 100
//  [functionName][arg1][arg2]
let setPopulation tuple newPopulation =
    match tuple with
    | ("New York", _) -> ("New York", newPopulation + 100)
    | (cityName, _) -> (cityName, newPopulation)
    ;;

let portland = ("Portland", 123)
setPopulation portland 10;;

let newYork = ("New York", 123)
setPopulation newYork 10;