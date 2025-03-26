// Задание 7. Написать функцию обход числа, которая выполняет операции на цифрами числа, 
// принимает три аргумента, число, функция (например, сумма, произведение, минимум, максимум)
// и инициализирующее значение. Функция должна иметь два Int аргумента и возвращать Int.

// Задание 8. Протестировать эту функцию на операциях  сумма, произведение, минимум, максимум 
// цифр числа. Для тестирования и передачи аргумента использовать лямбда выражения. 
// Инициализирующее заполнение должно иметь значение по умолчанию.

let rec obhod_chisla n (f: int->int->int) acc =
     match n with
     | 0 -> acc
     | n -> obhod_chisla (n/10) f (f acc (n%10))

let count_ a b = a+1
System.Console.WriteLine(obhod_chisla 412 count_ 0)
 
let sum_ a b = a+b
System.Console.WriteLine(obhod_chisla 634 sum_ 0)
 
let minDigit a b =
    match (a, b) with
    | (a, b) when a <= b -> a
    | _ -> b
System.Console.WriteLine(obhod_chisla 865 minDigit 9)
 
let maxDigit a b =
    match (a, b) with
    | (a, b) when a >= b -> a
    | _ -> b
System.Console.WriteLine(obhod_chisla 348 maxDigit 0)