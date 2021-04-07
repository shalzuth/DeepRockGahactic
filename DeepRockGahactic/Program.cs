using System;
using System.Windows.Forms;

namespace DeepRockGahactic
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var drg = new DeepRockGahactic();
            drg.InitWindow();
            drg.Start();
        }
    }
}
