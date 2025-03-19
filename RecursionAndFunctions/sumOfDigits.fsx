// Рекурсия вверх
let sumDigitsUp n =
    let rec sumDigitsUp1 n curSum =
        if n = 0 then curSum
        else
            let n1 = n / 10
            let cifr = n % 10
            let newSum = curSum + cifr
            sumDigitsUp1 n1 newSum
    sumDigitsUp1 n 0

let result = sumDigitsUp 12345
printfn "Сумма цифр: %d" result

// Рекурсия вниз
let rec sumDigitsDown n =
    if n = 0 then 0
    else (n%10) + (sumDigitsDown (n / 10))

let result2 = sumDigitsDown 12345
printfn "Сумма цифр: %d" result2

// Хвостовая рекурсия 
let rec sumDigitsTailRec (n: int, acc: int) : int =
    if n = 0 then acc                               // Базовый случай: если n = 0, возвращаем накопитель acc
    else sumDigitsTailRec (n / 10, acc + n % 10)    // Рекурсивный случай: убираем последнюю цифру и добавляем её в acc

let sumDigits n = sumDigitsTailRec (n, 0)

// Пример использования
let result3 = sumDigits 12345 
printfn "Сумма цифр: %d" result3
