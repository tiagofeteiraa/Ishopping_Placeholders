using Ishopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Model
{
    internal class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? Preco { get; set; }

        // FK
        public int IdTipoArtigo { get; set; }

        
        public virtual ICollection<ItemCompra> ItensCompra { get; set; }
    }
}
