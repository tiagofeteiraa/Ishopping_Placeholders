using Ishopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Controller
{
    internal class LoginController
    {
        public static bool Autenticar(string login, string password,
            out string mensagem)
        {
            mensagem = "";
            if (login.Trim() == "" || password.Trim() == "")
            {
                mensagem = "Deve introduzir o username e a password";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Utilizador utilizador = db.Utilizadores.FirstOrDefault(u => u.Username == login
                    && u.Password == password);

                if (utilizador == null)
                {
                    mensagem = "Username ou password incorretos.";
                    return false;
                }

                Sessao.UtilizadorAtual = utilizador.Username;
                mensagem = "Autenticação com sucesso.";
                return true;

            }
        }
    }
}
