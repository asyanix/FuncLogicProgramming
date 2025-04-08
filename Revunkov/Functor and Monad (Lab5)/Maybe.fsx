namespace Functional

module Maybe =
    type Maybe<'a> =
        | Nothing
        | Just of 'a

    // Функтор: функция map для применения функции f к значению внутри Maybe
    let map (f: 'a -> 'b) (m: Maybe<'a>) : Maybe<'b> =
        match m with
        | Nothing -> Nothing
        | Just x -> Just (f x)

    // Аппликативный функотор: функция pure для подъёма значения в Maybe
    let pure (x: 'a) : Maybe<'a> = Just x

    // Аппликативный функотор: функция apply, которая применяет обёрнутую в Maybe функцию к значению в Maybe  
    let apply (mf: Maybe<'a -> 'b>) (m: Maybe<'a>) : Maybe<'b> =
        match mf, m with
        | Just f, Just x -> Just (f x)
        | _ , _ -> Nothing

    // Монада: функция bind для связывания вычислений, возвращающих Maybe  
    let bind (m: Maybe<'a>) (f: 'a -> Maybe<'b>) : Maybe<'b> =
        match m with
        | Nothing -> Nothing
        | Just x -> f x

    // Оператор для bind
    let (>>=) m f = bind m f

    let toString (toStr: 'a -> string) (m: Maybe<'a>) : string =
        match m with
        | Nothing -> "Nothing"
        | Just x -> "Just (" + (toStr x) + ")"
