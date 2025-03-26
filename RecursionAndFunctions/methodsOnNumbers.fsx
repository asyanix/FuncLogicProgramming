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