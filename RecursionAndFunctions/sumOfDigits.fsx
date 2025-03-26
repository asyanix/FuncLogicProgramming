// Рекурсия вверх
let sumDigitsDown n =
    let rec sumDigitsDown1 n curSum =
        if n = 0 then curSum
        else
            let n1 = n / 10
            let cifr = n % 10
            let newSum = curSum + cifr
            sumDigitsDown1 n1 newSum
    sumDigitsDown1 n 0

let result = sumDigitsDown 12345
printfn "Сумма цифр: %d" result

// Рекурсия вниз
let rec sumDigitsUp n =
    if n = 0 then 0
    else (n%10) + (sumDigitsUp (n / 10))

let result2 = sumDigitsUp 12345
printfn "Сумма цифр: %d" result2

// Хвостовая рекурсия 
let rec sumDigitsTailRec (n: int, acc: int) : int =
    if n = 0 then acc                               // Базовый случай: если n = 0, возвращаем накопитель acc
    else sumDigitsTailRec (n / 10, acc + n % 10)    // Рекурсивный случай: убираем последнюю цифру и добавляем её в acc

let sumDigits n = sumDigitsTailRec (n, 0)

// Пример использования
let result3 = sumDigits 12345 
printfn "Сумма цифр: %d" result3
