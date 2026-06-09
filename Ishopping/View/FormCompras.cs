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
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormCompras : Form
    {
        public FormCompras()
        {
            InitializeComponent();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            MostrarCompras();
        }

        private void MostrarCompras()
        {
            // Filtrar por estado selecionado no ComboBox
            bool? filtro = null;
            if (comboBoxFiltro.SelectedIndex == 1) filtro = true;  // Abertas
            if (comboBoxFiltro.SelectedIndex == 2) filtro = false; // Fechadas

            ComprasController.MostrarCompras(dataGridViewCompras, filtro);
            ComprasController.ConfigurarGrid(dataGridViewCompras);
        }

        // Botão Adicionar - cria nova compra
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeCompra.Text.Trim();
            int id = ComprasController.AdicionarCompra(nome);
            if (id > 0)
            {
                textBoxNomeCompra.Clear();
                textBoxID.Clear();
                MostrarCompras();
            }
        }

        // Botão Editar - abre formulário de edição
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxID.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("Selecione uma compra da lista.");
                return;
            }

            Compra compra = ComprasController.ObterCompraPorId(id);
            if (compra == null) { MessageBox.Show("Compra não encontrada."); return; }

            FormEditarCompra form = new FormEditarCompra(id);
            form.ShowDialog();
            MostrarCompras();
        }

        // Botão Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text.Trim();
            if (string.IsNullOrEmpty(id)) { MessageBox.Show("Selecione uma compra da lista."); return; }

            if (MessageBox.Show("Tem a certeza que pretende eliminar esta compra?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ComprasController.EliminarCompra(id);
                textBoxID.Clear();
                textBoxNomeCompra.Clear();
                MostrarCompras();
            }
        }

        // Botão Modo Compra - abre formulário de modo compra
        private void btnModoCompra_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxID.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("Selecione uma compra da lista.");
                return;
            }

            Compra compra = ComprasController.ObterCompraPorId(id);
            if (compra == null) { MessageBox.Show("Compra não encontrada."); return; }
            if (compra.Fechada) { MessageBox.Show("Esta compra já está fechada."); return; }

            FormModoCompra form = new FormModoCompra(id);
            form.ShowDialog();
            MostrarCompras();
        }

        // Exportar CSV
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ComprasController.ExportarCSV();
        }

       
        private void comboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCompras();
        }

        // Selecionar linha na grid
        private void dataGridViewCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCompras.SelectedRows.Count > 0)
            {
                var linha = dataGridViewCompras.SelectedRows[0];
                textBoxID.Text = linha.Cells["Id"].Value?.ToString() ?? "";
                textBoxNomeCompra.Text = linha.Cells["NomeCompra"].Value?.ToString() ?? "";
            }
        }
    }
}
