using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUKEP.Student.WindowsCalculator
{
    /// <summary>
    /// Проверяет правильность ввода математического выражения.
    /// </summary>
    internal class InputHandler
    {
        /// <summary>
        /// Обрабатывает вводимый символ и определяет, возможно ли его добавить к математическому выражению.
        /// </summary>
        /// <param name="currentText">Текущее математическое выражение.</param>
        /// <param name="newChar">Вводимый символ.</param>
        /// <returns>Возвращает обновленное математическое выражение если символ можно добавить, если добавление невозможно возвращает текущее выражение без изменений.</returns>
        public string GetUpdatedInput(string currentText, char newChar)
        {
            if (currentText.Length == 0 && (newChar == '.' || newChar == '+' || newChar == '-' || newChar == '*' || newChar == '/'))
            {
                return currentText; 
            }

            if (newChar == '.')
            {
                int lastOperatorIndex = currentText.LastIndexOfAny(new char[] { '+', '-', '*', '/' });
                if (lastOperatorIndex == currentText.Length - 1) 
                {
                    return currentText;
                }
                if (currentText.IndexOf('.', lastOperatorIndex + 1) > -1) 
                {
                    return currentText;
                }
            }


            if (newChar == '0' && currentText.EndsWith("0") && currentText.Length > 0)
            {
                int lastOperatorIndex = currentText.LastIndexOfAny(new char[] { '+', '-', '*', '/' });
                lastOperatorIndex = lastOperatorIndex == -1 ? 0 : lastOperatorIndex + 1;
                string currentNumber = currentText.Substring(lastOperatorIndex);

                if (currentNumber.StartsWith("0") && !currentNumber.Contains("."))
                {
                    return currentText;
                }
            }

            if (newChar >= '1' && newChar <= '9')
            {
                int lastNonNumeric = currentText.LastIndexOfAny(new char[] { '+', '-', '*', '/' });
                string currentNumber = currentText.Substring(lastNonNumeric + 1);

                if (currentNumber == "0")
                {
                    currentText = currentText.Remove(lastNonNumeric + 1, 1);
                }
            }

            if (currentText.Length > 0 && "+-*/".Contains(newChar) && "+-*/".Contains(currentText.Last()))
            {
                currentText = currentText.Remove(currentText.Length - 1);
            }

            return currentText + newChar;
        }
    }

}