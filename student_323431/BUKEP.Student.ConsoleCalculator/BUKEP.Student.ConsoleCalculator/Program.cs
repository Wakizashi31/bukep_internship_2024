using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\r\nВведите простое математическое выражение для вычисления операции (+ или - или * или /)\nПо завершению ввода операции нажмите Enter:");
                string input = Console.ReadLine();
                try
                {
                    string RPN = ConvertToRPN(input);
                    double result = CalculateRPN(RPN);
                    Console.WriteLine("Result: " + result);

                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Деление на ноль");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Неизвестная операция");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ошибка: {ex}");
                }
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Для повторного ввода операции нажмите Enter, для завершения приложения Esc.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" - Введена неизвестная команда. Повторите ввод.");
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Метод возвращающий результат выражения из обратной польской записи
        /// </summary>
        /// <param name="rpn">Математическое выражение</param>
        /// <returns>Результат математичесокго выражения</returns>
        /// <exception cref="InvalidOperationException">Неизвестная операция</exception>
        /// <exception cref="DivideByZeroException">Деление на ноль</exception>
        static double CalculateRPN(string rpn)
        {
            var stack = new Stack<double>();

            var elements = rpn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in elements)
            {
                if (double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    double right = stack.Pop();
                    double left = stack.Pop();

                    switch (element)
                    {
                        case "+": stack.Push(left + right); break;
                        case "-": stack.Push(left - right); break;
                        case "*": stack.Push(left * right); break;
                        case "/":
                            if (right == 0)
                                throw new DivideByZeroException();
                            stack.Push(left / right);
                            break;
                        default: throw new InvalidOperationException("Неизвестная операция");
                    }
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// Метод преобразует математическое выражение в формат обратной польской записи 
        /// </summary>
        /// <param name="input">Математическое выражение</param>
        /// <returns>Математическое выражение в формате обратной польской записи</returns>
        static string ConvertToRPN(string input)
        {
            var operators = new Dictionary<char, int>
            {
                ['('] = 0,
                [')'] = 1,
                ['+'] = 2,
                ['-'] = 2,
                ['*'] = 3,
                ['/'] = 3
            };

            var output = new StringBuilder();
            var stack = new Stack<char>();

            foreach (char c in input)
            {
                if (Char.IsDigit(c) || c == '.')
                    output.Append(c);

                else if (operators.ContainsKey(c))
                {
                    output.Append(' ');

                    if (stack.Count == 0 || c == '(')
                        stack.Push(c);

                    else if (c == ')')
                    {
                        while (stack.Peek() != '(')
                        {
                            output.Append(stack.Pop() + " ");
                        }
                        stack.Pop();
                    }

                    else
                    {
                        while (stack.Count != 0 && operators[c] <= operators[stack.Peek()])
                            output.Append(stack.Pop() + " ");
                        stack.Push(c);
                    }
                }
            }

            while (stack.Count != 0)
                output.Append(" " + stack.Pop());

            return output.ToString();
        }
    }
}