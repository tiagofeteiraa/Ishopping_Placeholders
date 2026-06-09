using Ishopping.Controller;
using Ishopping.Model;
using System;
using System.Windows.Forms;

namespace Ishopping.View
{
    // Formulário de estatísticas com dois separadores: histórico/percentagens e sugestões
    public partial class FormEstatisticas : Form
    {
        public FormEstatisticas()
        {
            InitializeComponent();
        }

        // Quando o formulário abre, carrega logo os dados do primeiro separador
        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            CarregarDadosPrimeiroSeparador();
        }

        // Carrega o histórico de orçamentos e as percentagens de compras fechadas nas respetivas grids
        private void CarregarDadosPrimeiroSeparador()
        {
            EstatisticasController.CarregarHistoricoOrcamentosNaGrid(gridHistoricoOrcamento);
            EstatisticasController.CarregarPercentagensComprasFechadasNaGrid(gridComprasFechadas);
        }

        // Clique no botão "Gerar Sugestão": calcula e mostra a sugestão de orçamento para o próximo mês
        private void btnGerarSugestao_Click(object sender, EventArgs e)
        {
            // Limpa os valores anteriores antes de gerar uma nova sugestão
            LimparCamposSugestao();

            string mensagem;
            SugestaoOrcamento sugestao =
                EstatisticasController.CalcularSugestaoOrcamentoProximoMes(out mensagem);

            // Mostra mensagem de sucesso ou aviso consoante o resultado
            MessageBox.Show(mensagem, "Sugestão de Orçamento",
                            MessageBoxButtons.OK,
                            sugestao != null ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            // Se não foi possível calcular a sugestão, não há nada a mostrar
            if (sugestao == null) return;

            // Preenche os campos com os valores calculados
            PreencherCamposSugestao(sugestao);
        }

        // Preenche os labels com o valor sugerido e a média calculada
        private void PreencherCamposSugestao(SugestaoOrcamento sugestao)
        {
            lblValorSugerido.Text = sugestao.SugestaoProximoMes.ToString("F2") + " €";
            lblMediaValor.Text = "Média dos últimos meses (máx. 6):\n"
                                  + sugestao.MediaUltimosMeses.ToString("F2") + " €";
        }

        // Limpa os labels da sugestão para não ficarem valores desatualizados visíveis
        private void LimparCamposSugestao()
        {
            lblValorSugerido.Text = string.Empty;
            lblMediaValor.Text = string.Empty;
        }

        // Fecha o formulário de estatísticas
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}