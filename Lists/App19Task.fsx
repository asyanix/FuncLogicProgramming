// Дана строка. Необходимо перемешать все символы строки в случайном порядке.

open System

let shuffleString (input: string) =
    let rnd = Random()
    input.ToCharArray() |> Array.sortBy (fun _ -> rnd.Next()) |> String

Console.Write("Введите строку: ")
let input = Console.ReadLine()

let shuffled = shuffleString input
Console.WriteLine("Перемешанная строка: ")
Console.WriteLine(shuffled)