open System

let readList n =
    let rec readListRec n acc = 
        match n with
            | 0 -> acc
            | k ->
                let el = Console.ReadLine() |> int
                let newAcc = acc@[el]
                readListRec (k - 1) newAcc
    readListRec n []

readList 5


let rec printList list = 
    match list with
    | [] -> Console.ReadKey()
    | head::tail ->
        Console.WriteLine(head.ToString())
        printList tail

let l = [1; 2; 3; 4; 5]
printList l

let rec reduce list (f:(int->int->int)) (pr:(int->bool)) acc =
    match list with
        | [] -> acc
        | head::tail ->
            let newAcc = if pr head then f acc head else acc
            reduce tail f pr newAcc

