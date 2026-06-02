using System;
using System.Collections.Generic;
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
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        // Adiciona um novo artigo à base de dados
        public static void AdicionarArtigo(string nome, string preco)
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

            using (IShoppingContext db = new IShoppingContext())
            {
                // Cria uma nova instância de artigo com os dados fornecidos
                Artigo artigo = new Artigo
                {
                    Nome = nome.Trim(),
                    Preco = precoDecimal,
                };

                // Adiciona o artigo à base de dados e guarda as alterações
                db.Artigos.Add(artigo);
                db.SaveChanges();

                MessageBox.Show("Artigo adicionado com sucesso.");
            }
        }

        // Atualiza um artigo existente na base de dados
        public static void AtualizarArtigo(string id, string nome, string preco)
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

                // Atualiza os dados do artigo
                artigo.Nome = nome.Trim();
                artigo.Preco = precoDecimal;

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
                // Procura o artigo pelo ID
                return db.Artigos.FirstOrDefault(a => a.Id == id);
            }
        }
    }
}