#load "Maybe.fsx"
open Functional.Maybe

let inc x = x + 1
let double x = x * 2

let compose f g x = f (g x)

// Проверка законов для функтора

// Закон тождества: map id m = m
let functorIdentityLaw m =
    map id m = m

// Закон композиции: map (f ∘ g) m = map f (map g m)
let functorCompositionLaw m f g =
    map (compose f g) m = map f (map g m)

let m1 = Just 3
let mNothing = Nothing

printfn "=== Тестирование законов для функтора ==="
printfn "Закон тождества для функтора (Just 3): %b" (functorIdentityLaw m1)
printfn "Закон тождества для функтора (Nothing): %b" (functorIdentityLaw mNothing)
printfn "Закон композиции для функтора (Just 3, inc, double): %b" (functorCompositionLaw m1 inc double)
printfn "Закон композиции для функтора (Nothing, inc, double): %b" (functorCompositionLaw mNothing inc double)


// Проверка законов для аппликативного функтора 

// Закон идентичности: pure id <*> v = v
let applicativeIdentityLaw v =
    apply (pure id) v = v

// Закон гомоморфизма: pure f <*> pure x = pure (f x)
let applicativeHomomorphismLaw f x =
    apply (pure f) (pure x) = pure (f x)

// Закон интерчейнджа: u <*> pure y = pure (fun f -> f y) <*> u
let applicativeInterchangeLaw u y =
    apply u (pure y) = apply (pure (fun f -> f y)) u

// Закон композиции: pure (.) <*> u <*> v <*> w = u <*> (v <*> w)
let applicativeCompositionLaw u v w =
    let composeOp = (fun f g x -> f (g x))
    let left = apply (apply (apply (pure composeOp) u) v) w
    let right = apply u (apply v w)
    left = right

printfn "Закон идентичности (Just 3): %b" (applicativeIdentityLaw m1)
printfn "Закон идентичности (Nothing): %b" (applicativeIdentityLaw mNothing)
printfn "Закон гомоморфизма (inc, 3): %b" (applicativeHomomorphismLaw inc 3)

// Для закона интерчейнджа возьмём Just inc в качестве u и 3 в качестве y:
let u1 = Just inc
printfn "Закон интерчейнджа (Just inc, 3): %b" (applicativeInterchangeLaw u1 3)

// Для закона композиции проверим на u = Just inc, v = Just double, w = Just 3:
let u = Just inc
let v = Just double
let w = Just 3
printfn "Закон композиции: %b" (applicativeCompositionLaw u v w)


// Проверка законов для монады

// Закон левого нейтрального элемента: return a >>= f = f a
let monadLeftIdentityLaw a f =
    (pure a >>= f) = (f a)

// Закон правого нейтрального элемента: m >>= return = m
let monadRightIdentityLaw m =
    (m >>= pure) = m

// Закон ассоциативности: (m >>= f) >>= g = m >>= (fun x -> f x >>= g)
let monadAssociativityLaw m f g =
    ((m >>= f) >>= g) = (m >>= (fun x -> f x >>= g))

let f x = Just (inc x)
let g x = Just (double x)

printfn "Закон левого нейтрального элемента для монады (3, f): %b" (monadLeftIdentityLaw 3 f)
printfn "Закон правого нейтрального элемента для монады (Just 3): %b" (monadRightIdentityLaw m1)
printfn "Закон правого нейтрального элемента для монады (Nothing): %b" (monadRightIdentityLaw mNothing)
printfn "Закон ассоциативности для монады (Just 3): %b" (monadAssociativityLaw m1 f g)
printfn "Закон ассоциативности для монады (Nothing): %b" (monadAssociativityLaw mNothing f g)


// Демонстрация использования функций для Maybe 

let result1 = map inc m1           // Должно дать Just 4
let result2 = apply (Just inc) m1    // Должно дать Just 4
let result3 = m1 >>= f              // Должно дать Just 4

printfn "map inc (Just 3) = %s" (toString string result1)
printfn "apply (Just inc) (Just 3) = %s" (toString string result2)
printfn "bind (Just 3) f (через >>=) = %s" (toString string result3)
