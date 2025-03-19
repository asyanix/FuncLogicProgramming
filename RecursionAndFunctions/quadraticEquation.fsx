let a = 1.
let b = 2.
let c = -3.
let D = b * b - 4. * a *c  
let roots = (-b + sqrt(D)) / (2. * a), (-b - sqrt(D)) / (2. * a) 

printfn "Решение: %A" roots

let solve (a, b, c) =
    let D = b * b - 4. * a * c
    ((-b + sqrt D) / (2. * a), (-b - sqrt D) / (2. * a))

let solve_with_carry a b c =
    let D = b * b - 4. * a * c
    ((-b + sqrt D) / (2. * a), (-b - sqrt D) / (2. * a))

let solve_with_condition a b c =
    let D = b * b - 4. * a * c
    if D < 0. then None
    else Some(((-b + sqrt D) / (2. * a), (-b - sqrt D) / (2. * a)))

let result = solve (1., 2., -3.)
printfn "Решение: %A" result

let result2 = solve_with_carry 1. 2. -3.
printfn "Решение: %A" result2

let result3 = solve_with_condition 1.0 2.0 -3.0

if Option.isNone result3 then
    printfn "Нет решений"
else
    let roots = Option.get result3
    printfn "Решение: %A" roots

// Размеченное объединение 
type SolveResult =
    None
    | Linear of float
    | Quadratic of float*float

let solve_with_types a b c  =
    let D = b * b - 4.0 * a * c
    if a = 0.0 then
        if b = 0.0 then None 
        else Linear(-c / b)
    else
        if D < 0.0 then None
        else Quadratic(((-b + sqrt D) / (2.0 * a)), ((-b - sqrt D) / (2.0 * a)))

let result4 = solve_with_types 1.0 2.0 -3.0

match result4 with
| None -> printfn "Нет решений"
| Linear solution -> printfn "Линейное решение: %f" solution
| Quadratic (root1, root2) -> printfn "Квадратичные решения: (%f, %f)" root1 root2
