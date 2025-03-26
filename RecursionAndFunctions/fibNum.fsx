let fibDown n =
    let rec tailFib x acc y = 
        match y with
        | 0 -> acc
        | _ -> tailFib acc (acc + x) (y - 1)
    tailFib 1 0 n


let rec fibUp n = 
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fibUp (n - 1) + fibUp (n - 2)


printfn "19-е число Фибоначчи = %d" (fibDown 19) 
printfn "19-е число Фибоначчи = %d" (fibUp 19) 