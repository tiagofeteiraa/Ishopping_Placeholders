using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Model
{
    internal class SugestaoOrcamento
    {
        // média dos orçamentos nos últimos meses
        public decimal MediaUltimosMeses { get; set; }

        // orçamento do próximo mês
        public decimal SugestaoProximoMes { get; set; }
    }
}
