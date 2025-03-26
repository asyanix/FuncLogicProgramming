// Задание 11. Спросить у пользователя, какой язык у него любимый, если это F# или 
// Prolog, ответь пользователю, что он — подлиза, для других языков придумать комментарий, 
// реализовать функцию, принимающую аргументом ответ пользователя и возвращающую наш ответ пользователю.

// Задание 12. Предыдущую программу реализовать в функции main с помощью только оператора суперпозиции, 
// потом только с помощью оператора каррирования.


let favoriteLanguage language =
    match language with
    | "F#" | "Prolog" -> "Подлиза!"
    | "Swift" -> "Ты такой необычный"
    | "Pascal" -> "Привет, Амаль"
    | "R" -> "Подлиза #2"
    | _ -> "Ого, интересный выбор..."
 
let askUserSuper = (fun () -> System.Console.WriteLine("Какой язык программирования твой любимый?"); System.Console.ReadLine()) >> favoriteLanguage >> System.Console.WriteLine

askUserSuper ()

let addFunc input output = output (favoriteLanguage input)

System.Console.WriteLine("Какой язык программирования твой любимый?")
let askUserCarry = addFunc (System.Console.ReadLine())
askUserCarry System.Console.WriteLine