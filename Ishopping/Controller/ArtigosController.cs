using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    // Controlador responsável pelas operações dos artigos
    internal class ArtigosController
    {
        // Carrega e mostra todos os artigos na tabela
        public static void MostrarArtigos(DataGridView grid)
        {
            // Obtém a lista de artigos da base de dados
            List<Artigo> artigos = ObterArtigos();
            // Associa os dados à tabela
            grid.DataSource = artigos;
        }

        // Obtém todos os artigos da base de dados, ordenados alfabeticamente por nome
        public static List<Artigo> ObterArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)  // Carrega o TipoArtigo relacionado
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        // Configura as propriedades da tabela de artigos
        public static void ConfigurarGrid(DataGridView grid)
        {
            // Define o modo de seleção para seleccionar a linha inteira
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Desativa a possibilidade de seleccionar múltiplas linhas
            grid.MultiSelect = false;

            // Verifica se a tabela tem colunas
            if (grid.ColumnCount == 0)
                return;

            // Define a largura de cada coluna
            grid.Columns["Id"].Width = 50;
            grid.Columns["Nome"].Width = 100;
            grid.Columns["Preco"].Width = 80;

            // Se existir coluna TipoArtigo, configura a largura
            if (grid.Columns.Contains("TipoArtigo"))
            {
                grid.Columns["TipoArtigo"].Width = 120;
            }
        }

        // Limpa todos os campos de texto do formulário
        public static void LimparCampos(TextBox textBoxID, TextBox textBoxNome, TextBox textBoxPreco, ComboBox comboBoxTipoArtigo = null)
        {
            textBoxID.Clear();
            textBoxNome.Clear();
            textBoxPreco.Clear();
            if (comboBoxTipoArtigo != null)
                comboBoxTipoArtigo.SelectedIndex = -1;
        }

        // Carrega os tipos de artigos no comboBox
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

        // Obtém os dados da linha selecionada na tabela
        public static Dictionary<string, string> ObterDadosLinhaSelecionada(DataGridView grid)
        {
            // Se nenhuma linha estiver selecionada, retorna nulo
            if (grid.SelectedRows.Count == 0)
                return null;

            // Obtém a linha selecionada
            var linha = grid.SelectedRows[0];

            // Retorna um dicionário com os dados da linha
            return new Dictionary<string, string>
            {
                { "Id", linha.Cells["Id"].Value?.ToString() ?? string.Empty },
                { "Nome", linha.Cells["Nome"].Value?.ToString() ?? string.Empty },
                { "Preco", linha.Cells["Preco"].Value?.ToString() ?? string.Empty }
            };
        }

        // Adiciona um novo artigo à base de dados
        public static void AdicionarArtigo(string nome, string preco, int idTipoArtigo)
        {
            // Valida se o nome foi preenchido
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome do artigo.");
                return;
            }

            // Valida se o preço é um número decimal válido maior que zero
            if (!decimal.TryParse(preco, out decimal precoDecimal) || precoDecimal <= 0)
            {
                MessageBox.Show("Indique um preço válido.");
                return;
            }

            // Valida se um tipo de artigo foi selecionado
            if (idTipoArtigo <= 0)
            {
                MessageBox.Show("Selecione um tipo de artigo.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Valida se o tipo de artigo existe
                TipoArtigo tipoArtigo = db.TipoArtigos.FirstOrDefault(t => t.Id == idTipoArtigo);
                if (tipoArtigo == null)
                {
                    MessageBox.Show("Tipo de artigo inválido.");
                    return;
                }

                // Cria uma nova instância de artigo com os dados fornecidos
                Artigo artigo = new Artigo
                {
                    Nome = nome.Trim(),
                    Preco = precoDecimal,
                    IdTipoArtigo = idTipoArtigo
                };

                // Adiciona o artigo à base de dados e guarda as alterações
                db.Artigos.Add(artigo);
                db.SaveChanges();

                MessageBox.Show("Artigo adicionado com sucesso.");
            }
        }

        // Atualiza um artigo existente na base de dados
        public static void AtualizarArtigo(string id, string nome, string preco, int idTipoArtigo)
        {
            // Valida se o ID é um número inteiro válido
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            // Valida se o nome foi preenchido
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome do artigo.");
                return;
            }

            // Valida se o preço é um número decimal válido maior que zero
            if (!decimal.TryParse(preco, out decimal precoDecimal) || precoDecimal <= 0)
            {
                MessageBox.Show("Indique um preço válido.");
                return;
            }

            // Valida se um tipo de artigo foi selecionado
            if (idTipoArtigo <= 0)
            {
                MessageBox.Show("Selecione um tipo de artigo.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o artigo pelo ID
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == idInt);

                // Se o artigo não existir, mostra mensagem de erro
                if (artigo == null)
                {
                    MessageBox.Show("Artigo não encontrado.");
                    return;
                }

                // Valida se o tipo de artigo existe
                TipoArtigo tipoArtigo = db.TipoArtigos.FirstOrDefault(t => t.Id == idTipoArtigo);
                if (tipoArtigo == null)
                {
                    MessageBox.Show("Tipo de artigo inválido.");
                    return;
                }

                // Atualiza os dados do artigo
                artigo.Nome = nome.Trim();
                artigo.Preco = precoDecimal;
                artigo.IdTipoArtigo = idTipoArtigo;

                // Guarda as alterações na base de dados
                db.SaveChanges();

                MessageBox.Show("Artigo atualizado com sucesso.");
            }
        }

        // Elimina um artigo da base de dados
        public static void EliminarArtigo(string id)
        {
            // Valida se o ID é um número inteiro válido
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o artigo pelo ID
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == idInt);

                // Se o artigo não existir, mostra mensagem de erro
                if (artigo == null)
                {
                    MessageBox.Show("Artigo não encontrado.");
                    return;
                }

                // Remove o artigo da base de dados
                db.Artigos.Remove(artigo);
                // Guarda as alterações na base de dados
                db.SaveChanges();

                MessageBox.Show("Artigo eliminado com sucesso.");
            }
        }

        // Obtém um artigo específico pelo ID
        public static Artigo ObterArtigoPorId(int id)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o artigo pelo ID, incluindo o tipo de artigo
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .FirstOrDefault(a => a.Id == id);
            }
        }
    }
}