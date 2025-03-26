let rec fibUp n = 
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fibUp (n - 1) + fibUp (n - 2)

let rec sumDigitsUp n =
    if n = 0 then 0
    else (n%10) + (sumDigitsUp (n / 10))

let funBool flag = 
    match flag with
    | true -> fibUp
    | false -> sumDigitsUp

printfn "Фибоначи: %d" (funBool true 15)
printfn "Сумма цифр: %d" (funBool false 15)