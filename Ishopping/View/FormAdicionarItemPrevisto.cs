using System;
using System.Windows.Forms;
using Ishopping.Controller;
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormAdicionarItemPrevisto : Form
    {
        // Armazena o ID da compra para a qual os itens previstos estão sendo geridos
        private readonly int _idCompra;

        public FormAdicionarItemPrevisto(int idCompra)
        {
            InitializeComponent();
            _idCompra = idCompra;
        }

        // Carrega os tipos de artigos e os itens previstos para a compra ao abrir o formulário
        private void FormAdicionarItemPrevisto_Load(object sender, EventArgs e)
        {
            ArtigosController.CarregarTiposArtigos(comboBoxTipoArtigo);
            MostrarItens();
        }

        private void MostrarItens()
        {
            // Obtém os itens previstos para a compra e exibe na DataGridView
            var itens = ItemPrevistosController.ObterItensPrevisos(_idCompra);
            var lista = itens.ConvertAll(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                QuantidadePrevista = i.quantidadePrevista,
                i.QuantidadeAdquirida,
                i.PrecoUnitario,
                Total = i.QuantidadeAdquirida * i.PrecoUnitario
            });

            dataGridViewItens.DataSource = lista;
            dataGridViewItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewItens.MultiSelect = false;
        }

        // Carrega os artigos correspondentes ao tipo selecionado
        private void comboBoxTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBoxTipoArtigo.SelectedValue is int idTipo && idTipo > 0)
                ItemPrevistosController.CarregarArtigosPorTipo(idTipo, comboBoxArtigo);
        }

        private void comboBoxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        // Botão para adicionar um novo item previsto
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Validações 
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
            // Obtém o ID do artigo selecionado
            int idArtigo = (int)comboBoxArtigo.SelectedValue;
            bool ok = ItemPrevistosController.AdicionarItemPrevisto(_idCompra, idArtigo, qtd, out string msg);
            MessageBox.Show(msg);
            if (ok)
            {
                MostrarItens();
                comboBoxArtigo.SelectedIndex = -1;
                textBoxQuantidade.Clear();
            }
        }

        // Botão para remover um item previsto selecionado
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item da lista.");
                return;
            }

            // Obtém o ID do item previsto selecionado
            var idItem = dataGridViewItens.SelectedRows[0].Cells["Id"].Value;
            if (idItem == null) return;

            // Confirmação antes de remover
            if (MessageBox.Show("Remover este item previsto?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ItemPrevistosController.RemoverItemPrevisto((int)idItem, out string msg);
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
