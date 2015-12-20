module main

[<EntryPoint>]
let main argv = 
    global.fileIO.Exec(argv).Run()