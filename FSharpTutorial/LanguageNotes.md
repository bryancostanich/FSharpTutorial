﻿
# Language
## Single Pass Compiler
Is stupid. 

`and` and `rec` would go away. as would file ordering.

## BCL Calls as tuples
http://stackoverflow.com/questions/2725202/f-function-calling-syntax-confusion/2725357#2725357

the decision to interpret all BCL calls as tuples is a bad design call.


## Chaining
foo.Replace(“a”, “b”).Replace(“c”, “d”)
vs.
foo.Replace (“a”, “b”).Replace (“c”, “d”)

the second one above gets applied to the tuple, rather than calling the method. 



# Editor
I can't right click on a known class and resolve the import.



