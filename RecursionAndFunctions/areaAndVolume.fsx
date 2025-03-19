let areaOfCircle r = System.Math.PI * r * r

let volumeOfCylinder r h = areaOfCircle r * h

let main () =
    printf "Введите радиус круга: "
    let radius = float (System.Console.ReadLine())

    printf "Введите высоту цилиндра: "
    let height = float (System.Console.ReadLine())

    let area = areaOfCircle radius
    let volume = volumeOfCylinder radius height

    printfn "Площадь круга: %f" area
    printfn "Объем цилиндра: %f" volume

main ()
