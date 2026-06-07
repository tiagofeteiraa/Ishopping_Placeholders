using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    internal class ArtigosController
    {
        // DTO para exibição na grid (evita o objeto TipoArtigo inteiro aparecer como coluna)
        public class ArtigoGridDto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public string TipoArtigo { get; set; }
        }

        // Carrega e mostra todos os artigos na grid com o nome do tipo visível
        public static void MostrarArtigos(DataGridView grid)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                var lista = db.Artigos
                    .Include(a => a.TipoArtigo)
                    .OrderBy(a => a.Nome)
                    .ToList()
                    .Select(a => new ArtigoGridDto
                    {
                        Id = a.Id,
                        Nome = a.Nome,
                        Preco = a.Preco,
                        TipoArtigo = a.TipoArtigo?.Nome ?? ""
                    }).ToList();

                grid.DataSource = lista;
            }
        }

        // Obtém todos os artigos da base de dados
        public static List<Artigo> ObterArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        // Configura as propriedades da grid
        public static void ConfigurarGrid(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            if (grid.ColumnCount == 0) return;

            if (grid.Columns.Contains("Id")) grid.Columns["Id"].Width = 50;
            if (grid.Columns.Contains("Nome")) grid.Columns["Nome"].Width = 160;
            if (grid.Columns.Contains("Preco")) grid.Columns["Preco"].Width = 80;
            if (grid.Columns.Contains("TipoArtigo")) grid.Columns["TipoArtigo"].Width = 150;
        }

        // Limpa os campos do formulário
        public static void LimparCampos(TextBox textBoxID, TextBox textBoxNome,
            TextBox textBoxPreco, ComboBox comboBoxTipoArtigo = null)
        {
            textBoxID.Clear();
            textBoxNome.Clear();
            textBoxPreco.Clear();
            if (comboBoxTipoArtigo != null)
                comboBoxTipoArtigo.SelectedIndex = -1;
        }

        // Carrega os tipos de artigos num ComboBox
        public static void CarregarTiposArtigos(ComboBox comboBox)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                List<TipoArtigo> tipos = db.TipoArtigos
                    .OrderBy(t => t.Nome)
                    .ToList();

                comboBox.DataSource = tipos;
                comboBox.DisplayMember = "Nome";
                comboBox.ValueMember = "Id";
                comboBox.SelectedIndex = -1;
            }
        }

        // Obtém dados da linha selecionada na grid
        public static Dictionary<string, string> ObterDadosLinhaSelecionada(DataGridView grid)
        {
            if (grid.SelectedRows.Count == 0) return null;

            var linha = grid.SelectedRows[0];
            return new Dictionary<string, string>
            {
                { "Id",    linha.Cells["Id"].Value?.ToString()    ?? string.Empty },
                { "Nome",  linha.Cells["Nome"].Value?.ToString()  ?? string.Empty },
                { "Preco", linha.Cells["Preco"].Value?.ToString() ?? string.Empty }
            };
        }

        // Adiciona um novo artigo
        public static void AdicionarArtigo(string nome, string preco, int idTipoArtigo)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome do artigo.");
                return;
            }
            if (!decimal.TryParse(preco, out decimal precoDecimal) || precoDecimal <= 0)
            {
                MessageBox.Show("Indique um preço válido.");
                return;
            }
            if (idTipoArtigo <= 0)
            {
                MessageBox.Show("Selecione um tipo de artigo.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                TipoArtigo tipoArtigo = db.TipoArtigos.FirstOrDefault(t => t.Id == idTipoArtigo);
                if (tipoArtigo == null) { MessageBox.Show("Tipo de artigo inválido."); return; }

                Artigo artigo = new Artigo
                {
                    Nome = nome.Trim(),
                    Preco = precoDecimal,
                    IdTipoArtigo = idTipoArtigo
                };

                db.Artigos.Add(artigo);
                db.SaveChanges();
                MessageBox.Show("Artigo adicionado com sucesso.");
            }
        }

        // Atualiza um artigo existente
        public static void AtualizarArtigo(string id, string nome, string preco, int idTipoArtigo)
        {
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome do artigo.");
                return;
            }
            if (!decimal.TryParse(preco, out decimal precoDecimal) || precoDecimal <= 0)
            {
                MessageBox.Show("Indique um preço válido.");
                return;
            }
            if (idTipoArtigo <= 0)
            {
                MessageBox.Show("Selecione um tipo de artigo.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == idInt);
                if (artigo == null) { MessageBox.Show("Artigo não encontrado."); return; }

                TipoArtigo tipoArtigo = db.TipoArtigos.FirstOrDefault(t => t.Id == idTipoArtigo);
                if (tipoArtigo == null) { MessageBox.Show("Tipo de artigo inválido."); return; }

                artigo.Nome = nome.Trim();
                artigo.Preco = precoDecimal;
                artigo.IdTipoArtigo = idTipoArtigo;
                db.SaveChanges();
                MessageBox.Show("Artigo atualizado com sucesso.");
            }
        }

        // Elimina um artigo
        public static void EliminarArtigo(string id)
        {
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == idInt);
                if (artigo == null) { MessageBox.Show("Artigo não encontrado."); return; }

                db.Artigos.Remove(artigo);
                db.SaveChanges();
                MessageBox.Show("Artigo eliminado com sucesso.");
            }
        }

        // Obtém um artigo específico pelo ID
        public static Artigo ObterArtigoPorId(int id)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .FirstOrDefault(a => a.Id == id);
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
