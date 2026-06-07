namespace Ishopping.View
{
    partial class FormModoCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelNomeCompra = new System.Windows.Forms.Label();
            this.labelDataCriacao = new System.Windows.Forms.Label();
            this.labelOrcamento = new System.Windows.Forms.Label();
            this.labelAlerta = new System.Windows.Forms.Label();
            this.labelTotalCompra = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewPrevistos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxQtdAdquirida = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPrecoUnitario = new System.Windows.Forms.TextBox();
            this.btnMarcarAdquirido = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewNaoPrevistos = new System.Windows.Forms.DataGridView();
            this.btnAdicionarNP = new System.Windows.Forms.Button();
            this.btnFecharCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrevistos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNaoPrevistos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(280, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modo Compra";
            // 
            // labelNomeCompra
            // 
            this.labelNomeCompra.AutoSize = true;
            this.labelNomeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeCompra.Location = new System.Drawing.Point(25, 60);
            this.labelNomeCompra.Name = "labelNomeCompra";
            this.labelNomeCompra.Size = new System.Drawing.Size(73, 18);
            this.labelNomeCompra.TabIndex = 1;
            this.labelNomeCompra.Text = "Compra:";
            // 
            // labelDataCriacao
            // 
            this.labelDataCriacao.AutoSize = true;
            this.labelDataCriacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataCriacao.Location = new System.Drawing.Point(25, 83);
            this.labelDataCriacao.Name = "labelDataCriacao";
            this.labelDataCriacao.Size = new System.Drawing.Size(46, 15);
            this.labelDataCriacao.TabIndex = 2;
            this.labelDataCriacao.Text = "Criada:";
            // 
            // labelOrcamento
            // 
            this.labelOrcamento.AutoSize = true;
            this.labelOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamento.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelOrcamento.Location = new System.Drawing.Point(500, 60);
            this.labelOrcamento.Name = "labelOrcamento";
            this.labelOrcamento.Size = new System.Drawing.Size(187, 17);
            this.labelOrcamento.TabIndex = 3;
            this.labelOrcamento.Text = "Orçamento disponível: --";
            // 
            // labelAlerta
            // 
            this.labelAlerta.AutoSize = true;
            this.labelAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlerta.ForeColor = System.Drawing.Color.Red;
            this.labelAlerta.Location = new System.Drawing.Point(500, 82);
            this.labelAlerta.Name = "labelAlerta";
            this.labelAlerta.Size = new System.Drawing.Size(273, 20);
            this.labelAlerta.TabIndex = 4;
            this.labelAlerta.Text = "ORÇAMENTO ULTRAPASSADO!";
            this.labelAlerta.Visible = false;
            // 
            // labelTotalCompra
            // 
            this.labelTotalCompra.AutoSize = true;
            this.labelTotalCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCompra.Location = new System.Drawing.Point(25, 105);
            this.labelTotalCompra.Name = "labelTotalCompra";
            this.labelTotalCompra.Size = new System.Drawing.Size(148, 17);
            this.labelTotalCompra.TabIndex = 5;
            this.labelTotalCompra.Text = "Total desta compra: --";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Itens Previstos:";
            // 
            // dataGridViewPrevistos
            // 
            this.dataGridViewPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrevistos.Location = new System.Drawing.Point(25, 153);
            this.dataGridViewPrevistos.Name = "dataGridViewPrevistos";
            this.dataGridViewPrevistos.RowHeadersWidth = 51;
            this.dataGridViewPrevistos.Size = new System.Drawing.Size(860, 180);
            this.dataGridViewPrevistos.TabIndex = 7;
            this.dataGridViewPrevistos.SelectionChanged += new System.EventHandler(this.dataGridViewPrevistos_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Qtd. Adquirida:";
            // 
            // textBoxQtdAdquirida
            // 
            this.textBoxQtdAdquirida.Location = new System.Drawing.Point(135, 342);
            this.textBoxQtdAdquirida.Name = "textBoxQtdAdquirida";
            this.textBoxQtdAdquirida.Size = new System.Drawing.Size(80, 20);
            this.textBoxQtdAdquirida.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(230, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Preço Unit.:";
            // 
            // textBoxPrecoUnitario
            // 
            this.textBoxPrecoUnitario.Location = new System.Drawing.Point(320, 342);
            this.textBoxPrecoUnitario.Name = "textBoxPrecoUnitario";
            this.textBoxPrecoUnitario.Size = new System.Drawing.Size(80, 20);
            this.textBoxPrecoUnitario.TabIndex = 11;
            // 
            // btnMarcarAdquirido
            // 
            this.btnMarcarAdquirido.Location = new System.Drawing.Point(700, 340);
            this.btnMarcarAdquirido.Name = "btnMarcarAdquirido";
            this.btnMarcarAdquirido.Size = new System.Drawing.Size(181, 23);
            this.btnMarcarAdquirido.TabIndex = 12;
            this.btnMarcarAdquirido.Text = "Marcar como Adquirido";
            this.btnMarcarAdquirido.UseVisualStyleBackColor = true;
            this.btnMarcarAdquirido.Click += new System.EventHandler(this.btnMarcarAdquirido_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Itens Não Previstos:";
            // 
            // dataGridViewNaoPrevistos
            // 
            this.dataGridViewNaoPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNaoPrevistos.Location = new System.Drawing.Point(25, 405);
            this.dataGridViewNaoPrevistos.Name = "dataGridViewNaoPrevistos";
            this.dataGridViewNaoPrevistos.RowHeadersWidth = 51;
            this.dataGridViewNaoPrevistos.Size = new System.Drawing.Size(860, 140);
            this.dataGridViewNaoPrevistos.TabIndex = 14;
            // 
            // btnAdicionarNP
            // 
            this.btnAdicionarNP.Location = new System.Drawing.Point(700, 555);
            this.btnAdicionarNP.Name = "btnAdicionarNP";
            this.btnAdicionarNP.Size = new System.Drawing.Size(181, 23);
            this.btnAdicionarNP.TabIndex = 25;
            this.btnAdicionarNP.Text = "Adicionar Não Previsto";
            this.btnAdicionarNP.UseVisualStyleBackColor = true;
            this.btnAdicionarNP.Click += new System.EventHandler(this.btnAdicionarNP_Click);
            // 
            // btnFecharCompra
            // 
            this.btnFecharCompra.BackColor = System.Drawing.Color.Transparent;
            this.btnFecharCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharCompra.ForeColor = System.Drawing.Color.Black;
            this.btnFecharCompra.Location = new System.Drawing.Point(700, 590);
            this.btnFecharCompra.Name = "btnFecharCompra";
            this.btnFecharCompra.Size = new System.Drawing.Size(181, 30);
            this.btnFecharCompra.TabIndex = 26;
            this.btnFecharCompra.Text = "Fechar Compra";
            this.btnFecharCompra.UseVisualStyleBackColor = false;
            this.btnFecharCompra.Click += new System.EventHandler(this.btnFecharCompra_Click);
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNomeCompra);
            this.Controls.Add(this.labelDataCriacao);
            this.Controls.Add(this.labelOrcamento);
            this.Controls.Add(this.labelAlerta);
            this.Controls.Add(this.labelTotalCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewPrevistos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxQtdAdquirida);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPrecoUnitario);
            this.Controls.Add(this.btnMarcarAdquirido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewNaoPrevistos);
            this.Controls.Add(this.btnAdicionarNP);
            this.Controls.Add(this.btnFecharCompra);
            this.Name = "FormModoCompra";
            this.Text = "Modo Compra";
            this.Load += new System.EventHandler(this.FormModoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrevistos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNaoPrevistos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNomeCompra;
        private System.Windows.Forms.Label labelDataCriacao;
        private System.Windows.Forms.Label labelOrcamento;
        private System.Windows.Forms.Label labelAlerta;
        private System.Windows.Forms.Label labelTotalCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewPrevistos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxQtdAdquirida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPrecoUnitario;
        private System.Windows.Forms.Button btnMarcarAdquirido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewNaoPrevistos;
        private System.Windows.Forms.Button btnAdicionarNP;
        private System.Windows.Forms.Button btnFecharCompra;
    }
}
