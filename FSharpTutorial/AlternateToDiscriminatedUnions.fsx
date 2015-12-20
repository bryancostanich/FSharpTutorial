type Point = { X: float; Y : float } 

type IShape = 
    abstract member Area : float

type CircleT (Origin : Point, Radius : float ) =  
    interface IShape with
        member x.Area = Radius * 2.

type SquareT ( Length : float ) = 
    interface IShape with
        member x.Area = Length * Length
        
let s = SquareT(4.)
let c = CircleT({X = 10.; Y = 5. }, 4.)

printf "%d" s.Area
printf "%d" c.Area
