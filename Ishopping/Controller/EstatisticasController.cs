using Ishopping.Model;
using Ishopping.View;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Ishopping.Controller
{
    // Controller responsável pelas Estatísticas
    internal class EstatisticasController
    {
        // Dicionário para converter o nome do mês para o número correspondente (Janeiro = 1, Fevereiro = 2, etc.)
        private static System.Collections.Generic.Dictionary<string, int> DevolverIntMesCorrespondente()
        {
            
            return new System.Collections.Generic.Dictionary<string, int>
            {
                { "Janeiro",   1  },
                { "Fevereiro", 2  },
                { "Março",     3  },
                { "Abril",     4  },
                { "Maio",      5  },
                { "Junho",     6  },
                { "Julho",     7  },
                { "Agosto",    8  },
                { "Setembro",  9  },
                { "Outubro",   10 },
                { "Novembro",  11 },
                { "Dezembro",  12 }
            };
        }


        // Sugere um orçamento para o próximo mês com base na média dos últimos 6 meses

        public static SugestaoOrcamento SugerirOrcamento(out string mensagem)
        {
            var meses = DevolverIntMesCorrespondente();

            mensagem = "";

            SugestaoOrcamento sugestao = new SugestaoOrcamento();

            using (IShoppingContext db = new IShoppingContext())
            {
                // orçamentos dos últimos 6 meses
                DateTime dataMin = DateTime.Now.AddMonths(-6);

                // Filtra os orçamentos para os últimos 6 meses
                // Primeiro, converte os orçamentos para uma lista em memória para evitar problemas de tradução de LINQ to Entities
                var orcamentos = db.Orcamentos
                                   .ToList()
                                   
                                   .Where(o => new DateTime(o.Ano, meses[o.Mes], 1) >= dataMin
                                            && new DateTime(o.Ano, meses[o.Mes], 1) < DateTime.Today)
                                   .ToList();

                // Calcula a média dos valores máximos dos orçamentos dos últimos 6 meses
                if (orcamentos.Any())
                {
                    sugestao.MediaUltimosMeses = orcamentos.Average(o => o.ValorMaximo);
                    sugestao.SugestaoProximoMes = sugestao.MediaUltimosMeses;

                    mensagem = "Sugestão de orçamento gerada com sucesso!";
                }
                else
                {
                    mensagem = "Não foi possível calcular a sugestão de orçamento! Tem que ter orçamentos registados nos últimos 6 meses.";
                    return null;
                }

                return sugestao;
            }
        }

        
        // Mostra na datagridview o histórico de orçamento vs total gasto em cada mês
       
        public static void MostrarHistoricoOrcamento()
        {
            var meses = DevolverIntMesCorrespondente();

            using (IShoppingContext db = new IShoppingContext())
            {
                // Para cada orçamento, calcula o total gasto em compras fechadas no mesmo mês e ano, e apresenta a diferença
                var orcamentos = db.Orcamentos
                                   .AsEnumerable()
                                   .Select(o =>
                                   {
                                       int mesNumero = meses[o.Mes];
                                       // Calcula o total gasto em compras fechadas no mesmo mês e ano do orçamento
                                       decimal totalCompras = db.Compras
                                           .Where(c => c.Fechada
                                                    && c.DataFecho.Value.Year == o.Ano
                                                    && c.DataFecho.Value.Month == mesNumero)
                                           .Sum(c => (decimal?)c.GastoTotal) ?? 0;
                                       
                                       return new
                                       {
                                           o.Ano,
                                           o.Mes,
                                           Orcamento = o.ValorMaximo,
                                           TotalCompras = totalCompras,
                                           Diferenca = o.ValorMaximo - totalCompras
                                       };
                                   })
                                   .OrderByDescending(o => o.Ano)
                                   .ThenBy(o => meses[o.Mes])
                                   .ToList();

                if (orcamentos.Any())
                {
                    FormEstatisticas.historicoOrcamentos.DataSource = orcamentos;
                }
                else
                {
                    MessageBox.Show("Sem orçamentos para mostrar");
                }
            }
        }

       
        //  % de itens previstos vs não previstos
       
        public static void MostrarEstatisticasArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                var comprasFechadas = db.Compras
                    .Where(c => c.Fechada)
                    .ToList()
                    .Select(compra =>
                    {
                        // Conta os itens previstos desta compra
                        int previstos = db.ItensCompra
                            .OfType<ItemPrevisto>()
                            .Count(i => i.IdCompra == compra.Id);

                        // Conta os itens não previstos desta compra
                        int naoPrevistos = db.ItensCompra
                            .OfType<ItemNaoPrevisto>()
                            .Count(i => i.IdCompra == compra.Id);

                        int total = previstos + naoPrevistos;

                        return new
                        {
                            Compra = compra.NomeCompra,
                            DataFecho = compra.DataFecho,
                            PercentagemPrevistos = total == 0 ? 0 : (decimal)previstos * 100 / total,
                            PercentagemNaoPrevistos = total == 0 ? 0 : (decimal)naoPrevistos * 100 / total
                        };
                    })
                    .ToList();

                if (comprasFechadas.Any())
                {
                    FormEstatisticas.listagemPercentagem.DataSource = comprasFechadas;
                }
                else
                {
                    MessageBox.Show("Sem compras fechadas para mostrar");
                }
            }
        }
    }
}