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
        /// 
        /// fix names
        /// И правильнее было бы выводить как результат работы
        /// не просто yes no, а логин и пароль данного пользователя. И, соответственно, в команде
        /// к базе данных нет никакого смысла делать выборку всех пользователей, а необходимо лишь одного.
        /// 
        /// Make different langueges
        /// Make a difference between small/capital letters in pass/login
        /// Interdict repetition of pass/login
        /// Add hashes
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
