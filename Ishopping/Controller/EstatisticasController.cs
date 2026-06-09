using Ishopping.Model;
using Ishopping.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ishopping.Controller
{
    // Controlador responsável por toda a lógica das estatísticas da aplicação
    internal class EstatisticasController
    {
        // Devolve um dicionário que associa o nome do mês ao seu número (ex: "Janeiro" → 1)
        private static Dictionary<string, int> ObterMapaMeses()
        {
            return new Dictionary<string, int>
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

        // Carrega na grid o histórico de todos os orçamentos com o total gasto e a diferença em cada mês
        public static void CarregarHistoricoOrcamentosNaGrid(DataGridView grid)
        {
            var mapaMeses = ObterMapaMeses();

            using (IShoppingContext db = new IShoppingContext())
            {
                var historico = db.Orcamentos
                    .AsEnumerable()
                    .Select(o =>
                    {
                        // Converte o nome do mês para número para poder comparar com as datas das compras
                        int mesNumero = mapaMeses[o.Mes];

                        // Soma o gasto total de todas as compras fechadas no mesmo mês e ano do orçamento
                        decimal totalGasto = db.Compras
                            .Where(c => c.Fechada
                                     && c.DataFecho.Value.Year == o.Ano
                                     && c.DataFecho.Value.Month == mesNumero)
                            .Sum(c => (decimal?)c.GastoTotal) ?? 0;

                        // Devolve uma linha com o orçamento, o total gasto e a diferença entre os dois
                        return new
                        {
                            Ano = o.Ano,
                            Mes = o.Mes,
                            Orcamento = o.ValorMaximo,
                            TotalGasto = totalGasto,
                            Diferenca = o.ValorMaximo - totalGasto
                        };
                    })
                    // Ordena do ano mais recente para o mais antigo, e dentro do mesmo ano pelo mês
                    .OrderByDescending(o => o.Ano)
                    .ThenBy(o => mapaMeses[o.Mes])
                    .ToList();

                if (historico.Any())
                    grid.DataSource = historico;
                else
                    MessageBox.Show("Sem orçamentos para mostrar.", "Informação",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Carrega na grid a percentagem de itens previstos e não previstos de cada compra fechada
        public static void CarregarPercentagensComprasFechadasNaGrid(DataGridView grid)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                var dados = db.Compras
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

                        // Total de itens da compra (previstos + não previstos)
                        int total = previstos + naoPrevistos;

                        // Calcula as percentagens; se não houver itens fica a zero para evitar divisão por zero
                        return new
                        {
                            Compra = compra.NomeCompra,
                            DataFecho = compra.DataFecho,
                            PercentagemPrevistos = total == 0 ? 0 : (decimal)previstos * 100 / total,
                            PercentagemNaoPrevistos = total == 0 ? 0 : (decimal)naoPrevistos * 100 / total
                        };
                    })
                    .ToList();

                if (dados.Any())
                    grid.DataSource = dados;
                else
                    MessageBox.Show("Sem compras fechadas para mostrar.", "Informação",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Calcula uma sugestão de orçamento para o próximo mês com base na média dos últimos 6 meses
        public static SugestaoOrcamento CalcularSugestaoOrcamentoProximoMes(out string mensagem)
        {
            var mapaMeses = ObterMapaMeses();
            mensagem = string.Empty;

            using (IShoppingContext db = new IShoppingContext())
            {
                // Define a data mínima como 6 meses atrás a partir de hoje
                DateTime dataMinima = DateTime.Now.AddMonths(-6);

                // Filtra os orçamentos que estão dentro dos últimos 6 meses e já passaram (não inclui o mês atual)
                var orcamentosRecentes = db.Orcamentos
                    .ToList()
                    .Where(o =>
                    {
                        DateTime dataMes = new DateTime(o.Ano, mapaMeses[o.Mes], 1);
                        return dataMes >= dataMinima && dataMes < DateTime.Today;
                    })
                    .ToList();

                // Se não houver orçamentos no período, não é possível gerar sugestão
                if (!orcamentosRecentes.Any())
                {
                    mensagem = "Não foi possível calcular a sugestão de orçamento. " +
                               "São necessários orçamentos registados nos últimos 6 meses.";
                    return null;
                }

                // Calcula a média dos valores máximos dos orçamentos encontrados
                decimal media = orcamentosRecentes.Average(o => o.ValorMaximo);

                mensagem = "Sugestão de orçamento gerada com sucesso!";

                // A sugestão para o próximo mês é igual à média calculada
                return new SugestaoOrcamento
                {
                    MediaUltimosMeses = media,
                    SugestaoProximoMes = media
                };
            }
        }
    }
}