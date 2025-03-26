// Задание 7. Написать функцию обход числа, которая выполняет операции на цифрами числа, 
// принимает три аргумента, число, функция (например, сумма, произведение, минимум, максимум)
// и инициализирующее значение. Функция должна иметь два Int аргумента и возвращать Int.

// Задание 8. Протестировать эту функцию на операциях  сумма, произведение, минимум, максимум 
// цифр числа. Для тестирования и передачи аргумента использовать лямбда выражения. 
// Инициализирующее заполнение должно иметь значение по умолчанию.

// Задание 13. Написать функцию обход взаимно простых компонентов числа, которая выполняет 
// операции над числами, взаимно простыми с данным, принимает три аргумента, число, функция 
// (например, сумма, произведение, минимум, максимум, количество) и инициализирующее значение. 
// Функция должна иметь два Int аргумента и возвращать Int.

// Задание 14. Протестировать написанную функцию. Построить на её основе функции для вычисления числа Эйлера.

// Задание 15. На основе написанных функций построить функции обход  взаимнопростых с условием. Протестировать.

let rec obhod_chisla n (f: int->int->int) acc =
     match n with
     | 0 -> acc
     | n -> obhod_chisla (n/10) f (f acc (n%10))

let count_ a b = a+1
 
let sum_ a b = a+b
 
let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)
 
let are_сoprimes a b =
    gcd a b = 1
 
let obhod_chisla_coprime num (func :int->int->int) initial =
    let rec obhod num acc c =
        match c with
        | 0 -> acc
        | _ ->
            let newAcc = if are_сoprimes num c then func acc c else acc
            obhod num newAcc (c-1)
    obhod num initial num

let euler_func number =
    obhod_chisla_coprime number (fun x y -> x + 1) 0

let obhod_chisla_coprime_condition num (func :int->int->int) initial condition =
    let rec obhod num acc c =
        match c with
        | 0 -> acc
        | _ ->
            let newc = c-1
            let flag = condition c
            match flag, are_сoprimes num c with
            | true, true -> obhod num (func acc c) newc
            | _, _ -> obhod num acc newc
    obhod num initial num

let minDigit a b =
    match (a, b) with
    | (a, b) when a <= b -> a
    | _ -> b

let maxDigit a b =
    match (a, b) with
    | (a, b) when a >= b -> a
    | _ -> b

let lessThan5 n = n < 5 

System.Console.WriteLine(obhod_chisla 348 maxDigit 0)
System.Console.WriteLine(obhod_chisla 412 count_ 0)
System.Console.WriteLine(obhod_chisla 634 sum_ 0)
System.Console.WriteLine(obhod_chisla 865 minDigit 9)

System.Console.WriteLine(obhod_chisla_coprime 10 (+) 0)  

System.Console.WriteLine(euler_func 20)  

System.Console.WriteLine(obhod_chisla_coprime_condition 10 (+) 0 lessThan5)

