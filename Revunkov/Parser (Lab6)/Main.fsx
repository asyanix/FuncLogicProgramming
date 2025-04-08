#load "Parser.fsx"
open MyParser.Parser
open MyParser

let input = "3 + 4 * (2 - 1)"
match parseExpression input with
    | Success(result, _, _) ->
        // Если разбор успешен, выводим разобранное выражение (значение типа Expression).
        printfn "Разобранное выражение: %A" result
    | Failure(errorMsg, _, _) ->
        // В случае ошибки разбора выводим сообщение об ошибке.
        printfn "Ошибка разбора: %s" errorMsg