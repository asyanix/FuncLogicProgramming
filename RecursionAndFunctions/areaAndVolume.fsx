let areaOfCircle r = System.Math.PI * r * r

let volumeOfCylinder r h = areaOfCircle r * h
let areaOfCircleWithCarry r = fun () -> System.Math.PI * r * r

let volumeOfCylinderWithCarry r = fun h -> areaOfCircleWithCarry r () * h

let main () =
    printf "Введите радиус круга: "
    let radius = float (System.Console.ReadLine())

    printf "Введите высоту цилиндра: "
    let height = float (System.Console.ReadLine())

    let area = areaOfCircle radius
    let volume = volumeOfCylinder radius height

    printfn "Площадь круга: %f" area
    printfn "Объем цилиндра: %f" volume

    printf "Введите радиус круга: "
    let radius = float (System.Console.ReadLine())

    printf "Введите высоту цилиндра: "
    let height = float (System.Console.ReadLine())

    let area = areaOfCircleWithCarry radius ()
    let volume = volumeOfCylinderWithCarry radius height

    printfn "Площадь круга: %f" area
    printfn "Объем цилиндра: %f" volume
main ()
