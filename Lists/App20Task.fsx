// Отсортировать строки в  указанном порядке. В порядке увеличения квадратичного отклонения между средним весом 
// ASCII-кода символа в строке и максимально среднего ASCII-кода тройки подряд идущих символов в строке

open System

let meanAscii (s: string) =
    s.ToCharArray() |> Array.averageBy (fun c -> float (int c))

let maxMeanTripleAscii (s: string) =
    if String.length s < 3 then meanAscii s
    else
        s
        |> Seq.windowed 3
        |> Seq.map (fun arr -> arr |> Array.averageBy (fun c -> float (int c)))
        |> Seq.max

let quadraticDeviation (s: string) =
    let meanAll = meanAscii s
    let maxMeanTriple = maxMeanTripleAscii s
    (meanAll - maxMeanTriple) ** 2.0

let sortByQuadraticDeviation (strings: string list) =
    strings |> List.sortBy quadraticDeviation

Console.WriteLine("Введите строки (по одной в строке, пустая строка для завершения):")
    
let rec readLines acc =
    let line = Console.ReadLine()
    if String.IsNullOrWhiteSpace line then acc
    else readLines (line :: acc)
    
let inputStrings = readLines [] |> List.rev

let sortedStrings = sortByQuadraticDeviation inputStrings

Console.WriteLine("Отсортированные строки:")
sortedStrings |> List.iter Console.WriteLine