namespace Ishopping.View
{
    partial class FormAdicionarItemNaoPrevisto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxTipoArtigo = new System.Windows.Forms.ComboBox();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.textBoxPreco = new System.Windows.Forms.TextBox();
            this.textBoxObservacoes = new System.Windows.Forms.TextBox();
            this.dataGridViewItens = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItens)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Text = "Tipo de Artigo:";

            // comboBoxTipoArtigo
            this.comboBoxTipoArtigo.Location = new System.Drawing.Point(120, 12);
            this.comboBoxTipoArtigo.Size = new System.Drawing.Size(200, 21);
            this.comboBoxTipoArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoArtigo_SelectedIndexChanged);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Text = "Artigo:";

            // comboBoxArtigo
            this.comboBoxArtigo.Location = new System.Drawing.Point(120, 42);
            this.comboBoxArtigo.Size = new System.Drawing.Size(200, 21);
            this.comboBoxArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Text = "Qtd. Adquirida:";

            // textBoxQuantidade
            this.textBoxQuantidade.Location = new System.Drawing.Point(120, 72);
            this.textBoxQuantidade.Size = new System.Drawing.Size(80, 20);

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Text = "Preço Unitário:";

            // textBoxPreco
            this.textBoxPreco.Location = new System.Drawing.Point(120, 102);
            this.textBoxPreco.Size = new System.Drawing.Size(80, 20);

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Text = "Observações:";

            // textBoxObservacoes
            this.textBoxObservacoes.Location = new System.Drawing.Point(120, 132);
            this.textBoxObservacoes.Size = new System.Drawing.Size(200, 20);

            // btnAdicionar
            this.btnAdicionar.Location = new System.Drawing.Point(330, 128);
            this.btnAdicionar.Size = new System.Drawing.Size(120, 26);
            this.btnAdicionar.Text = "Adicionar Item";
            this.btnAdicionar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

            // dataGridViewItens
            this.dataGridViewItens.Location = new System.Drawing.Point(12, 170);
            this.dataGridViewItens.Size = new System.Drawing.Size(560, 230);
            this.dataGridViewItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItens.ReadOnly = true;
            this.dataGridViewItens.AllowUserToAddRows = false;

            // btnRemover
            this.btnRemover.Location = new System.Drawing.Point(12, 410);
            this.btnRemover.Size = new System.Drawing.Size(110, 30);
            this.btnRemover.Text = "Remover Item";
            this.btnRemover.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemover.ForeColor = System.Drawing.Color.White;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);

            // btnFechar
            this.btnFechar.Location = new System.Drawing.Point(460, 410);
            this.btnFechar.Size = new System.Drawing.Size(112, 30);
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoArtigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPreco);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxObservacoes);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dataGridViewItens);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnFechar);
            this.Text = "Adicionar Itens Não Previstos";
            this.Load += new System.EventHandler(this.FormAdicionarItemNaoPrevisto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxTipoArtigo;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.TextBox textBoxPreco;
        private System.Windows.Forms.TextBox textBoxObservacoes;
        private System.Windows.Forms.DataGridView dataGridViewItens;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
