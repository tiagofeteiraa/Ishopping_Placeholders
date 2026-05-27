using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ishopping.Controller;
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormArtigos : Form
    {
        public FormArtigos()
        {
            InitializeComponent();
            this.Load += FormArtigos_Load;
            this.dataGridViewArtigos.SelectionChanged += DataGridViewArtigos_SelectionChanged;
        }

        private void FormArtigos_Load(object sender, EventArgs e)
        {
            Carregar();
            ConfigurarGrid();
        }

        private void Carregar()
        {
            try
            {
                dataGridViewArtigos.DataSource = ArtigosController.ObterArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar artigos: " + ex.Message);
            }
        }

        private void ConfigurarGrid()
        {
            dataGridViewArtigos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewArtigos.MultiSelect = false;

            if (dataGridViewArtigos.ColumnCount == 0)
                return;

            dataGridViewArtigos.Columns["Id"].Width = 50;
            dataGridViewArtigos.Columns["Nome"].Width = 300;
            dataGridViewArtigos.Columns["Preco"].Width = 100;
            dataGridViewArtigos.Columns["IdTipoArtigo"].Width = 50;
            dataGridViewArtigos.Columns["ItensCompra"].Width = 50;
        }

        private void DataGridViewArtigos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewArtigos.SelectedRows.Count == 0)
                return;

            var linha = dataGridViewArtigos.SelectedRows[0];
            textBoxID.Text = linha.Cells["Id"].Value.ToString();
            textBoxNomeArtigo.Text = linha.Cells["Nome"].Value.ToString();
            textBoxPreco.Text = linha.Cells["Preco"].Value.ToString();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (ArtigosController.AdicionarArtigo(textBoxNomeArtigo.Text, ObterPreco(), out var msg))
            {
                MessageBox.Show(msg);
                LimparCampos();
                Carregar();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxID.Text, out int id))
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            if (!ValidarCampos())
                return;

            if (ArtigosController.AtualizarArtigo(id, textBoxNomeArtigo.Text, ObterPreco(), out var msg))
            {
                MessageBox.Show(msg);
                LimparCampos();
                Carregar();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxID.Text, out int id))
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            if (MessageBox.Show("Eliminar este artigo?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (ArtigosController.EliminarArtigo(id, out var msg))
            {
                MessageBox.Show(msg);
                LimparCampos();
                Carregar();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("Indique o nome do artigo.");
                return false;
            }

            if (!decimal.TryParse(textBoxPreco.Text, out _))
            {
                MessageBox.Show("Indique um preço válido.");
                return false;
            }

            return true;
        }

        private decimal ObterPreco()
        {
            decimal.TryParse(textBoxPreco.Text, out decimal preco);
            return preco;
        }

        private void LimparCampos()
        {
            textBoxID.Clear();
            textBoxNomeArtigo.Clear();
            textBoxPreco.Clear();
        }

        private void dataGridViewArtigos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FormArtigos_Load_1(object sender, EventArgs e)
        {

        }
    }
}