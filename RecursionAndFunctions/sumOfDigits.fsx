let sumCifr n =
    let rec sumCifr1 n curSum =
        if n = 0 then curSum
        else
            let n1 = n / 10
            let cifr = n % 10
            let newSum = curSum + cifr
            sumCifr1 n1 newSum
    sumCifr1 n 0

let result = sumCifr 12345
printfn "Сумма цифр: %d" result
