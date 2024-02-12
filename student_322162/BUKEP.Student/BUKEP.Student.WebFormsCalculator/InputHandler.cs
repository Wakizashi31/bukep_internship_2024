using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsCalculator
{
    /// <summary>
    /// Проверяет правильность ввода математического выражения.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        /// Обрабатывает вводимый символ и определяет, возможно ли его добавить к математическому выражению.
        /// </summary>
        /// <param name="currentText">Текущее математическое выражение.</param>
        /// <param name="newChar">Вводимый символ.</param>
        /// <returns>Возвращает обновленное математическое выражение если символ можно добавить, если добавление невозможно возвращает текущее выражение без изменений.</returns>
        public string GetUpdatedInput(string currentText, char newChar)
        {
            if (currentText.Length == 0 && (newChar == ',' || newChar == '+' || newChar == '-' || newChar == 'x' || newChar == '÷' || newChar == '^'))
            {
                return currentText;
            }

            if (newChar == ',')
            {
                int lastOperatorIndex = currentText.LastIndexOfAny(new char[] { '+', '-', 'x', '÷' });
                if (lastOperatorIndex == currentText.Length - 1)
                {
                    return currentText;
                }
                if (currentText.IndexOf(',', lastOperatorIndex + 1) > -1)
                {
                    return currentText;
                }
            }


            if (newChar == '0' && currentText.EndsWith("0") && currentText.Length > 0)
            {
                int lastOperatorIndex = currentText.LastIndexOfAny(new char[] { '+', '-', 'x', '÷', '(', ')' });
                lastOperatorIndex = lastOperatorIndex == -1 ? 0 : lastOperatorIndex + 1;
                string currentNumber = currentText.Substring(lastOperatorIndex);

                if (currentNumber.StartsWith("0") && !currentNumber.Contains(","))
                {
                    return currentText;
                }
            }

            if (newChar >= '1' && newChar <= '9' || newChar == '(')
            {
                int lastNonNumeric = currentText.LastIndexOfAny(new char[] { '+', '-', 'x', '÷' });
                string currentNumber = currentText.Substring(lastNonNumeric + 1);

                if (currentNumber == "0")
                {
                    currentText = currentText.Remove(lastNonNumeric + 1, 1);
                }
            }

            if (currentText.Length > 0 && "+-x÷^".Contains(newChar) && "+-x÷^".Contains(currentText.Last()))
            {
                currentText = currentText.Remove(currentText.Length - 1);
            }

            return currentText + newChar;
        }

        /// <summary>
        /// Проверяет есть ли в выражении символ равенства.
        /// </summary>
        /// <param name="currentText">Текущее математическое выражение.</param>
        /// <returns>Возвращает true в выражении есть символ равенства.</returns>
        public bool AvailabilityResult(string currentText)
        {
            bool symbolEqual = currentText.Contains('=');

            return symbolEqual;
        }

        /// <summary>
        /// Заменяет символы в выражении, если они не соотвествуют формату и не могут быть преобразованы в мат.выражения.
        /// </summary>
        /// <param name="input">Текущее математическое выражение.</param>
        /// <returns>Возвращает выражение с изменёнными символами.</returns>
        public string MathExpressionFormat(string input)
        {
            input = input.Replace('÷', '/');
            input = input.Replace(',', '.');
            input = input.Replace('x', '*');

            return input;
        }
    }
}
