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
    public partial class FormOrcamentos : Form
    {
        // Construtor do formulário
        public FormOrcamentos()
        {
            InitializeComponent();
        }

        // Evento que ocorre quando o formulário é carregado
        private void FormOrcamentos_Load(object sender, EventArgs e)
        {
            // Carrega e mostra todos os orçamentos na tabela
            MostrarOrcamentos();
        }

        // Carrega e mostra todos os orçamentos na tabela
        private void MostrarOrcamentos()
        {
            OrcamentosController.MostrarOrcamentos(dataGridViewOrcamentos);
        }

        // Evento do botão Adicionar - cria um novo orçamento
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Obtém o mês selecionado no combobox
            string mes = comboBoxMes.SelectedItem?.ToString();
            // Obtém o ano do campo de texto, removendo espaços desnecessários
            string ano = textBoxAno.Text.Trim();
            // Obtém o valor do campo de texto, removendo espaços desnecessários
            string valor = textBoxValorOrcamento.Text.Trim();

            // Envia os dados para o controlador adicionar o orçamento
            OrcamentosController.AdicionarOrcamento(mes, ano, valor);
            // Atualiza a tabela
            MostrarOrcamentos();
        }

        // Evento do botão Editar - modifica um orçamento existente
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtém o ID do orçamento a editar
            string id = textBoxID.Text.Trim();
            // Obtém o mês selecionado no combobox
            string mes = comboBoxMes.SelectedItem?.ToString();
            // Obtém o ano do campo de texto, removendo espaços desnecessários
            string ano = textBoxAno.Text.Trim();
            // Obtém o valor do campo de texto, removendo espaços desnecessários
            string valor = textBoxValorOrcamento.Text.Trim();

            // Envia os dados para o controlador atualizar o orçamento
            OrcamentosController.AtualizarOrcamento(id, mes, ano, valor);
            // Atualiza a tabela
            MostrarOrcamentos();
        }

        // Evento do botão Eliminar - remove um orçamento existente
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtém o ID do orçamento a eliminar
            string id = textBoxID.Text.Trim();
            // Envia o ID para o controlador eliminar o orçamento
            OrcamentosController.EliminarOrcamento(id);
            // Atualiza a tabela
            MostrarOrcamentos();
        }

        
        private void dataGridViewOrcamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}