// Построить приложение на F# , позволяющее пользователю решать задачу указанную задачу 
// с применением высших функций класса List. Для введенного списка построить список из элементов, 
// для которых в данном списке встречаются все простые делители.

open System

let primeFactors n =
    let rec factors n d acc =
        if n < 2 then acc
        elif n % d = 0 then factors (n / d) d (d :: acc)
        elif d * d > n then n :: acc
        else factors n (d + 1) acc
    factors n 2 [] |> List.distinct

let hasAllPrimeFactors lst n =
    let factors = primeFactors n
    List.forall (fun x -> List.contains x lst) factors

let buildList lst =
    lst |> List.filter (hasAllPrimeFactors lst)

let readList () =
    Console.WriteLine("Введите числа через пробел:")
    Console.ReadLine().Split(' ') |> Array.map int |> Array.toList

let inputList = readList()
let resultList = buildList inputList

Console.WriteLine("Результат:")
Console.WriteLine(String.Join(", ", resultList))
