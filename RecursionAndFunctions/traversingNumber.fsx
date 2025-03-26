// Задание 7. Написать функцию обход числа, которая выполняет операции на цифрами числа, 
// принимает три аргумента, число, функция (например, сумма, произведение, минимум, максимум)
// и инициализирующее значение. Функция должна иметь два Int аргумента и возвращать Int.

let rec obhod_chisla n (f: int->int->int) acc =
     match n with
     | 0 -> acc
     | n -> obhod_chisla (n/10) f (f acc (n%10))

let inc_ a b = a+1 in
System.Console.WriteLine(obhod_chisla 325 inc_ 0)
let sum_ a b = a+b in
System.Console.WriteLine(obhod_chisla 634 sum_ 0)