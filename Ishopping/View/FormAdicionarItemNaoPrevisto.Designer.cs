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
            // 
            // comboBoxTipoArtigo
            // 
            this.comboBoxTipoArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoArtigo.Location = new System.Drawing.Point(120, 12);
            this.comboBoxTipoArtigo.Name = "comboBoxTipoArtigo";
            this.comboBoxTipoArtigo.Size = new System.Drawing.Size(200, 21);
            this.comboBoxTipoArtigo.TabIndex = 1;
            this.comboBoxTipoArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoArtigo_SelectedIndexChanged);
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArtigo.Location = new System.Drawing.Point(120, 42);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(200, 21);
            this.comboBoxArtigo.TabIndex = 3;
            this.comboBoxArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxArtigo_SelectedIndexChanged);
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(120, 72);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(80, 20);
            this.textBoxQuantidade.TabIndex = 5;
            // 
            // textBoxPreco
            // 
            this.textBoxPreco.Location = new System.Drawing.Point(120, 102);
            this.textBoxPreco.Name = "textBoxPreco";
            this.textBoxPreco.Size = new System.Drawing.Size(80, 20);
            this.textBoxPreco.TabIndex = 7;
            // 
            // textBoxObservacoes
            // 
            this.textBoxObservacoes.Location = new System.Drawing.Point(120, 132);
            this.textBoxObservacoes.Name = "textBoxObservacoes";
            this.textBoxObservacoes.Size = new System.Drawing.Size(200, 20);
            this.textBoxObservacoes.TabIndex = 9;
            // 
            // dataGridViewItens
            // 
            this.dataGridViewItens.AllowUserToAddRows = false;
            this.dataGridViewItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItens.Location = new System.Drawing.Point(12, 170);
            this.dataGridViewItens.Name = "dataGridViewItens";
            this.dataGridViewItens.ReadOnly = true;
            this.dataGridViewItens.Size = new System.Drawing.Size(560, 230);
            this.dataGridViewItens.TabIndex = 11;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionar.Location = new System.Drawing.Point(330, 128);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(120, 26);
            this.btnAdicionar.TabIndex = 10;
            this.btnAdicionar.Text = "Adicionar Item";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.White;
            this.btnRemover.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Location = new System.Drawing.Point(12, 410);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(110, 30);
            this.btnRemover.TabIndex = 12;
            this.btnRemover.Text = "Remover Item";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(460, 410);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(112, 30);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Artigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Artigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Qtd. Adquirida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Preço Unitário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Observações:";
            // 
            // FormAdicionarItemNaoPrevisto
            // 
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
            this.Name = "FormAdicionarItemNaoPrevisto";
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
