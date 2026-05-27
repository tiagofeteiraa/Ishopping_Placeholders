using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ishopping.Model
{
    internal class AppDbInitializer : DropCreateDatabaseIfModelChanges<IShoppingContext>
    {
        protected override void Seed(IShoppingContext context)
        {
            context.Utilizadores.Add(new Utilizador
            {
                Username = "tiago",
                Password = "12345"
            });

            context.Utilizadores.Add(new Utilizador
            {
                Username = "henrique",
                Password = "12345"
            });

            context.Utilizadores.Add(new Utilizador
            {
                Username = "vasco",
                Password = "12345"
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
