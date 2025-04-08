namespace Geometry

module Figures =

    type Figure =
        | Rectangle of width: float * height: float
        | Square of side: float
        | Circle of radius: float

    let computeArea (figure: Figure) : float =
        match figure with
        | Rectangle (width, height) -> width * height
        | Square side -> side * side
        | Circle radius -> System.Math.PI * radius * radius

    let solveQuadratic (a: float) (b: float) (c: float) =
        let discriminant = b * b - 4.0 * a * c
        match discriminant with
        | d when d > 0.0 ->
            let x1 = (-b + sqrt d) / (2.0 * a)
            let x2 = (-b - sqrt d) / (2.0 * a)
            sprintf "Два корня: x1 = %.2f, x2 = %.2f" x1 x2
        | 0.0 ->
            let x = -b / (2.0 * a)
            sprintf "Один корень: x = %.2f" x
        | _ ->
            "Корней нет (дискриминант отрицательный)"
