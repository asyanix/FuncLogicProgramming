// Задание 9. Реализовать функцию обход числа с условием, которая выполняет 
// операции над цифрами, если цифры удовлетворяют заданному условию. Аргументы 
// функции: число, функция с двумя аргументами Int, возвращающая Int, инициализирующее 
// заполнение, функция с одним аргументом Int, возвращающая true-false.

// Задание 10. Проверить функцию на 3 различных примерах.


let rec obhod_chisla_condition n (f: int->int->int) acc (condition: int->bool) =
    match n with
    | 0 -> acc
    | n ->
        let digit = n % 10
        let newAcc = 
            match condition digit with
            | true -> f acc digit
            | false -> acc
        obhod_chisla_condition (n/10) f newAcc condition

let count_ a b = a+1
let sum_ a b = a+b
 
let equal9 n = n == 9
let isNotEven n = n % 2 = 1
let smallerThan7 n = n < 7
 
System.Console.WriteLine(obhod_chisla_condition 984287291 count_ 0 smallerThan7)
System.Console.WriteLine(obhod_chisla_condition 984287291 sum_ 0 isNotEven)
System.Console.WriteLine(obhod_chisla_condition 984287291 count_ 0 equal9)
