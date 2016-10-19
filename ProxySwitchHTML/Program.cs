using proxyswich;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxySwitchHTML
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginFrm = new LoginForm();
            loginFrm.ShowDialog();
            if (AccountModel.accountModel != null)
            {
                Application.Run(new Main());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
