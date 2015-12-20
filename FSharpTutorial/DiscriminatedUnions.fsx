
// can't do this, because what i really want is a "Record"/struct
(*
type Point =
    member X : float
    member Y : float
    //endclass    //TODO: is this necessary?
    *)
type Point = { X: float; Y : float } 

type Shape = // in these definitinos, shape becomes a tuple
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

let c = Circle ( { X = 5.0; Y = 5.0 }, 5.0);;
printf "%A" c.Area;;

let s = Square ( Length = 4.0 );;
printf "%A" s.Area;;

let r = Rectangle ( Width = 10.0, Height = 5.0 );;
printf "%A" r.Area;;