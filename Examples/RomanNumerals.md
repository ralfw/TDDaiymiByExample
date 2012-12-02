# Roman Numerals - From Decimal To Roman
Write a function to convert integers to roman numerals represented as strings. The function could look like this:

	string ToRoman(int decimal)

A sample conversion is this:

* 1999 = MCMXCIX

For details on roman numerals see for example [Wikipedia](http://en.wikipedia.org/wiki/Roman_numerals).

* The range of integers to cover is 1..3000.

This exercise is taken from [here](http://codingdojo.org/cgi-bin/wiki.pl?KataRomanNumerals).

## Design
The basic building blocks for arabic numbers or decimal numbers are the digits 0..9 and powers of 10 (10, 100, 1000, 10000 etc.).

The basic building blocks for roman numbers firstly are I (1), V (5), X (10), L (50), C (100), D (500), M (1000). But then there are "shortcuts" to express some numbers: 4 is written IV instead of IIII, 9 is written IX instead of VIIII, 900 is written CM instead of DCCCC etc. These shortcuts should be treated as composite building blocks of their own: IV (4), IX (9), XV (40), XC (90), CD (400), CM (900).

Now, to convert a decimal number to roman numerals you can iteratively find the largest roman number building block, e.g.

1. 1999 -> M (1000), remainder: 999
2. 999 -> CM (900), remainder: 99
3. 99 -> XC (90), remainder: 9
4. 9 -> IX (9), remainder: 0

## Test Cases
* 5 = "V" // decimal matches building block
* 9 = "IX"
* 400 = "CD"
* 6 = "VI" // decimal needs to be build from non-repeating building blocks
* 906 = "CMVI"
* 7 = "VII" // decimal needs to be build from repeating building blocks
* 1999 = "MCMXCIX" // acceptance tests
* 3000 = "MMM"
* 1954 = "MCMLIV"
* 3001 = Exception! // outside of range
* 0 = Exception!
