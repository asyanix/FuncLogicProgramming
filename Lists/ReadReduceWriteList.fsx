// Задание 1. Написать функцию, которая по заданному числу n возвращает список, прочитанный с клавиатуры.

let readList n =
    let rec read n list =
        match n with
        | 0 -> list
        | k -> 
            let element = System.Console.ReadLine() |> int
            let newList = list@[element]
            read (k - 1) newList
    read n []

// Задание 2. Написать функцию, которая выводит список на экран.
let rec writeList list =
    match list with
    | [] -> ignore
    | head :: tail -> 
        System.Console.WriteLine(head.ToString())
        writeList tail

// Задание 3. Написать функцию, принимающая в качестве аргументов: список, целочисленную функцию, 
// предикат, инициализирующее значение аккумулятора, возвращающую целочисленное значение. 
let rec reduce_list list (f: int->int->int) (condition: int->bool) acc =
    match list with
    | [] -> acc
    | head::tail ->
        let current = head
        let flag = condition current
        let newAcc = if condition current then f acc current else acc
        reduce_list tail f condition newAcc

// Задание 4. С помощью этой функции написать функции для мин элементов списка, суммы чётных, количества нечётных элементов.    
let min_list list = 
    match list with
    | [] -> 0
    | head::tail -> reduce_list list (fun a b -> if a < b then a else b) (fun a -> true) head

let max_list list = 
    match list with
    | [] -> 0
    | head::tail -> reduce_list list (fun a b -> if a > b then a else b) (fun a -> true) head

let sum_even list = reduce_list list (+) (fun a -> a%2 = 0) 0

let count_odd list = reduce_list list (fun a b -> a+1) (fun a -> a%2 = 1) 0

let rec frequency list num count =
    match list with
    | [] -> count
    | head::tail -> 
        let newCount = if head = num then count+1 else count
        frequency tail num newCount

let rec freq_list list main_list cur_list = 
    match list with
    | [] -> cur_list
    | head::tail -> 
        let freq_elem = frequency main_list head 0
        let new_list = cur_list @ [freq_elem]
        freq_list tail main_list new_list

let pos list el = 
    let rec pos_inner list el num = 
        match list with
            |[] -> 0
            |head::tail -> 
                if (head = el) then num
                else 
                    let num1 = num + 1
                    pos_inner tail el num1
    pos_inner list el 1

let get_from_list list pos = 
    let rec get list num cur_num = 
        match list with 
            |[] -> 0
            |head::tail -> 
                if num = cur_num then head
                else 
                    let new_num = cur_num + 1
                    get tail num new_num
    get list pos 1

// Задание 5. Реализовать функцию, которая для заданного списка находит самый частый элемент. 
let find_most_frequent list = 
    let fL = freq_list list list []
    (max_list fL) |> (pos fL) |> (get_from_list list)   

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
System.Console.Write("Самый часто встречающийся элемент: ")
System.Console.WriteLine(find_most_frequent arr)

// Задание 6. Построить реализацию двоичного дерева с элементом строка.

type BinaryTree =
    | Leaf
    | Node of string * BinaryTree * BinaryTree

let empty = Leaf

let rec insert value tree =
    match tree with
    | Leaf -> Node(value, Leaf, Leaf)
    | Node(v, left, right) ->
        if value < v then
            Node(v, insert value left, right)
        elif value > v then
            Node(v, left, insert value right)
        else
            tree

let rec contains value tree =
    match tree with
    | Leaf -> false
    | Node(v, left, right) ->
        if value = v then true
        elif value < v then contains value left
        else contains value right

let rec traverse tree =
    match tree with
    | Leaf -> []
    | Node(v, left, right) -> traverse left @ [v] @ traverse right

let print_tree tree =
    let rec print tree_arr =
        match tree_arr with
        | [] -> System.Console.WriteLine("")
        | head::tail ->
            System.Console.Write(head + " ")
            print tail
    print (traverse tree)

let tree = 
        empty
        |> insert "banana"
        |> insert "apple"
        |> insert "cherry"
        |> insert "mango"
        |> insert "lemon"
System.Console.WriteLine("Вывод двоичного дерева:")
print_tree tree

// Задание 7. Реализовать функцию, которая для заданного списка находит самый частый элемент. 

let most_frequent list =
    list
    |> List.countBy id
    |> List.sortByDescending snd
    |> List.head
    |> fst

System.Console.Write("Самый частый элемент с использованием класса List: ")
System.Console.WriteLine(most_frequent arr)
