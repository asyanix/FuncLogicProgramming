namespace MyAgent

open System

type AgentMessage =
    | Print of string
    | Count
    | Stop

module Agent =
    let startAgent () =
        MailboxProcessor.Start(fun inbox ->

            let rec loop count =
                async {
                    let! msg = inbox.Receive()

                    match msg with
                    | Print text ->
                        printfn "Сообщение: %s" text
                        return! loop (count + 1)

                    | Count ->
                        printfn "Всего сообщений получено: %d" count
                        return! loop count

                    | Stop ->
                        printfn "Агент остановлен."
                        return () // выход из цикла

                }

            loop 0
        )
