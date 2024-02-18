using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BUKEP.Student.Calculator
{
    /// <summary>
    /// Класс калькулятор работающий при помощи RPN
    /// </summary>
    public class MathCalculator
    {
        /// <summary>
        /// принимает математическое выражение в виде строки, конвертирует его в обратную польску нотации
        /// </summary>
        /// <param name="input">Математическое выражение</param>
        /// <returns>возвращает полученный результат в виде числа с плавающей запятой</returns>
        public double ResultCalculate(string input)
        {
            string ConvertInput = ConvertToRPN(input);

            double result = CalculateRPN(ConvertInput);

            return result;
        }

        /// <summary>
        /// Конвертирует математическое выражение в обратную польскую нотацию
        /// </summary>
        /// <param name="input">Математическое выражение</param>
        /// <returns>Математическое выражение в обратной польской записи</returns>
        private string ConvertToRPN(string input)
        {
            var operators = new Dictionary<char, int>
            {
                ['('] = 0,
                [')'] = 1,
                ['+'] = 2,
                ['-'] = 2,
                ['*'] = 3,
                ['/'] = 3,
                ['^'] = 4
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

        /// <summary>
        /// Возращает результат математического выражения, записанного в обратной польской нотации
        /// </summary>
        /// <param name="rpn">Математическое выражение в формате обратной польской записи</param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException">Деление на ноль</exception>
        /// <exception cref="InvalidOperationException">Некорректная запись</exception>
        private double CalculateRPN(string rpn)
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
                        case "^": stack.Push(Math.Pow(left, right)); break;
                        case "/":
                            if (right == 0)
                            {
                                throw new DivideByZeroException("ошибка");
                            }
                            stack.Push(left / right);
                            break;
                        default: throw new InvalidOperationException("Неизвестная операция");
                    }
                }
            }
            return stack.Pop();
        }
    }
}
