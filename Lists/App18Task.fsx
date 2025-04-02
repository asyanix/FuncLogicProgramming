// Решить задачу с использование класса массив. Напишите программу, которая вводит с клавиатуры 
// два непустых неубывающих массива целых чисел, и печатает те и только те элементы, которые 
// встречаются хотя бы в одном из массивов (объединение множеств). 

open System

let readArray () =
    Console.WriteLine("Введите элементы массива через пробел (неубывающий порядок):")
    Console.ReadLine().Split(' ') |> Array.map int

let unionArrays (arr1: int array) (arr2: int array) =
    let set1 = Set.ofArray arr1
    let set2 = Set.ofArray arr2
    Set.union set1 set2 |> Set.toArray |> Array.sort

let arr1 = readArray()
let arr2 = readArray()

let result = unionArrays arr1 arr2

Console.WriteLine("Объединение массивов без повторений:")
Console.WriteLine(String.Join(" ", result))
