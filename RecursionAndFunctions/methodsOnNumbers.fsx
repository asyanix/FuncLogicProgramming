// Задание 16. «Работа с числами». Составить 3 функции для работы 
// с цифрами или делителей числа на основании варианта с использованием 
// только хвостовой рекурсии и функций высших порядков.

// Метод 1. Найти сумму непростых делителей числа.

let isPrime n =
    let rec check d =
        d * d > n || (n % d <> 0 && check (d + 1))
    n > 1 && check 2
 
let sumOfPrimeDiv number =
    let rec sumOfPrimeDiv d acc =
        match d > number with
        | true -> acc
        | false ->
            match number % d, isPrime d with
            | 0, true -> sumOfPrimeDiv (d + 1) (acc + d) 
            | _, _ -> sumOfPrimeDiv (d + 1) acc
    sumOfPrimeDiv 1 0

System.Console.WriteLine(sumOfPrimeDiv 39)

// Метод 2. Найти количество цифр числа, меньших 3.

let rec reduce num (func:int->int->int) acc: int  =
    match num with
    | 0 -> acc
    | _ -> reduce (num/10) func (func acc (num%10)) 

let countDigitsGreaterThan3 number =
    reduce number (fun acc d -> 
        match d > 3 with
        | true -> acc + 1
        | _ -> acc
    ) 0
 
let productOfDivisorsWithSmallerDigitSum number =
    let totalSum = reduce number (fun acc d -> acc + d) 0
    let rec findProduct d acc =
        match d > number with
        | true -> acc
        | false -> 
            match number % d, reduce d (fun acc x -> acc + x) 0 < totalSum with
            | 0, true -> findProduct (d + 1) (acc * d)
            | _, _ -> findProduct (d + 1) acc
    findProduct 1 1

System.Console.WriteLine(countDigitsGreaterThan3 173829)

// Метод 3. Найти количество чисел, не являющихся делителями исходного числа, не взамно 
// простых с ним и взаимно простых с суммой простых цифр этого числа.

let sumOfPrimeDigits n =
    let rec sumDigits n acc =
        if n = 0 then acc
        else
            let digit = n % 10
            let acc = if isPrime digit then acc + digit else acc
            sumDigits (n / 10) acc
    sumDigits n 0

let gcd a b =
    let rec gcdTail a b =
        if b = 0 then a else gcdTail b (a % b)
    gcdTail a b

let countNumbers number =
    let sumPrimes = sumOfPrimeDigits number
    let rec countRec n acc =
        if n > number then acc
        else
            let isNotDivisor = number % n <> 0
            let notCoprimeWithNumber = gcd number n <> 1
            let coprimeWithPrimeSum = gcd sumPrimes n = 1

            let acc = if isNotDivisor && notCoprimeWithNumber && coprimeWithPrimeSum then acc + 1 else acc
            countRec (n + 1) acc
    countRec 1 0


System.Console.WriteLine(countNumbers 30)

// Задание 20. Напишите программу, в которой пользователь вводит кортеж из двух чисел, 
// где первое число это номер одной из трех функций вашего варианта, второе число 
// аргумент этой функции. Построить функцию, которая принимает номер от 1 до 3 и 
// возвращает одну из трех написанных функций. Далее программа выполняет указанную 
// функцию и выдает результат на экран. Для реализации функции main использовать только 
// оператор каррирования, потом только оператор суперпозиции.

let selectFunc = function
    | 1 -> sumOfPrimeDiv
    | 2 -> productOfDivisorsWithSmallerDigitSum
    | 3 -> countNumbers
    | _ -> failwith "Ошибка: номер функции должен быть от 1 до 3"

let mainCurry (n, m) =
    let func = selectFunc n
    let result = func m
    printfn "Результат: %d" result

let mainSuper = selectFunc >> (fun f -> f >> printfn "Результат: %d")


printfn "Выберите функцию (от 1 до 3):"
let n = System.Int32.Parse(System.Console.ReadLine())

System.Console.WriteLine("Введите число")
let m = System.Int32.Parse(System.Console.ReadLine())

printfn "\nКаррирование:"
mainCurry (n, m)

printfn "\nСуперпозиция:"
mainSuper n m