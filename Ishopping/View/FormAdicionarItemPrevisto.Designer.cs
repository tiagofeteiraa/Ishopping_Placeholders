namespace Ishopping.View
{
    partial class FormAdicionarItemPrevisto
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
            this.dataGridViewItens = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItens)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTipoArtigo
            // 
            this.comboBoxTipoArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoArtigo.Location = new System.Drawing.Point(110, 12);
            this.comboBoxTipoArtigo.Name = "comboBoxTipoArtigo";
            this.comboBoxTipoArtigo.Size = new System.Drawing.Size(200, 21);
            this.comboBoxTipoArtigo.TabIndex = 1;
            this.comboBoxTipoArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoArtigo_SelectedIndexChanged);
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArtigo.Location = new System.Drawing.Point(110, 42);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(200, 21);
            this.comboBoxArtigo.TabIndex = 3;
            this.comboBoxArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxArtigo_SelectedIndexChanged);
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(110, 72);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(80, 20);
            this.textBoxQuantidade.TabIndex = 5;
            // 
            // dataGridViewItens
            // 
            this.dataGridViewItens.AllowUserToAddRows = false;
            this.dataGridViewItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItens.Location = new System.Drawing.Point(12, 110);
            this.dataGridViewItens.Name = "dataGridViewItens";
            this.dataGridViewItens.ReadOnly = true;
            this.dataGridViewItens.Size = new System.Drawing.Size(560, 250);
            this.dataGridViewItens.TabIndex = 7;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionar.Location = new System.Drawing.Point(200, 70);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(110, 26);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar Item";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.Transparent;
            this.btnRemover.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Location = new System.Drawing.Point(12, 370);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(110, 30);
            this.btnRemover.TabIndex = 8;
            this.btnRemover.Text = "Remover Item";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(460, 370);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(112, 30);
            this.btnFechar.TabIndex = 9;
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
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Qtd. Prevista:";
            // 
            // FormAdicionarItemPrevisto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoArtigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dataGridViewItens);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnFechar);
            this.Name = "FormAdicionarItemPrevisto";
            this.Text = "Gerir Itens Previstos";
            this.Load += new System.EventHandler(this.FormAdicionarItemPrevisto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBoxTipoArtigo;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.DataGridView dataGridViewItens;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
