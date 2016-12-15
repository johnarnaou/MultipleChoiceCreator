using Multiple_Choice_Creator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //User temp = new User("johnarnaou@gmail.com", "123");
            //temp.setUserID(5);
            Login form = new Login();
            form.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(form);
        }
    }
}
