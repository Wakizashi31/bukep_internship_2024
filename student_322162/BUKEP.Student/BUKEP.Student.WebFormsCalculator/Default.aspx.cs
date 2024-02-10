using BUKEP.Student.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        public MathCalculator calculator = new MathCalculator();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonInput_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TextBox1.Text += button.Text;
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "0";
        }

        protected void ButtonDeleteChar_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1);
            }
        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            TextBox1.Text += " = " + calculator.Calculate(TextBox1.Text);
        }
    }
}