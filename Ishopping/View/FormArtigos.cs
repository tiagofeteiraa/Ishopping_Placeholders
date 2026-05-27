using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ishopping.View
{
    public partial class FormArtigos : Form
    {
        public FormArtigos()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = Application.OpenForms["FormPrincipal"] as FormPrincipal;
            if (formPrincipal != null)
            {
                formPrincipal.Show();
            }
            this.Close();
        }
    }
}
