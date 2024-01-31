using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.WindowsCalculator
{
    /// <summary>
    /// Класс калькулятор использующий алгоритм обратной польской нотации. 
    /// </summary>
    internal class Calculator
    {
        /// <summary>
        /// Возвращает результат математического выражения.
        /// </summary>
        /// <param name="input">Математическое выражение.</param>
        /// <returns>Вовзвращает результат выражения.</returns>
        public double Calculate(string input)
        {
            string convertInput = ConvertToRPN(input);

            double result = CalculateRPN(convertInput);

            return result;
        }

        /// <summary>
        /// Конвертирует математическое выражение в обратную польскую нотацию.
        /// </summary>
        /// <param name="input">Математическое выражение.</param>
        /// <returns>Математическое выражение в обратной польской нотации.</returns>
        private string ConvertToRPN(string input)
        {
            var operators = new Dictionary<char, int>
            {
                { '+', 1 },
                { '-', 1 },
                { '*', 2 },
                { '/', 2 }
            };

            var stack = new Stack<char>();
            var output = new List<string>();

            for (int i = 0; i < input.Length; ++i)
            {
                char token = input[i];

                if (char.IsDigit(token))
                {
                    string number = token.ToString();

                    while (i + 1 < input.Length && (char.IsDigit(input[i + 1]) || input[i + 1] == '.'))
                    {
                        number += input[++i];
                    }

                    output.Add(number);
                }

                else if (operators.ContainsKey(token))
                {
                    while (stack.Count != 0 && operators[token] <= operators[stack.Peek()])
                    {
                        output.Add(stack.Pop().ToString());
                    }
                    stack.Push(token);
                }
            }

            while (stack.Count != 0)
            {
                output.Add(stack.Pop().ToString());
            }

            return string.Join(" ", output);
        }

        /// <summary>
        /// Возвращает результат математического выражения, записанного в обратной польской нотации.
        /// </summary>
        /// <param name="rpn">Математическое выражение в формате обратной польской нотации.</param>
        /// <returns>Вовзвращает результат выражения.</returns>
        /// <exception cref="DivideByZeroException">Генерируется если в выражении происходит деление на ноль.</exception>
        /// <exception cref="ArgumentException">Генерируется при недопустимом выражении.</exception>
        private double CalculateRPN(string rpn)
        {
            var stack = new Stack<double>();

            string[] tokens = rpn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.Count < 2) 
                    {
                        throw new ArgumentException();
                    }

                    double numberTwo = stack.Pop();
                    double numberOne = stack.Pop();
                    double result;

                    switch (token)
                    {
                        case "+": result = numberOne + numberTwo; break;
                        case "-": result = numberOne - numberTwo; break;
                        case "*": result = numberOne * numberTwo; break;
                        case "/":
                            if (numberTwo == 0)
                                throw new DivideByZeroException();
                            result = numberOne / numberTwo;
                            break;
                        default: throw new ArgumentException();

                    }
                    stack.Push(result);
                }
            }

            if (stack.Count == 1)
                return stack.Pop();
            else
                throw new ArgumentException();
        }
    }
}
