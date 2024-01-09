namespace BUKEP.Student.ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\r\nВведите простое математическое выражение для вычисления операции (+ или - или * или /) над двумя числами. " +
                    "\nПо завершению ввода операции нажмите Enter:");
                string text = Console.ReadLine();

                string[] words = text.Split(new char[] { '+', '-', '/', '*' });
                try
                {
                    int numberOne = int.Parse(words[0]);
                    int numbersTwo = int.Parse(words[1]);
                    foreach (char s in text)
                    {
                        switch (s)
                        {
                            case '+':
                                Console.WriteLine($"{numberOne} + {numbersTwo} = {numberOne + numbersTwo}");
                                break;
                            case '-':
                                Console.WriteLine($"{numberOne} - {numbersTwo} = {numberOne - numbersTwo}");
                                break;
                            case '/':
                                if (numberOne == 0 || numbersTwo == 0)
                                    Console.WriteLine("На 0 делить нельзя");
                                else
                                    Console.WriteLine($"{numberOne} / {numbersTwo} = {(float)(numberOne / (float)numbersTwo)}");
                                break;
                            case '*':
                                Console.WriteLine($"{numberOne} * {numbersTwo} = {numberOne * numbersTwo}");
                                break;

                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Неверный ввод!");
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
    }
}
