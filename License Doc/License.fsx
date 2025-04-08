namespace Documents

open System
open System.Text.RegularExpressions

type DriverLicense
    (
        lastName: string,
        firstName: string,
        middleName: string,
        birthDate: DateTime,
        series: string,
        number: string,
        issueDate: DateTime,
        category: string
    ) =

    member this.LastName = lastName
    member this.FirstName = firstName
    member this.MiddleName = middleName
    member this.BirthDate = birthDate
    member this.Series = series
    member this.Number = number
    member this.IssueDate = issueDate
    member this.Category = category

    member this.Print() =
        printfn "Водительское удостоверение"
        printfn "ФИО: %s %s %s" this.LastName this.FirstName this.MiddleName
        printfn "Дата рождения: %s" (this.BirthDate.ToShortDateString())
        printfn "Серия: %s" this.Series
        printfn "Номер: %s" this.Number
        printfn "Дата выдачи: %s" (this.IssueDate.ToShortDateString())
        printfn "Категория: %s" this.Category

    member this.Validate() =
        let isCyrillic (s: string) = Regex("^[А-Яа-яЁё-]+$").IsMatch(s)
        let isSeriesValid = Regex("^\d{4}$").IsMatch(this.Series)
        let isNumberValid = Regex("^\d{6}$").IsMatch(this.Number)
        let isCategoryValid = Regex("^[ABCDM]+$").IsMatch(this.Category)

        isCyrillic this.LastName &&
        isCyrillic this.FirstName &&
        isCyrillic this.MiddleName &&
        isSeriesValid &&
        isNumberValid &&
        isCategoryValid


    override this.Equals(obj) =
        match obj with
        | :? DriverLicense as other ->
            this.Series = other.Series && this.Number = other.Number
        | _ -> false

    override this.GetHashCode() =
        hash (this.Series, this.Number)
