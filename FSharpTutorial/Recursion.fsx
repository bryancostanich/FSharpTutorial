let rec factorial number =
    if number <= 1 then
        1I
    else
        bigint number * factorial ( number - 1 );;

factorial 235;;