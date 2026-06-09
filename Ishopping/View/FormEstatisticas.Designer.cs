namespace Ishopping.View
{
    partial class FormEstatisticas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridHistoricoOrcamento = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.gridComprasFechadas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSugestaoValor = new System.Windows.Forms.Label();
            this.lblMediaValor = new System.Windows.Forms.Label();
            this.btnGerarSugestao = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistoricoOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprasFechadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(267, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estatísticas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Histórico de Orçamento vs Total Gasto:";
            // 
            // gridHistoricoOrcamento
            // 
            this.gridHistoricoOrcamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistoricoOrcamento.Location = new System.Drawing.Point(67, 79);
            this.gridHistoricoOrcamento.Name = "gridHistoricoOrcamento";
            this.gridHistoricoOrcamento.RowHeadersWidth = 51;
            this.gridHistoricoOrcamento.Size = new System.Drawing.Size(596, 146);
            this.gridHistoricoOrcamento.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Compras Fechadas — % Previstos / Não Previstos:";
            // 
            // gridComprasFechadas
            // 
            this.gridComprasFechadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComprasFechadas.Location = new System.Drawing.Point(67, 262);
            this.gridComprasFechadas.Name = "gridComprasFechadas";
            this.gridComprasFechadas.RowHeadersWidth = 51;
            this.gridComprasFechadas.Size = new System.Drawing.Size(596, 130);
            this.gridComprasFechadas.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 406);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Orçamento Sugestão:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 436);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sugestão:";
            // 
            // lblSugestaoValor
            // 
            this.lblSugestaoValor.AutoSize = true;
            this.lblSugestaoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugestaoValor.Location = new System.Drawing.Point(270, 436);
            this.lblSugestaoValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSugestaoValor.Name = "lblSugestaoValor";
            this.lblSugestaoValor.Size = new System.Drawing.Size(12, 15);
            this.lblSugestaoValor.TabIndex = 8;
            this.lblSugestaoValor.Text = "-";
            // 
            // lblMediaValor
            // 
            this.lblMediaValor.AutoSize = true;
            this.lblMediaValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaValor.Location = new System.Drawing.Point(218, 457);
            this.lblMediaValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMediaValor.Name = "lblMediaValor";
            this.lblMediaValor.Size = new System.Drawing.Size(11, 15);
            this.lblMediaValor.TabIndex = 9;
            this.lblMediaValor.Text = "-";
            // 
            // btnGerarSugestao
            // 
            this.btnGerarSugestao.Location = new System.Drawing.Point(67, 432);
            this.btnGerarSugestao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGerarSugestao.Name = "btnGerarSugestao";
            this.btnGerarSugestao.Size = new System.Drawing.Size(136, 21);
            this.btnGerarSugestao.TabIndex = 6;
            this.btnGerarSugestao.Text = "Gerar Sugestão";
            this.btnGerarSugestao.UseVisualStyleBackColor = true;
            this.btnGerarSugestao.Click += new System.EventHandler(this.btnGerarSugestao_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(527, 485);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(136, 21);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridHistoricoOrcamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridComprasFechadas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGerarSugestao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSugestaoValor);
            this.Controls.Add(this.lblMediaValor);
            this.Controls.Add(this.btnFechar);
            this.Name = "FormEstatisticas";
            this.Text = "FormEstatisticas";
            this.Load += new System.EventHandler(this.FormEstatisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistoricoOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprasFechadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridHistoricoOrcamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridComprasFechadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSugestaoValor;
        private System.Windows.Forms.Label lblMediaValor;
        private System.Windows.Forms.Button btnGerarSugestao;
        private System.Windows.Forms.Button btnFechar;
    }
}