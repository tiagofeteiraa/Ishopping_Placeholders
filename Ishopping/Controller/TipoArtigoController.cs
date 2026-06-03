using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    internal class TipoArtigoController
    {
        // Carrega e mostra todos os tipos de artigos na tabela
        public static void MostrarTiposArtigos(DataGridView grid)
        {
            List<TipoArtigo> tiposArtigos = ObterTiposArtigos();
            grid.DataSource = tiposArtigos;
        }

        // Obtém todos os tipos de artigos da base de dados, ordenados alfabeticamente por nome
        public static List<TipoArtigo> ObterTiposArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.TipoArtigos
                    .OrderBy(t => t.Nome)
                    .ToList();
            }
        }

        // Obtém a lista de nomes dos tipos de artigos (para comboBox)
        public static List<string> GetTiposArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.TipoArtigos.Select(t => t.Nome).ToList();
            }
        }

        // Adiciona um novo tipo de artigo à base de dados
        public static void AdicionarTipoArtigo(string nome, string descricao)
        {
            // Valida se o nome foi preenchido
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome do tipo de artigo.");
                return;
            }

            // Valida se a descrição foi preenchida
            if (string.IsNullOrWhiteSpace(descricao))
            {
                MessageBox.Show("Indique a descrição do tipo de artigo.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Verifica se o tipo de artigo já existe
                if (db.TipoArtigos.Any(t => t.Nome == nome.Trim()))
                {
                    MessageBox.Show("Tipo de artigo já existe.");
                    return;
                }

                // Cria uma nova instância de tipo de artigo com os dados fornecidos
                TipoArtigo tipoArtigo = new TipoArtigo
                {
                    Nome = nome.Trim(),
                    Descricao = descricao.Trim()
                };

                // Adiciona o tipo de artigo à base de dados e guarda as alterações
                db.TipoArtigos.Add(tipoArtigo);
                db.SaveChanges();

                MessageBox.Show("Tipo de artigo adicionado com sucesso.");
            }
        }

        // Atualiza um tipo de artigo existente na base de dados
        public static void AtualizarTipoArtigo(string id, string nome, string descricao)
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
                MessageBox.Show("Indique o nome do tipo de artigo.");
                return;
            }

            // Valida se a descrição foi preenchida
            if (string.IsNullOrWhiteSpace(descricao))
            {
                MessageBox.Show("Indique a descrição do tipo de artigo.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o tipo de artigo pelo ID
                TipoArtigo tipoArtigo = db.TipoArtigos.FirstOrDefault(t => t.Id == idInt);

                // Se o tipo de artigo não existir, mostra mensagem de erro
                if (tipoArtigo == null)
                {
                    MessageBox.Show("Tipo de artigo não encontrado.");
                    return;
                }

                // Verifica se já existe outro tipo de artigo com o mesmo nome
                if (db.TipoArtigos.Any(t => t.Nome == nome.Trim() && t.Id != idInt))
                {
                    MessageBox.Show("Tipo de artigo com esse nome já existe.");
                    return;
                }

                // Atualiza os dados do tipo de artigo
                tipoArtigo.Nome = nome.Trim();
                tipoArtigo.Descricao = descricao.Trim();

                // Guarda as alterações na base de dados
                db.SaveChanges();

                MessageBox.Show("Tipo de artigo atualizado com sucesso.");
            }
        }

        // Elimina um tipo de artigo da base de dados
        public static void EliminarTipoArtigo(string id)
        {
            // Valida se o ID é um número inteiro válido
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o tipo de artigo pelo ID
                TipoArtigo tipoArtigo = db.TipoArtigos.FirstOrDefault(t => t.Id == idInt);

                // Se o tipo de artigo não existir, mostra mensagem de erro
                if (tipoArtigo == null)
                {
                    MessageBox.Show("Tipo de artigo não encontrado.");
                    return;
                }

                // Verifica se existem artigos associados a este tipo
                if (tipoArtigo.Artigos != null && tipoArtigo.Artigos.Count > 0)
                {
                    MessageBox.Show("Não pode eliminar este tipo de artigo pois existem artigos associados.");
                    return;
                }

                // Remove o tipo de artigo da base de dados
                db.TipoArtigos.Remove(tipoArtigo);
                db.SaveChanges();

                MessageBox.Show("Tipo de artigo eliminado com sucesso.");
            }
        }

        // Pesquisa tipos de artigos por nome
        public static List<TipoArtigo> PesquisarTipoArtigo(string nome)
        {
            // Valida se o nome foi preenchido
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Indique o nome do tipo de artigo para pesquisar.");
                return new List<TipoArtigo>();
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Pesquisa tipos de artigos que contenham o nome fornecido (case-insensitive)
                return db.TipoArtigos
                    .Where(t => t.Nome.Contains(nome.Trim()))
                    .OrderBy(t => t.Nome)
                    .ToList();
            }
        }

        // Obtém um tipo de artigo específico pelo ID
        public static TipoArtigo ObterTipoArtigoPorId(int id)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.TipoArtigos.FirstOrDefault(t => t.Id == id);
            }
        }
    }
}