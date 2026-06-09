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
        //chave primária
        public int Id { get; set; }
        //propriedades
        public string Nome { get; set; }
        public decimal Preco { get; set; }


        //chave sec
        public int IdTipoArtigo { get; set; }
        //propriedade de navegação
        public virtual TipoArtigo TipoArtigo { get; set; }
        //propriedade de navegação para itens de compra
        public virtual ICollection<ItemCompra> ItensCompra { get; set; }
    }
}
