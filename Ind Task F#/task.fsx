let sumTo n =
    let rec sumRec acc i =
        match i > n with
        | true -> acc
        | false -> sumRec (acc + i) (i + 1)
    sumRec 0 1

let rec rectangles width height =
    match (width, height) with
    | (1, 1) -> 1
    | _ when width < height -> rectangles height width
    | _ ->
        let basicRects = width * sumTo height       // Общее количество обычных прямоугольников равно (1 + 2 + … + Y) * X

        let diagonalRects =
            [1 .. height]                           // Перебор всех индексов правых вершин диагональных прямоугольников (от верхней до центральной)
            |> List.sumBy (fun i ->                 // По симметрии считаем только первую половину вершин (всего вершин 2*height - 1)
                let y = i                           // Высота диагонального прямоугольника
                let x = height * 2 - y              // Ширина диагонального прямоугольника

                let area =
                    match width > height with
                    | true -> x * y
                    | false -> x * y - (y % 2)      // Когда прямоугольник не вмещается полностью и надо вычесть 1

                match x = y with
                | true -> area
                | false -> area * 2                 // Учитываем симметрию
            )                                       // Общее количество диагональных прямоугольников равно i * (2Y - i)

        basicRects + diagonalRects + rectangles (width - 1) height

let total = List.sumBy (fun x -> List.sumBy (fun y -> rectangles x y) [1..43]) [1..47]

printfn "Всего прямоугольников: %d" total
