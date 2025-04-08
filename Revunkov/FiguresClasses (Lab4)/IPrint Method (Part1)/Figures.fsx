namespace Geometry

type IPrint =
    abstract member Print: unit -> unit

[<AbstractClass>]
type Shape() =
    // Виртуальный метод для вычисления площади
    abstract member Area : unit -> float
    default this.Area() = 0.0


type Rectangle(width: float, height: float) =
    inherit Shape()
    member this.Width = width
    member this.Height = height

    override this.Area() = this.Width * this.Height

    override this.ToString() =
        sprintf "Прямоугольник: ширина=%.2f, высота=%.2f, площадь=%.2f" this.Width this.Height (this.Area())

    interface IPrint with
        member this.Print() = printfn "%s" (this.ToString())

type Square(side: float) =
    inherit Rectangle(side, side)
    
    override this.ToString() =
        sprintf "Квадрат: сторона=%.2f, площадь=%.2f" side (this.Area())

type Circle(radius: float) =
    inherit Shape()

    member this.Radius = radius

    override this.Area() = System.Math.PI * this.Radius * this.Radius

    override this.ToString() =
        sprintf "Круг: радиус=%.2f, площадь=%.2f" this.Radius (this.Area())

    interface IPrint with
        member this.Print() = printfn "%s" (this.ToString())
