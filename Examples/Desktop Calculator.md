# Desktop Calculator
Implement a simple desktop calculator with the following user interface:

![](images/desktop_calculator_ui_sketch.jpg)

It´s somewhat similar to the Windows desktop calculator in that it does not know operator precedences. But the number can be entered in its own text box. (No digit buttons in on the dialog.)

Once an operator is pressed the next result is calculated. Here´s an example of a multi step calculation and its results:

1. 2, + -> 2
1. 3, * -> 5
1. 4, = -> 20

The next result is calculated with the current number displayed and an operator -> and results in a new number to be displayed.

For each operator a button has to be provided. Their functionality should not require further explanations ;-)

Division by 0 causes a message to be displayed - either as a message box or in some status bar.

When the program starts and after each operator the cursor is in the result textbox with all its content selected. That way entering the next number is easy.

Also the operators should be accessible through their respective keys; no need to click the buttons.

Initially the result textbox is set to 0.

## Design
Clearly there are two concerns on the table:

* user interface
* calculation domain

Each should be represented by its own functional units (i.e. class).

There seem to be two ways of connecting them: by making one depending on the other, e.g. the UI uses a domain object as a service, or by keeping them independent.



## Test Cases

#### Acceptance tests

* (2, +) = 2
* (3, *) = 5
* (4, =) = 20
* (20, +) = 20
* (7, =) = 27

* (8, /) = 8
* (0, =) = Error message
* (2, =) = 4
