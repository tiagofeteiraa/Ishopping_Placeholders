using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ishopping.Controller;
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormEditarCompra : Form
    {
        private int _idCompra;
        private bool _soLeitura;

        public FormEditarCompra(int idCompra)
        {
            InitializeComponent();
            _idCompra = idCompra;
        }

        private void FormEditarCompra_Load(object sender, EventArgs e)
        {
            Compra compra = ComprasController.ObterCompraPorId(_idCompra);
            if (compra == null) { this.Close(); return; }

            _soLeitura = compra.Fechada;

            textBoxNomeCompra.Text = compra.NomeCompra;
            labelEstado.Text = compra.Fechada ? "Fechada" : "Em Aberto";
            labelDataCriacao.Text = "Criada: " + compra.DataCriacao.ToString("dd/MM/yyyy HH:mm");

            if (_soLeitura)
            {
                textBoxNomeCompra.ReadOnly = true;
                btnGuardarNome.Enabled = false;
                btnGerarItensPrevistos.Enabled = false;
                btnAdicionarNaoPrevistos.Enabled = false;
            }

            MostrarItens();
        }

        private void MostrarItens()
        {
            // Mostrar itens previstos
            var previstos = ItemPrevistosController.ObterItensPrevisos(_idCompra);
            var listaP = previstos.ConvertAll(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                QuantidadePrevista = i.quantidadePrevista,
                i.QuantidadeAdquirida,
                i.PrecoUnitario,
                Total = i.QuantidadeAdquirida * i.PrecoUnitario,
                Tipo = "Previsto"
            });
            dataGridViewPrevistos.DataSource = listaP;
            dataGridViewPrevistos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPrevistos.MultiSelect = false;

            // Mostrar itens não previstos
            var naoPrevistos = ItemNaoPrevistosController.ObterItensNaoPrevistos(_idCompra);
            var listaNP = naoPrevistos.ConvertAll(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                i.QuantidadeAdquirida,
                i.PrecoUnitario,
                Total = i.QuantidadeAdquirida * i.PrecoUnitario,
                i.Observacoes
            });
            dataGridViewNaoPrevistos.DataSource = listaNP;
            dataGridViewNaoPrevistos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNaoPrevistos.MultiSelect = false;
        }

        private void btnGuardarNome_Click(object sender, EventArgs e)
        {
            ComprasController.AtualizarCompra(_idCompra, textBoxNomeCompra.Text);
        }

        // Abre o formulário dedicado para gerir itens previstos
        private void btnGerarItensPrevistos_Click(object sender, EventArgs e)
        {
            FormAdicionarItemPrevisto form = new FormAdicionarItemPrevisto(_idCompra);
            form.ShowDialog();
            MostrarItens();
        }

        // Abre o formulário dedicado para adicionar itens não previstos
        private void btnAdicionarNaoPrevistos_Click(object sender, EventArgs e)
        {
            FormAdicionarItemNaoPrevisto form = new FormAdicionarItemNaoPrevisto(_idCompra);
            form.ShowDialog();
            MostrarItens();
        }
    }
}
