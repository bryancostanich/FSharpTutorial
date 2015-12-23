open System


//====== Declaration with named members
type Point = { X: float; Y : float } 

type Shape = // in these definitinos, shape becomes a tuple, note that here the constructor 
             // parameters are named. e.g. Origin, Radius, Width, Height
    | Circle of Origin: Point * Radius:float 
    | Ellipse of Origin: Point * Width: float * Height: float
    | Square of Length: float
    | Rectangle of Width: float * Height: float

    member s.Area =
        match s with
        | Circle(Radius = r) -> 2.0 * System.Math.PI + r
        | Ellipse(Width = w; Height = h) -> System.Math.PI + (w/2.0) + (h/2.0)
        | Square(Length = l) -> l ** 2.0
        | Rectangle(Width = w; Height = h) -> w * h


// test them out

let c = Circle({ X = 5.0; Y = 5.0 }, 5.0);;
printf "%A" c.Area;;

let s = Square(Length = 4.0 );;
printf "%A" s.Area;;

let r = Rectangle(Width = 10.0, Height = 5.0 );;
printf "%A" r.Area;;

//====== Simple Declaration
type Schedule =
  | Never
  | Once of DateTime
  | Recurring of DateTime * TimeSpan

let tomorrow = DateTime.Now.AddDays (1.0)
let noon = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 12, 0, 0)
let daySpan = new TimeSpan(24, 0, 0)

let schedule1 = Never
let schedule2 = Once(tomorrow)
let schedule3 = Recurring(noon, daySpan)

// using
let GetNextOccurrence(schedule) =
  match schedule with
  | Never -> DateTime.MaxValue
  | Once(eventDate) -> //note that the definitino of Once is Once(DateTime)
    if (eventDate > DateTime.Now) then eventDate
    else DateTime.MaxValue
  | Recurring(startDate, interval) -> //again, note that this matches the ctor and automatically makes them available
    let secondsFromFirst = (DateTime.Now - startDate).TotalSeconds
    let q = secondsFromFirst / interval.TotalSeconds
    let q = max q 0.0
    startDate.AddSeconds
      (interval.TotalSeconds * (Math.Floor(q) + 1.0))

// we can also use higher order functions here
let mapSchedule rescheduleFunc schedule =
  match schedule with
  | Never -> Never
  | Once(eventDate) -> Once(rescheduleFunc eventDate)
  | Recurring(startDate, interval) -> Recurring((rescheduleFunc startDate), interval)

// add two days
mapSchedule (fun date -> date.AddDays(2.0)) schedule2

// or use the pipeline operator
schedule2 |> mapSchedule (fun date -> date.AddDays(2.0))

// we can even do this on a list
let schedules = [schedule2; schedule3]
schedules |> List.map(mapSchedule (fun date -> date.AddDays(2.0)))