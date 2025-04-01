let readList n =
    let rec read n list =
        match n with
        | 0 -> list
        | k -> 
            let element = System.Console.ReadLine() |> int
            let newList = list@[element]
            read (k - 1) newList
    read n []


let rec reduce_list list (f: int->int->int) (condition: int->bool) acc =
    match list with
    | [] -> acc
    | head::tail ->
        let current = head
        let flag = condition current
        let newAcc = if condition current then f acc current else acc
        reduce_list tail f condition newAcc
    
let min_list list = 
    match list with
    | [] -> 0
    | head::tail -> reduce_list list (fun a b -> if a < b then a else b) (fun a -> true) head

let sum_even list = reduce_list list (+) (fun a -> a%2 = 0) 0

let count_odd list = reduce_list list (fun a b -> a+1) (fun a -> a%2 = 1) 0

let rec frequency list num count =
    match list with
    | [] -> count
    | head::tail -> 
        let newCount = if head = num then count+1 else count
        frequency tail num newCount
        
let rec writeList list =
    match list with
    | [] -> ignore
    | head :: tail -> 
        System.Console.WriteLine(head.ToString())
        writeList tail

System.Console.WriteLine("Введите 5 элементов списка:")
let arr = readList 5
System.Console.WriteLine("Вывод списка:")
writeList arr
System.Console.WriteLine("Сумма элементов меньших 5:")
let sumLess5 = reduce_list arr (+) (fun (x) -> x < 5) 0
System.Console.WriteLine sumLess5
System.Console.WriteLine("Минимальный элемент:")
System.Console.WriteLine(min_list arr)
System.Console.WriteLine("Сумма чётных:")
System.Console.WriteLine(sum_even arr)
System.Console.WriteLine("Количество нечётных:")
System.Console.WriteLine(count_odd arr)
System.Console.WriteLine(frequency arr 3 0)


