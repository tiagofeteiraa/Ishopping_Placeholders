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
            MostrarArtigos();
            ConfigurarGrid();
            // Subscreve o evento de mudança de visibilidade do formulário
            this.VisibleChanged += FormArtigos_VisibleChanged;
        }

        // Evento que se dispara quando a visibilidade do formulário muda
        private void FormArtigos_VisibleChanged(object sender, EventArgs e)
        {
            // Se o formulário ficar visível, atualiza a lista de artigos e limpa os campos
            if (this.Visible)
            {
                MostrarArtigos();
                LimparCampos();
            }
        }

        // Carrega e mostra todos os artigos na tabela
        private void MostrarArtigos()
        {
            ArtigosController.MostrarArtigos(dataGridViewArtigos);
        }

        // Configura as propriedades da tabela de artigos
        private void ConfigurarGrid()
        {
            // Define o modo de seleção para seleccionar a linha inteira
            dataGridViewArtigos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Desativa a possibilidade de seleccionar múltiplas linhas
            dataGridViewArtigos.MultiSelect = false;

            // Verifica se a tabela tem colunas
            if (dataGridViewArtigos.ColumnCount == 0)
                return;

            // Define a largura de cada coluna
            dataGridViewArtigos.Columns["Id"].Width = 100;
            dataGridViewArtigos.Columns["Nome"].Width = 100;
            dataGridViewArtigos.Columns["Preco"].Width = 100;
        }

        // Limpa todos os campos de texto do formulário
        private void LimparCampos()
        {
            textBoxID.Clear();
            textBoxNomeArtigo.Clear();
            textBoxPreco.Clear();
        }

        // Evento que ocorre quando a seleção da linha na tabela muda
        private void DataGridViewArtigos_SelectionChanged(object sender, EventArgs e)
        {
            // Se nenhuma linha estiver selecionada, sai do método
            if (dataGridViewArtigos.SelectedRows.Count == 0)
                return;

            // Obtém a linha selecionada
            var linha = dataGridViewArtigos.SelectedRows[0];
            // Preenche os campos de texto com os dados da linha selecionada
            textBoxID.Text = linha.Cells["Id"].Value.ToString();
            textBoxNomeArtigo.Text = linha.Cells["Nome"].Value.ToString();
            textBoxPreco.Text = linha.Cells["Preco"].Value.ToString();
        }

        // Evento do botão Adicionar - cria um novo artigo
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Obtém o nome e preço dos campos de texto, removendo espaços desnecessários
            string nome = textBoxNomeArtigo.Text.Trim();
            string preco = textBoxPreco.Text.Trim();

            // Envia os dados para o controlador adicionar o artigo
            ArtigosController.AdicionarArtigo(nome, preco);
            // Atualiza a tabela e limpa os campos
            MostrarArtigos();
            LimparCampos();
        }

        // Evento do botão Atualizar - modifica um artigo existente
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            // Obtém o ID, nome e preço dos campos de texto, removendo espaços desnecessários
            string id = textBoxID.Text.Trim();
            string nome = textBoxNomeArtigo.Text.Trim();
            string preco = textBoxPreco.Text.Trim();

            // Envia os dados para o controlador atualizar o artigo
            ArtigosController.AtualizarArtigo(id, nome, preco);
            // Atualiza a tabela e limpa os campos
            MostrarArtigos();
            LimparCampos();
        }

        // Evento do botão Eliminar - remove um artigo existente
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
                MostrarArtigos();
                LimparCampos();
            }
        }

            }
        }