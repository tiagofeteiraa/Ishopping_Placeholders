using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    internal class ComprasController
    {
        // Obtém todas as compras, opcionalmente filtradas por estado
        public static List<Compra> ObterCompras(bool? apenasAbertas = null)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                var query = db.Compras.AsQueryable();
                if (apenasAbertas == true)
                    query = query.Where(c => !c.Fechada);
                else if (apenasAbertas == false)
                    query = query.Where(c => c.Fechada);

                return query.OrderByDescending(c => c.DataCriacao).ToList();
            }
        }

        // Mostra compras na grid
        public static void MostrarCompras(DataGridView grid, bool? apenasAbertas = null)
        {
            grid.DataSource = ObterCompras(apenasAbertas);
        }

        // Configura a grid de compras
        public static void ConfigurarGrid(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            if (grid.ColumnCount == 0) return;

            string[] ocultar = { "ItensCompras" };
            foreach (string col in ocultar)
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
        }

        // Adiciona uma nova compra
        public static int AdicionarCompra(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome da compra.");
                return -1;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = new Compra
                {
                    NomeCompra = nome.Trim(),
                    DataCriacao = DateTime.Now,
                    CriadoPor = Sessao.UtilizadorAtual,
                    Fechada = false,
                    GastoTotal = 0
                };

                db.Compras.Add(compra);
                db.SaveChanges();
                MessageBox.Show("Compra criada com sucesso.");
                return compra.Id;
            }
        }

        // Atualiza o nome de uma compra
        public static void AtualizarCompra(int id, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome da compra.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == id);
                if (compra == null) { MessageBox.Show("Compra não encontrada."); return; }
                if (compra.Fechada) { MessageBox.Show("Não é possível alterar uma compra fechada."); return; }

                compra.NomeCompra = nome.Trim();
                compra.DataAlteracao = DateTime.Now;
                compra.AlteradoPor = Sessao.UtilizadorAtual;
                db.SaveChanges();
                MessageBox.Show("Compra atualizada com sucesso.");
            }
        }

        // Elimina uma compra
        public static void EliminarCompra(string id)
        {
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.Compras
                    .Include(c => c.ItensCompras)
                    .FirstOrDefault(c => c.Id == idInt);

                if (compra == null) { MessageBox.Show("Compra não encontrada."); return; }
                if (compra.Fechada) { MessageBox.Show("Não é possível eliminar uma compra fechada."); return; }

                db.ItensCompra.RemoveRange(compra.ItensCompras);
                db.Compras.Remove(compra);
                db.SaveChanges();
                MessageBox.Show("Compra eliminada com sucesso.");
            }
        }

        // Obtém uma compra pelo ID com itens incluídos
        public static Compra ObterCompraPorId(int id)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Compras
                    .Include(c => c.ItensCompras)
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        // Fecha uma compra
        public static void FecharCompra(int idCompra)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == idCompra);
                if (compra == null) { MessageBox.Show("Compra não encontrada."); return; }
                if (compra.Fechada) { MessageBox.Show("A compra já está fechada."); return; }

                compra.Fechada = true;
                compra.DataFecho = DateTime.Now;
                compra.FechadoPor = Sessao.UtilizadorAtual;
                db.SaveChanges();
                MessageBox.Show("Compra fechada com sucesso.");
            }
        }

        // Obtém o orçamento disponível para o mês atual
        public static decimal ObterOrcamentoDisponivel()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                int mes = DateTime.Now.Month;
                int ano = DateTime.Now.Year;
                string[] meses = { "Janeiro","Fevereiro","Março","Abril","Maio","Junho",
                                   "Julho","Agosto","Setembro","Outubro","Novembro","Dezembro" };
                string nomeMes = meses[mes - 1];

                Orcamento orc = db.Orcamentos.FirstOrDefault(o => o.Mes == nomeMes && o.Ano == ano);
                if (orc == null) return -1;

                decimal totalGasto = db.Compras
                    .Where(c => c.DataCriacao.Month == mes && c.DataCriacao.Year == ano)
                    .Sum(c => (decimal?)c.GastoTotal) ?? 0;

                return orc.ValorMaximo - totalGasto;
            }
        }

        // Obtém orçamento máximo do mês atual
        public static decimal ObterOrcamentoMaximo()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                int mes = DateTime.Now.Month;
                int ano = DateTime.Now.Year;
                string[] meses = { "Janeiro","Fevereiro","Março","Abril","Maio","Junho",
                                   "Julho","Agosto","Setembro","Outubro","Novembro","Dezembro" };
                string nomeMes = meses[mes - 1];

                Orcamento orc = db.Orcamentos.FirstOrDefault(o => o.Mes == nomeMes && o.Ano == ano);
                return orc?.ValorMaximo ?? -1;
            }
        }

        // Exporta compras fechadas para CSV
        public static void ExportarCSV()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV|*.csv";
                dlg.FileName = "ComprasFechadas_" + DateTime.Now.ToString("yyyyMMdd");
                if (dlg.ShowDialog() != DialogResult.OK) return;

                using (IShoppingContext db = new IShoppingContext())
                {
                    var comprasFechadas = db.Compras
                        .Include(c => c.ItensCompras)
                        .Where(c => c.Fechada)
                        .ToList();

                    var sb = new StringBuilder();
                    sb.AppendLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                    foreach (var compra in comprasFechadas)
                    {
                        if (compra.ItensCompras == null || compra.ItensCompras.Count == 0)
                        {
                            sb.AppendLine($"{compra.NomeCompra};{compra.DataCriacao:dd/MM/yyyy};{compra.DataFecho:dd/MM/yyyy};;;;0;0;0");
                            continue;
                        }

                        foreach (var item in compra.ItensCompras)
                        {
                            var artigo = db.Artigos.FirstOrDefault(a => a.Id == item.IdArtigo);
                            string nomeArtigo = artigo?.Nome ?? "";

                            bool isPrevisto = item is ItemPrevisto;
                            int qtdPrevista = isPrevisto ? ((ItemPrevisto)item).quantidadePrevista : 0;

                            sb.AppendLine($"{compra.NomeCompra};{compra.DataCriacao:dd/MM/yyyy};{compra.DataFecho:dd/MM/yyyy};" +
                                $"{nomeArtigo};{(isPrevisto ? "Sim" : "")};{(!isPrevisto ? "Sim" : "")};" +
                                $"{qtdPrevista};{item.QuantidadeAdquirida};{item.PrecoUnitario}");
                        }
                    }

                    File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Ficheiro CSV exportado com sucesso.");
                }
            }
        }
    }
}
