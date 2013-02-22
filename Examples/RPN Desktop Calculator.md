# RPN Desktop Calculator
Idea is taken from [Brett Schuchert´s video series](http://vimeo.com/album/205252)

A RPN calculator works on math formulas in postfix notation rather than infix:

* Infix: 2 + 3 * 4 is either 20 (no op precedence) or 14 (with op precedence)
* Postfix: 2 3 + 4 * is 20 or 2 3 4 + * is 14 or 2 3 4 * + is 14

The UI should roughly look like this:

![](images/rpncalc_macosx.jpg)

The current number on the last line (4) (entry field) is put on a stack (numbers 2 and 3) upon pressing ENTER.

Or the current number (4) is combined with the stack top (3) upon pressing an operator leading to a new current number.

Or the stack is reduced by pressing DROP which means the stack top is removed and replaces the current number.

The calculator only needs to support integer numbers, the basic operators {+, -, *, /}, the advanced operator !, ENTER and DROP.

To quickly gain feedback, development should move forward in small increments:

1. ENTER numbers, show stack
1. +
1. DROP
1. -, *, /
1. !

## Design

## Tests
