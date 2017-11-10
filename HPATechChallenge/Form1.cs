using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPATechChallenge
{
    public partial class Form1 : Form
    {
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        double result;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void mathResult_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            string operand1 = this.userInt1.Text;
            string operand2 = this.userInt2.Text;
            double opr1, opr2;
            double.TryParse(operand1, out opr1);
            double.TryParse(operand2, out opr2);

            if (mathOperations.SelectedItem == null)
            {
                MessageBox.Show("Please select an operator");
            }
            else
            {
                string selection = mathOperations.SelectedItem.ToString();
                char operation = selection[0];

                switch (operation)
                {
                    case '+':
                        result = (opr1 + opr2);
                        break;

                    case '-':
                        result = (opr1 - opr2);
                        break;

                    case '*':
                        result = (opr1 * opr2);
                        break;

                    case '/':
                        if (opr2 != 0)
                        {
                            result = (opr1 / opr2);
                        }
                        else
                        {
                            MessageBox.Show("Can't divide by zero");
                        }
                        break;
                }
            }
            
            userResult.Text = result.ToString("G17");
        }
    }
}
