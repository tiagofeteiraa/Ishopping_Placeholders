using System;
using System.Collections.Generic;
using System.Linq;
using Ishopping.Model;

namespace Ishopping.Controller
{
    internal class ArtigosController
    {
        public static List<Artigo> ObterArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Artigos
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        public static bool AdicionarArtigo(string nome, decimal preco, out string mensagem)
        {
            mensagem = "";

            if (string.IsNullOrWhiteSpace(nome))
            {
                mensagem = "Indique o nome do artigo.";
                return false;
            }

            if (preco < 0)
            {
                mensagem = "O preço não pode ser negativo.";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = new Artigo
                {
                    Nome = nome.Trim(),
                    Preco = preco,
                };

                db.Artigos.Add(artigo);
                db.SaveChanges();

                mensagem = "Artigo adicionado com sucesso.";
                return true;
            }
        }

        public static bool AtualizarArtigo(int id, string nome, decimal preco, out string mensagem)
        {
            mensagem = "";

            if (string.IsNullOrWhiteSpace(nome))
            {
                mensagem = "Indique o nome do artigo.";
                return false;
            }

            if (preco < 0)
            {
                mensagem = "O preço não pode ser negativo.";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == id);

                if (artigo == null)
                {
                    mensagem = "Artigo não encontrado.";
                    return false;
                }

                artigo.Nome = nome.Trim();
                artigo.Preco = preco;

                db.SaveChanges();

                mensagem = "Artigo atualizado com sucesso.";
                return true;
            }
        }

        public static bool EliminarArtigo(int id, out string mensagem)
        {
            mensagem = "";

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == id);

                if (artigo == null)
                {
                    mensagem = "Artigo não encontrado.";
                    return false;
                }

                db.Artigos.Remove(artigo);
                db.SaveChanges();

                mensagem = "Artigo eliminado com sucesso.";
                return true;
            }
        }

        public static Artigo ObterArtigoPorId(int id)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Artigos.FirstOrDefault(a => a.Id == id);
            }
        }
    }
}