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
            TipoArtigoController.MostrarTiposArtigos(dataGridView1);
        }

        private void btnExibirTodos_Click(object sender, EventArgs e)
        {
            // Carrega e exibe todos os tipos de artigos
            TipoArtigoController.MostrarTiposArtigos(dataGridView1);
            TipoArtigoController.LimparCampos(textBoxID, textBoxTipoArtigo, textBoxDescricao);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Obtém os dados da linha selecionada
            Dictionary<string, string> dados = TipoArtigoController.ObterDadosLinhaSelecionada(dataGridView1);

            // Se nenhuma linha estiver selecionada, sai do método
            if (dados == null)
                return;

            // Preenche os campos de texto com os dados da linha selecionada
            textBoxID.Text = dados["Id"];
            textBoxTipoArtigo.Text = dados["Nome"];
            textBoxDescricao.Text = dados["Descricao"];
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Obtém os valores dos campos
            string nome = textBoxTipoArtigo.Text.Trim();
            string descricao = textBoxDescricao.Text.Trim();

            // Chama o controlador para adicionar o tipo de artigo
            TipoArtigoController.AdicionarTipoArtigo(nome, descricao);

            // Recarrega os dados
            TipoArtigoController.MostrarTiposArtigos(dataGridView1);
            TipoArtigoController.LimparCampos(textBoxID, textBoxTipoArtigo, textBoxDescricao);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            // Obtém os valores dos campos
            string id = textBoxID.Text.Trim();
            string nome = textBoxTipoArtigo.Text.Trim();
            string descricao = textBoxDescricao.Text.Trim();

            // Valida se o ID foi preenchido
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Selecione um tipo de artigo para atualizar.");
                return;
            }

            // Chama o controlador para atualizar o tipo de artigo
            TipoArtigoController.AtualizarTipoArtigo(id, nome, descricao);

            // Recarrega os dados
            TipoArtigoController.MostrarTiposArtigos(dataGridView1);
            TipoArtigoController.LimparCampos(textBoxID, textBoxTipoArtigo, textBoxDescricao);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtém o ID do tipo de artigo
            string id = textBoxID.Text.Trim();

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
                TipoArtigoController.MostrarTiposArtigos(dataGridView1);
                TipoArtigoController.LimparCampos(textBoxID, textBoxTipoArtigo, textBoxDescricao);
            }
        }
    }
}