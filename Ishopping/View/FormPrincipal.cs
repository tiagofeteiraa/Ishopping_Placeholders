using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ishopping.Controller;

namespace Ishopping.View
{
    public partial class FormPrincipal : Form
    {
        

        public FormPrincipal()
        {
            InitializeComponent();
            
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArtigos_Click(object sender, EventArgs e)
        {
            FormArtigos formArtigos = new FormArtigos();
            formArtigos.ShowDialog();
           
        }

        private void btnTiposArtigo_Click(object sender, EventArgs e)
        {

        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            FormOrcamentos formOrcamentos = new FormOrcamentos();
            formOrcamentos.ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {

        }
    }
}
