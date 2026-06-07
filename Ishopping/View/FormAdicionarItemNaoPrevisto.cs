using System;
using System.Windows.Forms;
using Ishopping.Controller;
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormAdicionarItemNaoPrevisto : Form
    {
        private readonly int _idCompra;

        public FormAdicionarItemNaoPrevisto(int idCompra)
        {
            InitializeComponent();
            _idCompra = idCompra;
        }

        private void FormAdicionarItemNaoPrevisto_Load(object sender, EventArgs e)
        {
            ArtigosController.CarregarTiposArtigos(comboBoxTipoArtigo);
            MostrarItens();
        }

        private void MostrarItens()
        {
            var itens = ItemNaoPrevistosController.ObterItensNaoPrevistos(_idCompra);
            var lista = itens.ConvertAll(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                i.QuantidadeAdquirida,
                i.PrecoUnitario,
                Total = i.QuantidadeAdquirida * i.PrecoUnitario,
                i.Observacoes
            });

            dataGridViewItens.DataSource = lista;
            dataGridViewItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewItens.MultiSelect = false;
        }

        private void comboBoxTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoArtigo.SelectedValue is int idTipo && idTipo > 0)
                ItemNaoPrevistosController.CarregarArtigosPorTipo(idTipo, comboBoxArtigo);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (comboBoxArtigo.SelectedValue == null)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }
            if (!decimal.TryParse(textBoxQuantidade.Text.Trim(), out decimal qtd) || qtd <= 0)
            {
                MessageBox.Show("Indique uma quantidade válida.");
                return;
            }
            if (!decimal.TryParse(textBoxPreco.Text.Trim(), out decimal preco) || preco < 0)
            {
                MessageBox.Show("Indique um preço válido.");
                return;
            }

            int idArtigo = (int)comboBoxArtigo.SelectedValue;
            string obs = textBoxObservacoes.Text.Trim();

            bool ok = ItemNaoPrevistosController.AdicionarItemNaoPrevisto(
                _idCompra, idArtigo, qtd, preco, obs, out string msg);
            MessageBox.Show(msg);
            if (ok)
            {
                MostrarItens();
                comboBoxArtigo.SelectedIndex = -1;
                textBoxQuantidade.Clear();
                textBoxPreco.Clear();
                textBoxObservacoes.Clear();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item da lista.");
                return;
            }

            var idItem = dataGridViewItens.SelectedRows[0].Cells["Id"].Value;
            if (idItem == null) return;

            if (MessageBox.Show("Remover este item não previsto?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ItemNaoPrevistosController.RemoverItemNaoPrevisto((int)idItem, out string msg);
                MessageBox.Show(msg);
                MostrarItens();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
