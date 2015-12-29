open System.Drawing

type Rectangle = 
  { Left    : float
    Top     : float
    Width   : float
    Height  : float }


// note that when instantiating a record, you don't need the type name, 
// because the compiler looks up the ctor args and matches it to a defined
// type
let rect1 = { Left = 10.0; Top = 10.0; Width = 100.; Height = 80.; }

// note that because they're immutable, we have a shortcut way of creating
// a new record from an existing, so the following would "move" the rectangle:
let rect2 = { rect1 with Left = rect1.Left + 20. }


// again, F# infers the type. but you could also declare type explicitly: `let deflate(original:Rectangle, ...)`
let deflate(original, wspace, hspace) = 
  { Left = original.Left + wspace
    Top = original.Top + hspace
    Width = original.Width - (2.0 * wspace)
    Height = original.Height - (2.0 * hspace) }

let toRectangleF(original) =
  RectangleF((float32)original.Left, (float32)original.Top, (float32)original.Width, (float32)original.Height)

deflate (rect1, 30.0, 10.)

