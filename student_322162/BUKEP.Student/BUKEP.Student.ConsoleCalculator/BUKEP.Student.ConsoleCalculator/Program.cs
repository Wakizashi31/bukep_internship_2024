using System.Globalization;
using BUKEP.Student.Calculator;

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
                    MathCalculator calculator = new MathCalculator();

                    double result = calculator.Calculate(input);
                    Console.WriteLine($"Результат выражения: {result}");
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
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
