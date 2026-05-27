using Ishopping.Model;
using Ishopping.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ishopping
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Database.SetInitializer(new AppDbInitializer());
            using (IShoppingContext db = new IShoppingContext())
            {
                db.Database.Initialize(false);
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormPrincipal());
            }
        }
    }
}
