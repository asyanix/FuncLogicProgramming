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
