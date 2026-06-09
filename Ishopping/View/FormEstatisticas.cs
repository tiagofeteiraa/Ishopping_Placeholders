using Ishopping.Controller;
using Ishopping.Model;
using System;
using System.Windows.Forms;

namespace Ishopping.View
{
    public partial class FormEstatisticas : Form
    {
        // DataGridView para apresentar o histórico de orçamentos
        public static DataGridView historicoOrcamentos;

        // DataGridView para apresentar as estatísticas dos artigos
        public static DataGridView listagemPercentagem;

        public FormEstatisticas()
        {
            InitializeComponent();

            // Atribuir as DataGridViews às variáveis estáticas para acesso global
            historicoOrcamentos = gridHistoricoOrcamento;
            // Atribuir a DataGridView para as estatísticas dos artigos
            listagemPercentagem = gridComprasFechadas;
        }

        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            // Carregar histórico de orçamentos
            EstatisticasController.MostrarHistoricoOrcamento();

            // carregar estatísticas dos artigos
            EstatisticasController.MostrarEstatisticasArtigos();
        }

        private void btnGerarSugestao_Click(object sender, EventArgs e)
        {
            string mensagem;

            // sugestão de orçamento últimos 6 meses
            SugestaoOrcamento sugestao = EstatisticasController.SugerirOrcamento(out mensagem);

            // Exibe a mensagem de sugestão
            MessageBox.Show(mensagem);

            if (sugestao == null) return;

            // Exibe a sugestão de orçamento para o próximo mês e a média dos últimos meses
            lblSugestaoValor.Text = sugestao.SugestaoProximoMes.ToString("F2") + " €";
            // Exibe a média dos últimos meses (baseado até aos últimos 6)
            lblMediaValor.Text = "Média dos últimos meses (baseado até aos últimos 6):\n" +
                                 sugestao.MediaUltimosMeses.ToString("F2") + " €";
        }
        // Botão para fechar o formulário
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}