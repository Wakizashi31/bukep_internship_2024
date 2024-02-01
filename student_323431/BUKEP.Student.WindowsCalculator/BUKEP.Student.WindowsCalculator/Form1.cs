using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKEP.Student.WindowsCalculator
{
    public partial class Form1 : Form
    {
        private bool Flag = true;
        private string TempParametr;
        private string Act;
        Calculate calculate = new Calculate();

        public Form1()
        {
            InitializeComponent();
        }      


        private void AddNumber_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            
            
            if (Flag)
            {
                Flag = false;
                display.Text = numButton.Text;                              
            }               
            else
            {
                if(numButton.Text == "0" && display.Text == "0")
                {
                    display.Text = numButton.Text;
                }
                else
                {
                    display.Text += numButton.Text;
                }
                
            }
        }

        private void buttonClear(object sender, EventArgs e)
        {
            Flag = true;
            Act = string.Empty;
            TempParametr = string.Empty;
            display.Text = "0";
        }
        
        private void buttonDisplay(object sender, EventArgs e)
        {
            Button buttonAct = (Button)sender;
            Act = buttonAct.Text;
            TempParametr = display.Text;
            Flag = true;
        }

        private void ButtonResult(object sender, EventArgs e)
        {
            try
            {
                string mathExpression = TempParametr.ToString() + Act.ToString() + display.Text;

                display.Text = Convert.ToString(calculate.ResultCalculate(mathExpression));
                
            }
            catch(NullReferenceException ex)
            {
                display.Text = "Некорректно";
            }
            catch (DivideByZeroException)
            {
                display.Text = "деление на 0!";
            }
            catch(Exception)
            {
                display.Text = "Ошибка!";
            }

            Flag = true;
            Act = string.Empty;
            TempParametr = string.Empty;
        }

        private void buttonDeleteSymbol(object sender, EventArgs e)
        {
            if (display.Text.Length > 1)
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 1);
            }
            else
            {
                display.Text = "0";
                Flag = true;
            }
        }

    }
}
