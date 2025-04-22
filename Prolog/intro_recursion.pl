# Реализовать предикат max(+X,+Y,+U,-Z), где U максимальное из чисел X, Y и Z.

max(X, Y, X):- X>Y,!.
max(_,Y,Y).

max(X,Y,Z,U):-
    max(X,Y,M),max(M,Z,U).

max(X,Y,Z,X):- X>Y, X>Z,!.
max(_,Y,Z,Y):- Y>Z,!.
max(_,_,Z,Z).

# Реализовать предикат fact(N,X), где X – это факториал первого аргумента с помощью рекурсии вверх, рекурсии вниз.

fact_down(N, X) :- fact_down(N, 1, X).

fact_down(0, Acc, Acc).
fact_down(N, Acc, X) :-
    N > 0,
    Acc1 is Acc * N,
    N1 is N - 1,
    fact_down(N1, Acc1, X).

# Найти сумму цифр числа с помощью рекурсии вверх. Найти сумму цифр числа с помощью рекурсии вниз.

sum(0,0):-!.
sum(N,S):- Cifr is N mod 10,
    NewN is N div 10, sum(NewN, NewSum),
    S is NewSum + Cifr.

sum_numbers(X, Answer):-
    sum_numbers_tailed(X,0,Answer).
sum_numbers_tailed(0,Acc,Acc):-!.
sum_numbers_tailed(X,Acc,Answer):-
    X1 is X // 10,
    Acc1 is Acc + X mod 10,
    sum_numbers_tailed(X1, Acc1, Answer).
