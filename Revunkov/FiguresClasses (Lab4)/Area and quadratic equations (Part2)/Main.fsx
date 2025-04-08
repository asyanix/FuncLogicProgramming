// Main.fsx

#load "Figures.fsx"
open Geometry.Figures

let rectangle = Rectangle (5.0, 3.0)
let square = Square 4.0
let circle = Circle 2.5

printfn "Площадь прямоугольника: %.2f" (computeArea rectangle)
printfn "Площадь квадрата: %.2f" (computeArea square)
printfn "Площадь круга: %.2f" (computeArea circle)

let quadraticResult = solveQuadratic 1.0 -3.0 2.0
printfn "\nВычисление корней квадратного уравнения: %s" quadraticResult
