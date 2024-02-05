using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using BUKEP.Student.Calculator;


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
                    MathCalculator calculator = new MathCalculator();
                    double result = calculator.ResultCalculate(input);
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
    }
}