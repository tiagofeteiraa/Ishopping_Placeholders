using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Model
{
    internal class ItemPrevisto : ItemCompra
    {
        public int quantidadePrevista { get; set; }
    }
}
