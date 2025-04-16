
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