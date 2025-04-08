#load "Figures.fsx"
open Geometry

let printShape (shape: IPrint) =
    shape.Print()

let rectangle = new Rectangle(5.0, 3.0)
let square = new Square(4.0)
let circle = new Circle(2.5)

printfn "Вывод информации о фигурах:"
printShape rectangle
printShape square
printShape circle

printfn "\nВывод через вызов ToString():"
printfn "%s" (rectangle.ToString())
printfn "%s" (square.ToString())
printfn "%s" (circle.ToString())
