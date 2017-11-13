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
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto)]
        static extern IntPtr GetWindowCaption(IntPtr hwnd, StringBuilder lpString, int maxCount);

        static string GetWindowCaption(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder(256);
            GetWindowCaption(hwnd, sb, 256);
            return sb.ToString();
        }

        uint CB_SETCURSEL = 0x014E;
        uint BM_CLICK = 0x00F5;
        const UInt32 WM_CLOSE = 0x0010;

        Thread thread;

        string operand1 = string.Empty;
        string operand2 = string.Empty;
        double result;

        static void ShowMessageBox()
        {
            MessageBox.Show("Cannot divide by 0", "Alert");
        }

        void CloseMessageBox()
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "Caption");
            if (hWnd != IntPtr.Zero)
                PostMessage(hWnd, WM_CLOSE, 0, null);

            if (thread.IsAlive)
                thread.Abort();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userInt1.Location = new Point(12, 44);
            userInt1.TabIndex = 0;
            userInt1.Text = "6";
            userInt2.Location = new Point(172, 44);
            userInt2.TabIndex = 1;
            userInt2.Text = "0";

            // Get the handle of the window
            var windowHandle = FindWindow((string)null, "Calculator");

            // Get combo box handle
            var comboBoxHandle = FindWindowEx(windowHandle, IntPtr.Zero, "WindowsForms10.COMBOBOX.app.0.141b42a_r13_ad1", "");
            // Click combo box
            PostMessage(comboBoxHandle, CB_SETCURSEL, 3, null);

            // Get = button handle
            var buttonHandle = FindWindowEx(windowHandle, IntPtr.Zero, (string)null, "=");
            // Click the = button
            PostMessage(buttonHandle, BM_CLICK, 0, null);
        }

        private void SecondStep()
        {
            userInt2.Text = "3";

            // Get the handle of the window
            var windowHandle = FindWindow((string)null, "Calculator");

            // Get = button handle
            var buttonHandle = FindWindowEx(windowHandle, IntPtr.Zero, (string)null, "=");
            // Send click to the button
            PostMessage(buttonHandle, BM_CLICK, 0, null);

            var result2 = FindWindowEx(windowHandle, IntPtr.Zero, "WindowsForms10.STATIC.app.0.141b42a_r13_ad1", "");
        }

        private void LastStep(string passedResult)
        {
            var lastResult = passedResult;

            // Get the handle of the window
            var windowHandle = FindWindow((string)null, "Calculator");

            PostMessage(windowHandle, WM_CLOSE, 0, null);

            Console.WriteLine("Last result = " + lastResult);
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
                            LastStep(result.ToString());
                        }
                        else
                        {
                            //show alert message
                            thread = new Thread(ShowMessageBox);
                            thread.Start();
                            
                            CloseMessageBox();

                            SecondStep();
                        }
                        break;
                }
            }
            
            userResult.Text = result.ToString("G17");
        }
    }
}
