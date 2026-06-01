using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Controller
{
    internal class TiposArtigosController
    {
        public static List<string> GetTiposArtigos()
        {
            using (Model.IShoppingContext db = new Model.IShoppingContext())
            {
                return db.TipoArtigos.Select(t => t.Nome).ToList();
            }
        }
    }
}
