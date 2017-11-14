using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        // An overload of the SendMessage function
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn,
            IntPtr lParam);

        static IEnumerable<IntPtr> EnumerateProcessWindowHandles(int processId)
        {
            var handles = new List<IntPtr>();

            foreach (ProcessThread thread in Process.GetProcessById(processId).Threads)
                EnumThreadWindows(thread.Id,
                    (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

            return handles;
        }

        static void Main(string[] args)
        {
            var proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "C:/Users/adamr_000/source/repos/HPATechChallenge/HPATechChallenge/bin/Debug/HPATechChallenge";
            proc.Start();

            uint CB_SETCURSEL = 0x014E;
            uint WM_SETTEXT = 0x000C;
            uint BM_CLICK = 0x00F5;
            uint WM_NCDESTROY = 0x0082;
            const UInt32 WM_CLOSE = 0x0010;
            int WM_GETTEXT = 0x000D;
            const int WM_GETTEXTLENGTH = 0x000E;

            foreach (var handle in EnumerateProcessWindowHandles(
                Process.GetProcessesByName("explorer").First().Id))
            {
                StringBuilder message = new StringBuilder(1000);
                Console.WriteLine(message);
            }

            // Get the handle of the window
            var windowHandle = FindWindow((string)null, "Calculator");

            //Get handle of textbox1
            var textbox1 = FindWindowEx(windowHandle, IntPtr.Zero, "WindowsForms10.EDIT.app.0.141b42a_r12_ad1", "");
            //Insert text
            SendMessage(textbox1, WM_SETTEXT, 0, "0");

            //Get handle of textbox2
            var textbox2 = FindWindowEx(windowHandle, textbox1, "WindowsForms10.EDIT.app.0.141b42a_r12_ad1", "");
            //Insert text
            SendMessage(textbox2, WM_SETTEXT, 0, "6");

            // Get combo box handle
            var comboBoxHandle = FindWindowEx(windowHandle, IntPtr.Zero, "WindowsForms10.COMBOBOX.app.0.141b42a_r12_ad1", "");
            // Click combo box
            PostMessage(comboBoxHandle, CB_SETCURSEL, 3, null);

            // Get = button handle
            var buttonHandle = FindWindowEx(windowHandle, IntPtr.Zero, (string)null, "=");
            // Click the = button
            PostMessage(buttonHandle, BM_CLICK, 0, null);

            Thread.Sleep(1000);
            //Find the alert box handle
            var alertHandle = FindWindowByCaption(IntPtr.Zero, "Alert");
            //Close the alert
            PostMessage(alertHandle, WM_CLOSE, 0, null);

            //Insert text
            SendMessage(textbox1, WM_SETTEXT, 0, "3");

            // Click the = button
            PostMessage(buttonHandle, BM_CLICK, 0, null);

            Thread.Sleep(1000);
            //Get result handle
            var resultHandle = FindWindowEx(windowHandle, IntPtr.Zero, "WindowsForms10.STATIC.app.0.141b42a_r12_ad1", "");
            StringBuilder sb = new StringBuilder(1000);
            var resultValue = SendMessage(resultHandle, WM_GETTEXT, sb.Capacity, sb);
            
        }
    }
}
