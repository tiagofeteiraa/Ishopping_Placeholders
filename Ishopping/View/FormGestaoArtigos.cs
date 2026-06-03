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
    public partial class FormGestaoArtigos : Form
    {
        public FormGestaoArtigos()
        {
            InitializeComponent();
        }

        private void FormGestaoArtigos_Load(object sender, EventArgs e)
        {
            // Carrega todos os tipos de artigos quando o formulário abre
            CarregarTodosOsTipos();
        }

        // Carrega todos os tipos de artigos na grid
        private void CarregarTodosOsTipos()
        {
            TipoArtigoController.MostrarTiposArtigos(dataGridView1);
        }

        // Limpa os campos de entrada
        private void LimparCampos()
        {
            textBoxID.Clear();
            textBoxTipoArtigo.Clear();
            textBoxDescricao.Clear();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // Obtém o texto de pesquisa do campo de tipo de artigo
            string nomePesquisa = textBoxTipoArtigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomePesquisa))
            {
                MessageBox.Show("Indique um nome para pesquisar.");
                return;
            }

            // Pesquisa os tipos de artigos pelo nome
            List<Model.TipoArtigo> resultados = TipoArtigoController.PesquisarTipoArtigo(nomePesquisa);

            if (resultados.Count == 0)
            {
                MessageBox.Show("Nenhum tipo de artigo encontrado.");
                return;
            }

            // Mostra os resultados na grid
            dataGridView1.DataSource = resultados;
        }

        private void btnExibirTodos_Click(object sender, EventArgs e)
        {
            // Carrega e exibe todos os tipos de artigos
            CarregarTodosOsTipos();
            LimparCampos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Quando uma linha da grid é clicada, preenche os campos com os dados dessa linha
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGridView1.Rows[e.RowIndex];

                // Obtém os valores da linha
                if (linha.Cells["Id"].Value != null)
                {
                    textBoxID.Text = linha.Cells["Id"].Value.ToString();
                }

                if (linha.Cells["Nome"].Value != null)
                {
                    textBoxTipoArtigo.Text = linha.Cells["Nome"].Value.ToString();
                }

                if (linha.Cells["Descricao"].Value != null)
                {
                    textBoxDescricao.Text = linha.Cells["Descricao"].Value.ToString();
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Obtém os valores dos campos
            string nome = textBoxTipoArtigo.Text;
            string descricao = textBoxDescricao.Text;

            // Chama o controlador para adicionar o tipo de artigo
            TipoArtigoController.AdicionarTipoArtigo(nome, descricao);

            // Recarrega os dados
            CarregarTodosOsTipos();
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            // Obtém os valores dos campos
            string id = textBoxID.Text;
            string nome = textBoxTipoArtigo.Text;
            string descricao = textBoxDescricao.Text;

            // Valida se o ID foi preenchido
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Selecione um tipo de artigo para atualizar.");
                return;
            }

            // Chama o controlador para atualizar o tipo de artigo
            TipoArtigoController.AtualizarTipoArtigo(id, nome, descricao);

            // Recarrega os dados
            CarregarTodosOsTipos();
            LimparCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtém o ID do tipo de artigo
            string id = textBoxID.Text;

            // Valida se o ID foi preenchido
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Selecione um tipo de artigo para eliminar.");
                return;
            }

            // Pede confirmação antes de eliminar
            DialogResult resultado = MessageBox.Show("Tem a certeza que deseja eliminar este tipo de artigo?", 
                                                      "Confirmar Eliminação", 
                                                      MessageBoxButtons.YesNo, 
                                                      MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Chama o controlador para eliminar o tipo de artigo
                TipoArtigoController.EliminarTipoArtigo(id);

                // Recarrega os dados
                CarregarTodosOsTipos();
                LimparCampos();
            }
        }
    }
}
