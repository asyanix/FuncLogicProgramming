
man(anatoliy).
man(dimitriy).
man(vlad).
man(kirill).
man(mefodiy).
woman(vladina).
woman(galya).
woman(sveta).
woman(zoya).
woman(katrin).
child(dimitriy, anatoliy).
child(dimitriy, galya).
child(vladina, anatoliy).
child(vladina, galya).
child(kirill, dimitriy).
child(mefodiy, dimitriy).
child(kirill, sveta).
child(mefodiy, sveta).
child(zoya, vlad).
child(zoya, vladina).
child(katrin, vlad).
child(katrin, vladina).

men :- man(X), write(X), nl, fail.
women :- woman(X), write(X), nl, fail.
parent(X, Y) :- child(Y, X).
mother(X, Y) :- woman(X), child(Y, X).

brother(X, Y) :- 
    man(X), 
    child(X, P1), child(Y, P1),
    child(X, P2), child(Y, P2),
    X \= Y.

brothers(X) :- brother(Y, X), write(Y), nl, fail.

b_s(X, Y) :-
    child(X, P1), child(Y, P1),
    child(X, P2), child(Y, P2),
    X \= Y.

b_s(X) :- b_s(X, Y), write(Y), nl, fail.

# Построить предикат father(X, Y), который проверяет, является ли  X отцом Y. Построить предикат, father(X), который выводит отца X.

father(X, Y) :-
    man(X),
    child(Y, X).

# Построить предикат wife(X, Y), который проверяет, является ли X женой Y. Построить предикат wife(X), который выводит жену X.

wife(X, Y) :-
    woman(X),
    man(Y),
    child(C, X),
    child(C, Y).

# Построить предикат grand_da(X, Y), который проверяет, является ли X внучкой Y. 
# Через базу фактов

grand_da(X, Y) :-
    woman(X),
    child(X, Z),
    child(Z, Y).

# Через предикаты

grand_da(X, Y) :-
    woman(X),
    parent(Z, X),
    parent(Y, Z).

# Построить предикат grand_dats(X), который выводит всех внучек X.
# Через базу фактов

grand_dats(X) :-
    woman(GD),
    child(GD, Z),
    child(Z, X),
    write(GD), nl,
    fail.

# Через предикаты

grand_dats(X) :-
    grand_da(GD, X),
    write(GD), nl,
    fail.

# Построить предикат grand_pa_and_da(X,Y), который проверяет, являются ли X и Y дедушкой и внучкой или внучкой и дедушкой.
# Через базу фактов

 grand_pa_and_da(X, Y) :-
    (man(X), woman(Y), child(Y, Z), child(Z, X));
    (man(Y), woman(X), child(X, Z), child(Z, Y)).

# Через предикаты

grand_pa_and_da(X, Y) :-
    (man(X), grand_da(Y, X));
    (man(Y), grand_da(X, Y)).

# Построить предикат, который проверяет, является ли X тетей Y. 
# Через базу фактов

aunt(X, Y) :-
    woman(X),
    child(Y, P),
    child(X, P1), child(P, P1),
    X \= P.

# Через предикаты

aunt(X, Y) :-
    woman(X),
    parent(P, Y),
    b_s(X, P).

# Построить предикат, который выводит всех тетей X.
# Через базу фактов
aunts(X) :-
    woman(A),
    child(X, P),
    child(A, GP),
    child(P, GP),
    A \= P,
    write(A), nl,
    fail.

# Через предикаты
aunts(X) :-
    aunt(A, X),
    write(A), nl,
    fail.
