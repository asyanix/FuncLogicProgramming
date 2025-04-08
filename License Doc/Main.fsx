#load "License.fsx"
open Documents
open System

let license = DriverLicense(
        lastName = "Чеуж",
        firstName = "Асиет",
        middleName = "Асланбиевна",
        birthDate = DateTime(2005, 2, 22),
        series = "9829",
        number = "214817",
        issueDate = DateTime(2024, 11, 19),
        category = "B"
)

license.Print()

printfn "\nВалидация: %b" (license.Validate())


let license2 = DriverLicense(
    lastName = "НеЧеуж",
    firstName = "НеАсиет",
    middleName = "НеАсланбиевна",
    birthDate = DateTime(2002, 2, 22),
    series = "9829",
    number = "214817",
    issueDate = DateTime(2024, 11, 19),
    category = "B"
)

printfn "\nСовпадают по серии и номеру? %b" (license.Equals(license2))
