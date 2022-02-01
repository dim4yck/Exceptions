using System;

namespace Exceptions
{
    class Program
    {
        class IncorrectExpressionException : Exception
        {
            public IncorrectExpressionException() : base("Выражение некорректное, попробуйте написать в формате\n a + b\n a * b\n a - b\n a / b") { }
        }
        class NoOperatorException : Exception
        {
            public NoOperatorException() : base("Укажите в выражении оператор: +, -, *, /") { }
        }
        class Answer13Exception : Exception
        {
            public Answer13Exception() : base("вы получили ответ 13!") { }
        }
        class NotSupporedOperatorException : Exception
        {
            public string Data;
            public NotSupporedOperatorException(string arg) : base("Я пока не умею работать с оператором")
            {
                Data = arg;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Calculate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"В калькуляторе произошла ошибка: {e.Message}");
            }
        }
        static void Calculate()
        {
            string expression;
            string[] subExp;
            int number1;
            int number2;
            char sing;

            // Expression Handler
            do
            {
                expression = Console.ReadLine();
                subExp = expression.Split(' ');

                // Checking the first operand for errors
                try
                {
                    if (subExp.Length == 1)
                        throw new IncorrectExpressionException();
                    number1 = int.Parse(subExp[0]);
                }
                catch (IncorrectExpressionException e)
                {
                    WriteTextWithColor($"{e.Message}", ConsoleColor.White, ConsoleColor.Red);
                    continue;
                }
                catch (FormatException)
                {
                    WriteTextWithColor($"Операнд {subExp[0]} не является числом", ConsoleColor.White, ConsoleColor.Red);
                    continue;
                }
                catch (OverflowException)
                {
                    WriteTextWithColor($"Число {subExp[0]} не помещается в целый тип", ConsoleColor.Black, ConsoleColor.Yellow);
                    continue;
                }
                catch (Exception)
                {
                    throw new Exception("Я не смог обработать ошибку");
                }

                // Checking the operator for errors
                try
                {
                    if (subExp.Length == 2 & subExp[1] != "+" && subExp[1] != "-" && subExp[1] != "*" && subExp[1] != "/" && subExp[1].Length == 1)
                    {
                        throw new NoOperatorException();
                    }
                    if (subExp[1].Length > 1)
                        throw new IncorrectExpressionException();
                    sing = char.Parse(subExp[1]);
                }
                catch (NoOperatorException e)
                {
                    WriteTextWithColor($"{e.Message}", ConsoleColor.White, ConsoleColor.Red);
                    continue;
                }
                catch (IncorrectExpressionException e)
                {
                    WriteTextWithColor($"{e.Message}", ConsoleColor.White, ConsoleColor.Red);
                    continue;
                }
                catch (Exception)
                {
                    throw new Exception("Я не смог обработать ошибку");
                }

                // Checking the second operand for errors
                try
                {
                    if (subExp.Length != 3)
                        throw new IncorrectExpressionException();
                    number2 = int.Parse(subExp[2]);
                }
                catch (IncorrectExpressionException e)
                {
                    WriteTextWithColor($"{e.Message}", ConsoleColor.White, ConsoleColor.Red);
                    continue;
                }
                catch (FormatException)
                {
                    WriteTextWithColor($"Операнд {subExp[2]} не является числом", ConsoleColor.White, ConsoleColor.Red);
                    continue;
                }
                catch (OverflowException)
                {
                    WriteTextWithColor($"Число {subExp[2]} не помещается в целый тип", ConsoleColor.Black, ConsoleColor.Yellow);
                    continue;
                }
                catch (Exception)
                {
                    throw new Exception("Я не смог обработать ошибку");
                }

                // Choosing an arithmetic operation and checking it for errors  
                try
                {
                    switch (sing)
                    {
                        case '+':
                            Sum(number1, number2);
                            break;
                        case '-':
                            Sub(number1, number2);
                            break;
                        case '*':
                            Mul(number1, number2);
                            break;
                        case '/':
                            Div(number1, number2);
                            break;
                        default:
                            throw new NotSupporedOperatorException(subExp[1]);
                    }
                }
                catch (NotSupporedOperatorException e)
                {
                    WriteTextWithColor($"{e.Message} {e.Data}", ConsoleColor.White, ConsoleColor.Green);
                    continue;
                }
                catch (DivideByZeroException)
                {
                    WriteTextWithColor($"Деление на ноль", ConsoleColor.White, ConsoleColor.DarkMagenta);
                    continue;
                }
                catch (Answer13Exception e)
                {
                    WriteTextWithColor($"{e.Message}", ConsoleColor.White, ConsoleColor.Green);
                    continue;
                }
                catch (OverflowException)
                {
                    WriteTextWithColor($"Результат выражения вышел за грани int", ConsoleColor.White, ConsoleColor.Blue);
                    continue;
                }
            } while (Console.ReadLine() != "стоп");


            void Sum(int a, int b)
            {
                if (a + b == 13)
                {
                    Console.WriteLine($"Ответ: {a + b}");
                    throw new Answer13Exception();
                }
                try
                {
                    Console.WriteLine($"Ответ: {a + b}");
                }
                catch (OverflowException)
                {
                    throw new OverflowException();
                }
            }

            void Sub(int a, int b)
            {
                if (a - b == 13)
                {
                    Console.WriteLine($"Ответ: {a - b}");
                    throw new Answer13Exception();
                }
                try
                {
                    Console.WriteLine($"Ответ: {a - b}");
                }
                catch (OverflowException)
                {
                    throw new OverflowException();
                }
            }

            void Mul(int a, int b)
            {
                try
                {
                    Console.WriteLine($"Ответ: {a * b}");
                }
                catch (OverflowException)
                {
                    throw new OverflowException();
                }
            }

            void Div(int a, int b)
            {
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                if (a / b == 13)
                {
                    Console.WriteLine($"Ответ: {a / b}");
                    throw new Answer13Exception();
                }
                else
                    Console.WriteLine($"Ответ: {a / b}");
            }
        }

        private static void WriteTextWithColor(string message, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            Console.WriteLine(message);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nНажмите клавишу \"Ввод\" для продолжения набора выражения, либо введите с клавиатуры \"стоп\" для выхода из программы");
        }
    }
}