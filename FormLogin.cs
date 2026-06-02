using System;
using System.Windows.Forms;
using Ishopping.Controller;

namespace Ishopping
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string mensagem;

            bool ok = LoginController.Autenticar(
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                out mensagem);

            MessageBox.Show(mensagem);

            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
