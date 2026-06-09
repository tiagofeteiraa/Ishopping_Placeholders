using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Model
{
    internal class ItemCompra
    {   

        public int Id { get; set; }

        public int IdCompra { get; set; }
        public int IdArtigo { get; set; }

        //chave sec
        public string CriadoPor { get; set; }
        public string AlteradoPor { get; set; }

        public decimal QuantidadeAdquirida { get; set; }
        public decimal PrecoUnitario { get; set; }

        //propriedade de navegação
        public virtual Compra Compra { get; set; }
        //propriedade de navegação
        public virtual Artigo Artigo { get; set; }

    }
}
