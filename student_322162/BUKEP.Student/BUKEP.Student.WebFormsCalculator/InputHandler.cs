using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUKEP.Student.WebFormsCalculator
{
    public class InputHandler
    {
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
                int lastOperatorIndex = currentText.LastIndexOfAny(new char[] { '+', '-', 'x', '÷'});
                lastOperatorIndex = lastOperatorIndex == -1 ? 0 : lastOperatorIndex + 1;
                string currentNumber = currentText.Substring(lastOperatorIndex);

                if (currentNumber.StartsWith("0") && !currentNumber.Contains(","))
                {
                    return currentText;
                }
            }

            if (newChar >= '1' && newChar <= '9' || newChar == '(')
            {
                int lastNonNumeric = currentText.LastIndexOfAny(new char[] { '+', '-', 'x', '÷'});
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


    }
}
