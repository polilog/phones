using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;

namespace WindowsFormsPhones
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

            MainMenu mainMenu = new MainMenu();
            Unit company = new Unit("My company", 0);
            MainMenuController controller = new MainMenuController(mainMenu, company);

            Application.Run(mainMenu);
        }
    }
}
