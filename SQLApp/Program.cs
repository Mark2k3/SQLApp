using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLApp
{
    internal static class Program
    {
        /// <summary>
        /// move first Registration mouse position 
        /// Make different languages
        /// Make a difference between small/capital letters in login
        /// add a config for DB con
        /// </summary>
                [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

        }
    }
}
