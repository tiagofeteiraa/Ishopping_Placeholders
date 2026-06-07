using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    internal class ItemNaoPrevistosController
    {
        // Obtém os itens não previstos de uma compra
        public static List<ItemNaoPrevisto> ObterItensNaoPrevistos(int idCompra)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.ItensCompra.OfType<ItemNaoPrevisto>()
                    .Include(i => i.Artigo)
                    .Where(i => i.IdCompra == idCompra)
                    .ToList();
            }
        }

        // Adiciona um item não previsto a uma compra (entra logo como adquirido)
        public static bool AdicionarItemNaoPrevisto(int idCompra, int idArtigo,
            decimal quantidade, decimal preco, string observacoes, out string mensagem)
        {
            mensagem = "";

            if (idArtigo <= 0) { mensagem = "Selecione um artigo."; return false; }
            if (quantidade <= 0) { mensagem = "Indique uma quantidade válida."; return false; }
            if (preco < 0) { mensagem = "Indique um preço válido."; return false; }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == idCompra);
                if (compra == null || compra.Fechada)
                {
                    mensagem = "Compra inválida ou já fechada.";
                    return false;
                }

                ItemNaoPrevisto item = new ItemNaoPrevisto
                {
                    IdCompra = idCompra,
                    IdArtigo = idArtigo,
                    QuantidadeAdquirida = quantidade,
                    PrecoUnitario = preco,
                    Observacoes = observacoes,
                    CriadoPor = Sessao.UtilizadorAtual
                };

                compra.GastoTotal += quantidade * preco;
                compra.AlteradoPor = Sessao.UtilizadorAtual;

                db.ItensCompra.Add(item);
                db.SaveChanges();

                mensagem = "Item não previsto adicionado com sucesso.";
                return true;
            }
        }

        // Remove um item não previsto
        public static bool RemoverItemNaoPrevisto(int idItem, out string mensagem)
        {
            mensagem = "";
            using (IShoppingContext db = new IShoppingContext())
            {
                ItemNaoPrevisto item = db.ItensCompra.OfType<ItemNaoPrevisto>()
                    .FirstOrDefault(i => i.Id == idItem);
                if (item == null)
                {
                    mensagem = "Item não encontrado.";
                    return false;
                }

                // Reverter o gasto total da compra
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == item.IdCompra);
                if (compra != null)
                    compra.GastoTotal -= item.QuantidadeAdquirida * item.PrecoUnitario;

                db.ItensCompra.Remove(item);
                db.SaveChanges();

                mensagem = "Item removido com sucesso.";
                return true;
            }
        }

        // Carrega artigos filtrados por tipo para um ComboBox
        public static void CarregarArtigosPorTipo(int idTipo, ComboBox comboBoxArtigo)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                var artigos = db.Artigos
                    .Where(a => a.IdTipoArtigo == idTipo)
                    .OrderBy(a => a.Nome)
                    .ToList();

                comboBoxArtigo.DataSource = artigos;
                comboBoxArtigo.DisplayMember = "Nome";
                comboBoxArtigo.ValueMember = "Id";
                comboBoxArtigo.SelectedIndex = -1;
            }
        }
    }
}
