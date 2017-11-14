using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPATechChallenge
{
    public partial class Form1 : Form
    {
        Thread thread;

        string operand1 = string.Empty;
        string operand2 = string.Empty;
        double result;

        static void ShowMessageBox()
        {
            MessageBox.Show("Cannot divide by 0", "Alert");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MathResult_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            string operand1 = this.userInt1.Text;
            string operand2 = this.userInt2.Text;
            double opr1;
            double opr2;
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
                            //show alert message
                            thread = new Thread(ShowMessageBox);
                            thread.Start();
                        }
                        break;
                }
            }
            
            userResult.Text = result.ToString("G17");
        }
    }
}
