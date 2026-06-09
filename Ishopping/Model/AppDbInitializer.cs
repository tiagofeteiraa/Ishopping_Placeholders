using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ishopping.Model
{
    //internal class AppDbInitializer : DropCreateDatabaseAlways<IShoppingContext> //limpar dados cada vez que arrancar o programa
    internal class AppDbInitializer : DropCreateDatabaseIfModelChanges<IShoppingContext>
    {
        protected override void Seed(IShoppingContext context)
        {
            // Adiciona utilizadores
            context.Utilizadores.Add(new Utilizador
            {
                Username = "tiago",
                Password = "12345"
            });

            context.Utilizadores.Add(new Utilizador
            {
                Username = "henrique",
                Password = "12345"
            });

            context.Utilizadores.Add(new Utilizador
            {
                Username = "vasco",
                Password = "12345"
            });

            context.SaveChanges();

            // Adiciona tipos de artigos com descrição
            context.TipoArtigos.Add(new TipoArtigo
            {
                Nome = "Eletrónicos",
                Descricao = "Dispositivos e equipamentos eletrónicos"
            });

            context.TipoArtigos.Add(new TipoArtigo
            {
                Nome = "Roupa",
                Descricao = "Vestuário e acessórios de moda"
            });

            context.TipoArtigos.Add(new TipoArtigo
            {
                Nome = "Livros",
                Descricao = "Publicações e material de leitura"
            });

            context.TipoArtigos.Add(new TipoArtigo
            {
                Nome = "Alimentos",
                Descricao = "Produtos alimentares e bebidas"
            });

            context.TipoArtigos.Add(new TipoArtigo
            {
                Nome = "Móveis",
                Descricao = "Peças de mobiliário e decoração"
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}