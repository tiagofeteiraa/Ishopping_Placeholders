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
            MostrarComprasEmAberto();
        }

        private void MostrarComprasEmAberto()
        {
            ComprasController.MostrarCompras(dataGridViewComprasAberto, false);
            ComprasController.ConfigurarGrid(dataGridViewComprasAberto);
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
            FormGestaoArtigos formTiposArtigo = new FormGestaoArtigos();
            formTiposArtigo.ShowDialog();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            FormOrcamentos formOrcamentos = new FormOrcamentos();
            formOrcamentos.ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormCompras formCompras = new FormCompras();
            formCompras.ShowDialog();
            MostrarComprasEmAberto();
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            FormEstatisticas formEstatisticas = new FormEstatisticas();
            formEstatisticas.ShowDialog();
        }

        // Duplo clique na lista de compras abre o Modo Compra
        private void dataGridViewComprasAberto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var idVal = dataGridViewComprasAberto.Rows[e.RowIndex].Cells["Id"].Value;
            if (idVal == null) return;

            int id = (int)idVal;
            FormModoCompra form = new FormModoCompra(id);
            form.ShowDialog();
            MostrarComprasEmAberto();
        }
    }
}
