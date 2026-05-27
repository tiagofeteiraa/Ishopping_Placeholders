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
            formArtigos.Show();
            this.Hide();
        }
    }
}
