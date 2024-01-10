using System.Collections.Concurrent;
using System.Linq;

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
                Console.WriteLine("Введите простое математическое выражение для вычисления операции (+ или - или * или /) над двумя числами.\nПо завершению ввода операции нажмите Enter:");
                string input = Console.ReadLine();

                char[] mathSymbols= new char[] { '+', '-', '/', '*' };
                string[] numbers = input.Split(mathSymbols);

                if (numbers.Length >= 3 )
                {
                    Console.WriteLine("Выражение введено некорректно!\nПовторите ввод!");
                    continue;
                }

                try
                {
                    int numberOne = int.Parse(numbers[0]);
                    int numberTwo = int.Parse(numbers[1]);

                    Calc(input, numberOne, numberTwo,mathSymbols);
                }
                catch
                {
                    Console.WriteLine("Введено некорректное выражение!");
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
                }
            }
        }


        static void Calc(string input, int numberOne, int numberTwo, char[] mathSymbols)
        {
            char symbol = mathSymbols.First(s => input.Any(os => os == s));
            switch (symbol)
            {
                case '+':
                    Console.WriteLine($"{numberOne} + {numberTwo} = {numberOne + numberTwo}");
                    break;
                case '-':
                    Console.WriteLine($"{numberOne} - {numberTwo} = {numberOne - numberTwo}");
                    break;
                case '*':
                    Console.WriteLine($"{numberOne} * {numberTwo} = {numberOne * numberTwo}");
                    break;
                case '/':
                    if (numberTwo == 0)
                    {
                        Console.WriteLine("На ноль делить нельзя!");
                    }
                    else
                    {
                        Console.WriteLine($"{numberOne} / {numberTwo} = {(float)(numberOne / (float)numberTwo)}");
                    }
                    break;
            }
        }
    }
}
