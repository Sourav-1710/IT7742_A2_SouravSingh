using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new CustomerForm());
        }
    }
}
