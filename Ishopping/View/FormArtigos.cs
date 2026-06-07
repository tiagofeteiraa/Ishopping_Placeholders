using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ishopping.Controller;
using Ishopping.Model;

namespace Ishopping.View
{
    public partial class FormArtigos : Form
    {
        // Construtor do formulário
        public FormArtigos()
        {
            InitializeComponent();
        }

        // Evento que ocorre quando o formulário é carregado
        private void FormArtigos_Load(object sender, EventArgs e)
        {
            ArtigosController.MostrarArtigos(dataGridViewArtigos);
            ArtigosController.ConfigurarGrid(dataGridViewArtigos);
            ArtigosController.CarregarTiposArtigos(comboBoxTipoArtigo);
            // Subscreve o evento de mudança de visibilidade do formulário
            this.VisibleChanged += FormArtigos_VisibleChanged;
        }

        // Evento que se dispara quando a visibilidade do formulário muda
        private void FormArtigos_VisibleChanged(object sender, EventArgs e)
        {
            // Se o formulário ficar visível, atualiza a lista de artigos e limpa os campos
            if (this.Visible)
            {
                ArtigosController.MostrarArtigos(dataGridViewArtigos);
                ArtigosController.CarregarTiposArtigos(comboBoxTipoArtigo);
                ArtigosController.LimparCampos(textBoxID, textBoxNomeArtigo, textBoxPreco, comboBoxTipoArtigo);
            }
        }

        // Evento que ocorre quando a seleção da linha na tabela muda
        private void DataGridViewArtigos_SelectionChanged(object sender, EventArgs e)
        {
            // Obtém os dados da linha selecionada
            Dictionary<string, string> dados = ArtigosController.ObterDadosLinhaSelecionada(dataGridViewArtigos);

            // Se nenhuma linha estiver selecionada, sai do método
            if (dados == null)
                return;

            // Preenche os campos de texto com os dados da linha selecionada
            textBoxID.Text = dados["Id"];
            textBoxNomeArtigo.Text = dados["Nome"];
            textBoxPreco.Text = dados["Preco"];

            // Preenche o comboBox com o tipo de artigo da linha selecionada
            if (int.TryParse(dados["Id"], out int idArtigo))
            {
                Artigo artigo = ArtigosController.ObterArtigoPorId(idArtigo);
                if (artigo != null)
                {
                    comboBoxTipoArtigo.SelectedValue = artigo.IdTipoArtigo;
                }
            }
        }

        // Evento do botão Adicionar - cria um novo artigo
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeArtigo.Text.Trim();
            string preco = textBoxPreco.Text.Trim();
            int idTipoArtigo = comboBoxTipoArtigo.SelectedIndex >= 0 ? (int)comboBoxTipoArtigo.SelectedValue : -1;

            if (idTipoArtigo == -1)
            {
                MessageBox.Show("Por favor, selecione um tipo de artigo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ArtigosController.AdicionarArtigo(nome, preco, idTipoArtigo);
            ArtigosController.MostrarArtigos(dataGridViewArtigos);
            ArtigosController.LimparCampos(textBoxID, textBoxNomeArtigo, textBoxPreco, comboBoxTipoArtigo);
        }

        // Evento do botão Atualizar 
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            // Obtém o ID, nome e preço dos campos de texto, removendo espaços desnecessários
            string id = textBoxID.Text.Trim();
            string nome = textBoxNomeArtigo.Text.Trim();
            string preco = textBoxPreco.Text.Trim();
            int idTipoArtigo = comboBoxTipoArtigo.SelectedIndex >= 0 ? (int)comboBoxTipoArtigo.SelectedValue : -1;

            // Envia os dados para o controlador atualizar o artigo
            ArtigosController.AtualizarArtigo(id, nome, preco, idTipoArtigo);
            // Atualiza a tabela e limpa os campos
            ArtigosController.MostrarArtigos(dataGridViewArtigos);
            ArtigosController.LimparCampos(textBoxID, textBoxNomeArtigo, textBoxPreco, comboBoxTipoArtigo);
        }

        // Evento do botão Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtém o ID do artigo a eliminar
            string id = textBoxID.Text.Trim();

            // Mostra uma janela de confirmação
            DialogResult resultado = MessageBox.Show("Tem a certeza que deseja eliminar este artigo?", "Confirmação", MessageBoxButtons.YesNo);
            // Se o utilizador confirmar, elimina o artigo
            if (resultado == DialogResult.Yes)
            {
                ArtigosController.EliminarArtigo(id);
                // Atualiza a tabela e limpa os campos
                ArtigosController.MostrarArtigos(dataGridViewArtigos);
                ArtigosController.LimparCampos(textBoxID, textBoxNomeArtigo, textBoxPreco, comboBoxTipoArtigo);
            }
        }
    }
}