using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    internal class ItemPrevistosController
    {
        // Obtém os itens previstos de uma compra
        public static List<ItemPrevisto> ObterItensPrevisos(int idCompra)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.ItensCompra.OfType<ItemPrevisto>()
                    .Include(i => i.Artigo)
                    .Where(i => i.IdCompra == idCompra)
                    .ToList();
            }
        }

        // Adiciona um item previsto a uma compra
        public static bool AdicionarItemPrevisto(int idCompra, int idArtigo, decimal quantidadePrevista, out string mensagem)
        {
            mensagem = "";

            if (idArtigo <= 0)
            {
                mensagem = "Selecione um artigo.";
                return false;
            }
            if (quantidadePrevista <= 0)
            {
                mensagem = "Indique uma quantidade válida.";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == idCompra);
                if (compra == null || compra.Fechada)
                {
                    mensagem = "Compra inválida ou já fechada.";
                    return false;
                }

                bool jaExiste = db.ItensCompra.OfType<ItemPrevisto>()
                    .Any(i => i.IdCompra == idCompra && i.IdArtigo == idArtigo);
                if (jaExiste)
                {
                    mensagem = "Este artigo já está na lista de compras previstas.";
                    return false;
                }

                ItemPrevisto item = new ItemPrevisto
                {
                    IdCompra = idCompra,
                    IdArtigo = idArtigo,
                    quantidadePrevista = (int)quantidadePrevista,
                    QuantidadeAdquirida = 0,
                    PrecoUnitario = 0,
                    CriadoPor = Sessao.UtilizadorAtual
                };

                db.ItensCompra.Add(item);
                db.SaveChanges();

                mensagem = "Item previsto adicionado com sucesso.";
                return true;
            }
        }

        // Remove um item previsto
        public static bool RemoverItemPrevisto(int idItem, out string mensagem)
        {
            mensagem = "";
            using (IShoppingContext db = new IShoppingContext())
            {
                ItemCompra item = db.ItensCompra.FirstOrDefault(i => i.Id == idItem);
                if (item == null)
                {
                    mensagem = "Item não encontrado.";
                    return false;
                }
                db.ItensCompra.Remove(item);
                db.SaveChanges();
                mensagem = "Item removido com sucesso.";
                return true;
            }
        }

        // Marca um item previsto como adquirido (usado no modo compra)
        public static bool AtualizarItemAdquirido(int idItem, decimal quantidade, decimal preco, out string mensagem)
        {
            mensagem = "";

            if (quantidade <= 0) { mensagem = "Indique uma quantidade válida."; return false; }
            if (preco < 0) { mensagem = "Indique um preço válido."; return false; }

            using (IShoppingContext db = new IShoppingContext())
            {
                ItemCompra item = db.ItensCompra.FirstOrDefault(i => i.Id == idItem);
                if (item == null) { mensagem = "Item não encontrado."; return false; }

                decimal antigaQtd = item.QuantidadeAdquirida;
                decimal antigoPreco = item.PrecoUnitario;

                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = preco;
                item.AlteradoPor = Sessao.UtilizadorAtual;

                Compra compra = db.Compras.FirstOrDefault(c => c.Id == item.IdCompra);
                if (compra != null)
                {
                    compra.GastoTotal -= (antigaQtd * antigoPreco);
                    compra.GastoTotal += (quantidade * preco);
                }

                db.SaveChanges();
                mensagem = "Aquisição registada com sucesso.";
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
