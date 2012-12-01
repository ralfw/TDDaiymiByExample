# ToDictionary
Write a function called _ToDictionary()_ converting a string to a dictionary (list of name-value-pairs). 

The format of the string is like this: "a=1;b=2;c=3". It consists of name-value-pairs separated by a semicolon [1].

The names can of course be longer than just one character. The values can of course be longer than just one character.

A semicolon cannot be part of a name nor of a value. An equal sign can be part only of the value.

If names occur several times in a string the last value "wins".

Whitespace is significant in values, but insignificant in names.

## Design
For C# a function signature like this fits the problem definition [2]:

	Dictionary<string,string> ToDictionary(string text)

Aspects of the solution seem to be

* splitting the text into name-value-pairs,
* splitting name-value-pairs into name and value, 
* and finally building a dictionary from names and values.

## Test Cases
Happy cases

* "a=1" = {{"a", "1"}}
* "a=1;b=2" = {{"a", "1"}, {"b", "2"}}
* "abc=1234" = {{"abc", "1234"}}

Unusual cases

* "a=" = {{"a", ""}} // empty value
* " a =1" = {{"a", "1"}} // whitespace in name
* "a= 1 " = {{"a", " 1 "}} // whitespace in value
* "a==" = {{"a", "="}} // "=" in value
* "a;b=2" = {{"a", ""}, {"b", "2"}} // no value provided
* "a=1;2" = {{"a", "1"}, {"2", ""}} // semicolon seemingly in value
* "a=1;a=2" = {{"a", "2"}} // multiple values for same name
* "" = {}

Exceptional cases

* null = Exception!
* "=1" = Exception! // no name given

## Footnotes
[1] If you like, think of the string as some configuration information.

[2] In C# the function could be implemented as an extension method to be used like this: _"a=1;b=2".ToDictionary()_

## Resources