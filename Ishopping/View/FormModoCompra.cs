using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ishopping.Controller;
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormModoCompra : Form
    {
        private int _idCompra;

        public FormModoCompra(int idCompra)
        {
            InitializeComponent();
            _idCompra = idCompra;
        }

        private void FormModoCompra_Load(object sender, EventArgs e)
        {
            CarregarCompra();
            AtualizarOrcamento();
            MostrarItensPrevistos();
            MostrarItensNaoPrevistos();
        }

        private void CarregarCompra()
        {
            Compra compra = ComprasController.ObterCompraPorId(_idCompra);
            if (compra == null) { this.Close(); return; }
            labelNomeCompra.Text = "Compra: " + compra.NomeCompra;
            labelDataCriacao.Text = "Criada: " + compra.DataCriacao.ToString("dd/MM/yyyy HH:mm");
        }

        private void AtualizarOrcamento()
        {
            decimal disponivel = ComprasController.ObterOrcamentoDisponivel();
            decimal maximo = ComprasController.ObterOrcamentoMaximo();

            // Calcular total desta compra
            decimal totalCompra = 0;
            var itensPrev = ItemPrevistosController.ObterItensPrevisos(_idCompra);
            foreach (var i in itensPrev)
                totalCompra += i.QuantidadeAdquirida * i.PrecoUnitario;

            var itensNP = ItemNaoPrevistosController.ObterItensNaoPrevistos(_idCompra);
            foreach (var i in itensNP)
                totalCompra += i.QuantidadeAdquirida * i.PrecoUnitario;

            labelTotalCompra.Text = "Total desta compra: " + totalCompra.ToString("C");

            if (maximo < 0)
            {
                labelOrcamento.Text = "Sem orçamento definido para este mês";
                labelOrcamento.ForeColor = Color.Gray;
                labelAlerta.Visible = false;
            }
            else
            {
                labelOrcamento.Text = $"Orçamento disponível: {disponivel:C} / {maximo:C}";
                if (disponivel < 0)
                {
                    labelOrcamento.ForeColor = Color.Red;
                    labelAlerta.Visible = true;
                    labelAlerta.Text = "ORÇAMENTO ULTRAPASSADO!";
                }
                else
                {
                    labelOrcamento.ForeColor = Color.DarkGreen;
                    labelAlerta.Visible = false;
                }
            }
        }

        private void MostrarItensPrevistos()
        {
            var itens = ItemPrevistosController.ObterItensPrevisos(_idCompra);
            var lista = itens.ConvertAll(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                QtdPrevista = i.quantidadePrevista,
                i.QuantidadeAdquirida,
                i.PrecoUnitario,
                Total = i.QuantidadeAdquirida * i.PrecoUnitario
            });

            dataGridViewPrevistos.DataSource = lista;
            dataGridViewPrevistos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPrevistos.MultiSelect = false;
        }

        private void MostrarItensNaoPrevistos()
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

            dataGridViewNaoPrevistos.DataSource = lista;
            dataGridViewNaoPrevistos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNaoPrevistos.MultiSelect = false;
        }

        // Selecionar item previsto -> preencher campos de aquisição
        private void dataGridViewPrevistos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPrevistos.SelectedRows.Count > 0)
            {
                var linha = dataGridViewPrevistos.SelectedRows[0];
                textBoxQtdAdquirida.Text = linha.Cells["QuantidadeAdquirida"].Value?.ToString() ?? "0";
                textBoxPrecoUnitario.Text = linha.Cells["PrecoUnitario"].Value?.ToString() ?? "0";
            }
        }

        // Marcar item previsto como adquirido (usa ItemPrevistosController)
        private void btnMarcarAdquirido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrevistos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item da lista.");
                return;
            }

            var idItem = dataGridViewPrevistos.SelectedRows[0].Cells["Id"].Value;
            if (idItem == null) return;

            if (!decimal.TryParse(textBoxQtdAdquirida.Text.Trim(), out decimal qtd) || qtd <= 0)
            {
                MessageBox.Show("Indique uma quantidade válida.");
                return;
            }
            if (!decimal.TryParse(textBoxPrecoUnitario.Text.Trim(), out decimal preco) || preco < 0)
            {
                MessageBox.Show("Indique um preço válido.");
                return;
            }

            bool ok = ItemPrevistosController.AtualizarItemAdquirido((int)idItem, qtd, preco, out string msg);
            MessageBox.Show(msg);
            if (ok)
            {
                MostrarItensPrevistos();
                AtualizarOrcamento();
                textBoxQtdAdquirida.Clear();
                textBoxPrecoUnitario.Clear();
            }
        }

        // Abre formulário dedicado para adicionar itens não previstos
        private void btnAdicionarNP_Click(object sender, EventArgs e)
        {
            FormAdicionarItemNaoPrevisto form = new FormAdicionarItemNaoPrevisto(_idCompra);
            form.ShowDialog();
            MostrarItensNaoPrevistos();
            AtualizarOrcamento();
        }

        // Fechar compra
        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que pretende fechar esta compra?\nNão poderá ser alterada depois.",
                "Confirmar Fecho", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ComprasController.FecharCompra(_idCompra);
                this.Close();
            }
        }
    }
}
