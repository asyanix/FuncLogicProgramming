open System

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

// Задание 8. Реализовать функцию, которая для данного списка указывает, сколько элементов 
// из него могут быть квадратом какого-то из элементов списка.

let count_square_elements (list: int list) =
    let unique_elements = List.distinct list
    list
    |> List.filter (fun x ->
        unique_elements
        |> List.exists (fun y -> y * y = x)
    )
    |> List.length

System.Console.Write("Количество элементов, которые могут быть квадратами других элементов: ")
System.Console.WriteLine(count_square_elements arr)

// Задание 9. Реализовать функцию, которая по трем спискам составляет список, состоящий из кортежей длины 3, 
// где каждый кортеж (ai,bi,ci) с номером I получен следующим образом:
// Ai – I по убыванию элемент первого списка
// Bi – I по возрастанию суммы цифр элемент второго списка
// Сi - I по убыванию количества делителей элемент третьего списка

let digit_sum n:int =
    let rec digit_sum_inner n curSum =
        if n = 0 then curSum
        else
            let n1 = n/10
            let digit = n%10
            let sum = curSum + digit
            digit_sum_inner n1 sum
    digit_sum_inner n 0

let count_divisors n =
    if n = 0 then 0
    else
        let nAbs = abs n
        [1..nAbs] |> List.filter (fun x -> nAbs % x = 0) |> List.length

let create_tuples (listA: int list) (listB: int list) (listC: int list) =
    let sortedA = listA |> List.sortByDescending id
    
    let sortedB = 
        listB 
        |> List.sortBy (fun x -> (digit_sum x, abs x))
    
    let sortedC = 
        listC 
        |> List.sortByDescending (fun x -> (count_divisors x, abs x))
    
    List.zip3 sortedA sortedB sortedC

let read_and_sort_strings_by_length () =
    let rec readLines acc =
        let line = System.Console.ReadLine()
        if String.IsNullOrEmpty line then
            acc
        else
            readLines (line :: acc)
    
    let lines = readLines [] |> List.rev
    lines |> List.sortBy (fun s -> s.Length)


let listA = [32; 51; 38; 42]   
let listB = [41; 64; 98; 21]
let listC = [75; 56; 81; 36]
System.Console.Write("Список из кортежей (ai, bi, ci): ")
System.Console.WriteLine(create_tuples listA listB listC)
System.Console.WriteLine("Введите строки (пустая строка - остановка):")
let sorted_strings = read_and_sort_strings_by_length ()
System.Console.WriteLine("Отсортированные по длине строки: ")
sorted_strings |> List.iter (System.Console.WriteLine)


// 1.10	Даны два массива. Необходимо найти количество совпадающих по значению элементов.

let count_common_church (arr1: int array) (arr2: int array) =
    let lst2 = Array.toList arr2
    let rec exists_in x lst =
        match lst with
        | head :: tail -> if head = x then true else exists_in x tail
        | [] -> false
    let rec count lst =
        match lst with
        | head :: tail ->
            let tailCount = count tail
            if exists_in head lst2 then 1 + tailCount else tailCount
        | [] -> 0

    count (Array.toList arr1)

let count_common_list (arr1: int array) (arr2: int array) =
    let lst1 = Array.toList arr1
    let lst2 = Array.toList arr2
    lst1 |> List.filter (fun x -> List.contains x lst2) |> List.length

let arr1 = [| 1; 2; 3; 4; 3; 2; 1 |]
let arr2 = [| 3; 7; 3; 8; 2; 9 |]

Console.WriteLine("Количество совпадающих по значению элементов:")
Console.Write("Чёрч: ")
Console.WriteLine(count_common_church arr1 arr2)
Console.Write("Лист: ")
Console.WriteLine(count_common_list arr1 arr2)

// 1.20	Дан целочисленный массив. Необходимо найти все пропущенные числа

let find_missing_church (arr: int array) =
    let lst = Array.toList arr

    let rec find_min_max lst currentMin currentMax =
        match lst with
        | [] -> (currentMin, currentMax)
        | head :: tail ->
            let newMin = if head < currentMin then head else currentMin
            let newMax = if head > currentMax then head else currentMax
            find_min_max tail newMin newMax

    let (minVal, maxVal) =
        match lst with
        | [] -> failwith "Пустой массив"
        | head :: tail -> find_min_max tail head head

    let rec exists x lst =
        match lst with
        | head :: tail -> if head = x then true else exists x tail
        | [] -> false

    let rec build_missing current maxVal acc =
        if current > maxVal then List.rev acc
        else
            if exists current lst then
                build_missing (current + 1) maxVal acc
            else
                build_missing (current + 1) maxVal (current :: acc)

    build_missing minVal maxVal []

let find_missing_list (arr: int array) =
    let lst = Array.toList arr
    let minVal = List.min lst
    let maxVal = List.max lst
    [minVal .. maxVal] |> List.filter (fun x -> not (List.contains x lst))

let arr3 = [| 1; 2; 4; 6; 7; 9 |]

Console.WriteLine("Пропущенные числа в массиве:")
Console.Write("Чёрч: ")
let missingChurch = find_missing_church arr3
Console.WriteLine(String.Join(", ", missingChurch))
    
Console.Write("Лист: ")
let missingList = find_missing_list arr3
Console.WriteLine(String.Join(", ", missingList))

// 1.30	Дан целочисленный массив и натуральный индекс (число, меньшее размера массива). 
// Необходимо определить является ли элемент по указанному индексу локальным максимумом.

let rec get_element idx lst =
    match lst with
    | head :: tail -> if idx = 0 then head else get_element (idx - 1) tail
    | [] -> failwith "Индекс вне диапазона"

let is_local_max_church (arr: int array) (index: int) =
    let lst = Array.toList arr
    match lst with
    | [] -> false
    | _ ->
        let elem = get_element index lst
        let leftOpt = if index > 0 then Some (get_element (index - 1) lst) else None
        let rightOpt = if index < (List.length lst - 1) then Some (get_element (index + 1) lst) else None
        match (leftOpt, rightOpt) with
        | (Some left, Some right) -> elem > left && elem > right
        | (None, Some right) -> elem > right
        | (Some left, None) -> elem > left
        | (None, None) -> true

let is_local_max_list (arr: int array) (index: int) =
    if index < 0 || index >= Array.length arr then false
    else
        let lst = Array.toList arr
        let elem = List.item index lst
        let leftOpt = if index > 0 then Some (List.item (index - 1) lst) else None
        let rightOpt = if index < (List.length lst - 1) then Some (List.item (index + 1) lst) else None
        match (leftOpt, rightOpt) with
        | (Some left, Some right) -> elem > left && elem > right
        | (None, Some right) -> elem > right
        | (Some left, None) -> elem > left
        | (None, None) -> true

let arr4 = [| 3; 5; 4; 7; 6; 2 |]
Console.WriteLine("Проверка элемента по индексу 3 на локальный максимум:")
Console.Write("Чёрч: ")
Console.WriteLine(is_local_max_church arr4 3)
Console.Write("Лист: ")
Console.WriteLine(is_local_max_list arr4 3)

// 1.40	Дан целочисленный массив. Необходимо найти минимальный четный элемент.

let find_min_even_church (arr: int array) =
    let lst = Array.toList arr
    let rec find_min candidate lst =
        match lst with
        | [] -> candidate
        | head :: tail ->
            if head % 2 = 0 then
                let newCandidate =
                    match candidate with
                    | None -> Some head
                    | Some cur -> Some (if head < cur then head else cur)
                find_min newCandidate tail
            else
                find_min candidate tail
    match find_min None lst with
    | Some result -> result
    | None -> failwith "Нет чётных элементов"

let find_min_even_list (arr: int array) =
    let lst = Array.toList arr
    let evens = List.filter (fun x -> x % 2 = 0) lst
    if evens.IsEmpty then failwith "Нет чётных элементов"
    else List.min evens

let arr5 = [| 7; 4; 9; 2; 8; 3; 10 |]

Console.WriteLine("Минимальный чётный элемент в массиве:")
Console.Write("Чёрч: ")
Console.WriteLine(find_min_even_church arr5)
Console.Write("Лист: ")
Console.WriteLine(find_min_even_list arr5)

// 1.50. Для двух введенных списков L1 и L2 построить новый список, состоящий из элементов, 
// встречающихся только в одном из этих списков и не повторяющихся в них.

let symmetric_unique_church (l1: 'a list) (l2: 'a list) =
    let rec count_occ x lst =
        match lst with
        | [] -> 0
        | h :: t -> (if h = x then 1 else 0) + count_occ x t

    let rec exists x lst =
        match lst with
        | [] -> false
        | h :: t -> if h = x then true else exists x t

    let rec filter_unique lst other acc =
        match lst with
        | [] -> List.rev acc
        | h :: t ->
            if count_occ h lst = 1 && not (exists h other) then
                filter_unique t other (h :: acc)
            else
                filter_unique t other acc

    let uniqueFromL1 = filter_unique l1 l2 []
    let uniqueFromL2 = filter_unique l2 l1 []
    uniqueFromL1 @ uniqueFromL2

let symmetric_unique_list (l1: 'a list) (l2: 'a list) =
    let uniqueFromL1 = 
        l1 |> List.filter (fun x -> (l1 |> List.filter ((=) x) |> List.length) = 1 
                                      && not (List.contains x l2))
    let uniqueFromL2 = 
        l2 |> List.filter (fun x -> (l2 |> List.filter ((=) x) |> List.length) = 1 
                                      && not (List.contains x l1))
    uniqueFromL1 @ uniqueFromL2


let L1 = [1; 2; 3; 4; 2; 5]
let L2 = [3; 6; 7; 3; 8; 9]

Console.WriteLine("Элементы, встречающиеся только в одном из списков и не повторяющиеся в них:")
Console.Write("Черч: ")
let resultChurch = symmetric_unique_church L1 L2
Console.WriteLine(String.Join(", ", resultChurch))

Console.Write("Лист: ")
let resultList = symmetric_unique_list L1 L2
Console.WriteLine(String.Join(", ", resultList))
