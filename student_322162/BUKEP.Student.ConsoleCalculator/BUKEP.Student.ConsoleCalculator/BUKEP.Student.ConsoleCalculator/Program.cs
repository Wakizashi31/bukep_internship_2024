using System.Globalization;

namespace BUKEP.Student.ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleCalculator();
        }
        static void ConsoleCalculator()
        {
            while (true)
            {
                Console.WriteLine("Введите математическое выражение.\nПо завершению ввода операции нажмите Enter:");
                string input = Console.ReadLine();

                try
                {
                    string outputExpression = ConvertToRPN(input);
                    Console.WriteLine($"Обратная польская запись: {outputExpression}");

                    double result = CalculateRPN(outputExpression);
                    Console.WriteLine($"Результат: {result}");
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine($"Ошибка: Деление на ноль.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка: Недопустимое выражение");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
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
        /// Конвертирует математическое выражение в обратную польскую нотацию.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static string ConvertToRPN(string input)
        {
            var operators = new Dictionary<char, int>
        {
            { '(', 0 },
            { ')', 0 },
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 },
            { '^', 3 }
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
                else if (token == '(')
                {
                    stack.Push(token);
                }
                else if (token == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        output.Add(stack.Pop().ToString());
                    }
                    stack.Pop();
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
        /// <param name="rpn"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>
        /// <exception cref="ArgumentException"></exception>
        static double CalculateRPN(string rpn)
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
                        case "^": result = Math.Pow(numberOne, numberTwo); break;
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
