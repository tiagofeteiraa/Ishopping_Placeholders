using Ishopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Model
{
    internal class Compra
    {
        
        public int Id { get; set; }

        public string NomeCompra { get; set; }

       
        public int IdCriadoPor { get; set; }
        public int? IdAlteradoPor { get; set; }

        public int? IdFechadoPor { get; set; }
        
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFecho { get; set; }
        public bool Fechada { get; set; }
        
        public decimal TotalGasto { get; set; }

        public virtual ICollection<ItemCompra> ItensCompras { get; set; }


        
    }

}
