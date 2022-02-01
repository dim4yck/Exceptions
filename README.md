# Exceptions

Calculator with handling of exceptional situations

Goal:
Consolidate the knowledge about the mechanism of working with exceptions obtained during the webinar. Students will learn how to write code
that handles exceptions and get acquainted with various examples of built-in exceptions.

The main task
You need to write a calculator program that processes a simple expression and outputs its result on the next line.
At the same time, it must correctly work out various exceptional situations and errors.

The program itself for data entry should be contained in the Calculate() function, that is, the program will have the form

static void Main()
{
Calculate();
}

static void Calculate()
{
// program code
}

The expression can be addition, subtraction, multiplication, division of two integers (type int).
The format of the expression NUMBER-OPERAND OPERATOR NUMBER-OPERAND
There must be a space between the operator and the numbers in the expression.
After entering the expression and pressing ENTER, the answer is displayed on the next line in the format

answer: the result of the expression

Examples of expressions and response output.

100 + 200
answer: 300

400 - 50
answer: 350

8 * 7
answer: 56

9 / 3
answer: 3

Entering expressions is allowed until the user enters the word "stop"

When converting strings to numbers, do not use the TryParse() function, only Parse()

The program should have the following functions

Number addition function: takes two numbers as input and outputs the result of addition

void Sum(int a, int b);
Number subtraction function: takes two numbers as input and outputs the result of subtraction

void Sub(int a, int b);
Number multiplication function: takes two numbers as input and outputs the result of multiplication

void Mul(int a, int b);
Number division function: takes two numbers as input and outputs the result of division

void Div(int a, int b);
These functions should not output any text other than the Answer:

The Sum, Sub, Mul and Div functions inside can cause exceptions, but they must be handled at the level of the Calculate function.

Features of the program:
-Each type of exception is handled by a separate catch
-Thrown exceptions should not contain messages that we output to the console, which we determine by the type of exceptions

EXCEPTIONS THAT MAY OCCUR IN THE INPUT EXPRESSION HANDLER

Case 1
If the expression does not have an operator
, throw an exception and display the message in white on a red background:
Specify the operator in the expression: +, -, *, /

For example
10 4
Specify the operator in the expression: +, -, *, /

Case 2
If the operator does not match +, -, * or /, throw an exception and display the message message in white on a green background:
I don't know how to work with the operator operator yet

For example
10 % 4
I don't know how to work with an operator yet %

Case 3
If the expression does not follow the pattern (there is no operator or there is more than one, there are no spaces between the numbers and the operator),
throw an exception and display the message in white on a red background:

The expression is incorrect, try to write in the format
a + b
a * b
a - b
a / b

Case 4
If some operand is not a number, throw an exception and output the message in white on a red background:
Operand "operand" is not a number

For example
13c4 + 5
The operand 13c4 is not a number

Case 5
If some operand does not fit into the int type, throw an exception and output the message in black on yellow
Number "number" does not fit into an integer type

For example
13000000000000000000004 + 5
The number 13000000000000000000004 does not fit into an integer type

EXCEPTIONS THAT MAY OCCUR INSIDE THE Sum, Sub, Mul, Div FUNCTIONS

Case 6
When dividing by 0, throw an exception and display the message white text on a purple background:
Division by zero

Case 7
If the answer is 13 when calculating the expression, output the answer as usual, but after that throw an exception and output white text on a green background:
you have received the answer 13!

Case 8
In all other errors - print the text:
I couldn't handle the error

And terminate the program

Additional task 1
When writing your exceptions For cases 1-5, try passing an argument for text output both in a separate field of your own exception
and in the Data field (different method for different exceptions)

Additional task 2
In case of exceptions from Case 8, forward it further and process it in main, outputting the text:
An error has occurred in the calculator: error text

Additional task 3
If the result of the expression in the whole type does not fit into the int type (for example 2 000 000 000 * 10), 
throw an exception and display the message in white on a blue background:
The result of the expression went beyond int
