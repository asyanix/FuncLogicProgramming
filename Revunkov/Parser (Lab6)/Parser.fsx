namespace MyParser

#r "nuget: FParsec"

open FParsec

type Expression =
    | Const of int
    | Add of Expression * Expression
    | Subtract of Expression * Expression
    | Multiply of Expression * Expression
    | Divide of Expression * Expression

module Parser =
    let ws = spaces
    let str_ws s = pstring s .>> ws
    let pint_ws = pint32 .>> ws

    // expr = term ((«+» | «-») term)*
    let rec expr() = chainl1 (term()) addOp

    // term = factor ((«*» | «/») factor)*
    and term() = chainl1 (factor()) mulOp

    and factor() =
        choice [
            between (str_ws "(") (str_ws ")") (expr())
            pint_ws |>> Const
        ]

    // Парсер для операций сложения и вычитания.
    and addOp = 
        (str_ws "+" >>% (fun a b -> Add(a, b))) <|>
        (str_ws "-" >>% (fun a b -> Subtract(a, b)))

    // Парсер для операций умножения и деления.
    and mulOp =
        (str_ws "*" >>% (fun a b -> Multiply(a, b))) <|>
        (str_ws "/" >>% (fun a b -> Divide(a, b)))

    // Функция для разбора выражения из входной строки.
    let parseExpression input =
        run (ws >>. expr() .>> eof) input
