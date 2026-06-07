namespace Ishopping.View
{
    partial class FormEditarCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelDataCriacao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNomeCompra = new System.Windows.Forms.TextBox();
            this.btnGuardarNome = new System.Windows.Forms.Button();
            this.labelPrevistos = new System.Windows.Forms.Label();
            this.dataGridViewPrevistos = new System.Windows.Forms.DataGridView();
            this.labelNaoPrevistos = new System.Windows.Forms.Label();
            this.dataGridViewNaoPrevistos = new System.Windows.Forms.DataGridView();
            this.btnGerarItensPrevistos = new System.Windows.Forms.Button();
            this.btnAdicionarNaoPrevistos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrevistos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNaoPrevistos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editar Compra";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelEstado.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelEstado.Location = new System.Drawing.Point(650, 20);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(58, 17);
            this.labelEstado.TabIndex = 1;
            this.labelEstado.Text = "Estado";
            // 
            // labelDataCriacao
            // 
            this.labelDataCriacao.AutoSize = true;
            this.labelDataCriacao.Location = new System.Drawing.Point(15, 55);
            this.labelDataCriacao.Name = "labelDataCriacao";
            this.labelDataCriacao.Size = new System.Drawing.Size(40, 13);
            this.labelDataCriacao.TabIndex = 2;
            this.labelDataCriacao.Text = "Criada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome da Compra:";
            // 
            // textBoxNomeCompra
            // 
            this.textBoxNomeCompra.Location = new System.Drawing.Point(130, 82);
            this.textBoxNomeCompra.Name = "textBoxNomeCompra";
            this.textBoxNomeCompra.Size = new System.Drawing.Size(320, 20);
            this.textBoxNomeCompra.TabIndex = 4;
            // 
            // btnGuardarNome
            // 
            this.btnGuardarNome.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarNome.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarNome.Location = new System.Drawing.Point(460, 80);
            this.btnGuardarNome.Name = "btnGuardarNome";
            this.btnGuardarNome.Size = new System.Drawing.Size(130, 24);
            this.btnGuardarNome.TabIndex = 5;
            this.btnGuardarNome.Text = "Guardar Nome";
            this.btnGuardarNome.UseVisualStyleBackColor = false;
            this.btnGuardarNome.Click += new System.EventHandler(this.btnGuardarNome_Click);
            // 
            // labelPrevistos
            // 
            this.labelPrevistos.AutoSize = true;
            this.labelPrevistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelPrevistos.Location = new System.Drawing.Point(15, 120);
            this.labelPrevistos.Name = "labelPrevistos";
            this.labelPrevistos.Size = new System.Drawing.Size(120, 17);
            this.labelPrevistos.TabIndex = 6;
            this.labelPrevistos.Text = "Itens Previstos:";
            // 
            // dataGridViewPrevistos
            // 
            this.dataGridViewPrevistos.AllowUserToAddRows = false;
            this.dataGridViewPrevistos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrevistos.Location = new System.Drawing.Point(15, 150);
            this.dataGridViewPrevistos.Name = "dataGridViewPrevistos";
            this.dataGridViewPrevistos.ReadOnly = true;
            this.dataGridViewPrevistos.Size = new System.Drawing.Size(765, 180);
            this.dataGridViewPrevistos.TabIndex = 8;
            // 
            // labelNaoPrevistos
            // 
            this.labelNaoPrevistos.AutoSize = true;
            this.labelNaoPrevistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelNaoPrevistos.Location = new System.Drawing.Point(15, 345);
            this.labelNaoPrevistos.Name = "labelNaoPrevistos";
            this.labelNaoPrevistos.Size = new System.Drawing.Size(154, 17);
            this.labelNaoPrevistos.TabIndex = 9;
            this.labelNaoPrevistos.Text = "Itens Não Previstos:";
            // 
            // dataGridViewNaoPrevistos
            // 
            this.dataGridViewNaoPrevistos.AllowUserToAddRows = false;
            this.dataGridViewNaoPrevistos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNaoPrevistos.Location = new System.Drawing.Point(15, 375);
            this.dataGridViewNaoPrevistos.Name = "dataGridViewNaoPrevistos";
            this.dataGridViewNaoPrevistos.ReadOnly = true;
            this.dataGridViewNaoPrevistos.Size = new System.Drawing.Size(765, 160);
            this.dataGridViewNaoPrevistos.TabIndex = 11;
            // 
            // btnGerarItensPrevistos
            // 
            this.btnGerarItensPrevistos.BackColor = System.Drawing.Color.White;
            this.btnGerarItensPrevistos.ForeColor = System.Drawing.Color.Black;
            this.btnGerarItensPrevistos.Location = new System.Drawing.Point(620, 116);
            this.btnGerarItensPrevistos.Name = "btnGerarItensPrevistos";
            this.btnGerarItensPrevistos.Size = new System.Drawing.Size(160, 26);
            this.btnGerarItensPrevistos.TabIndex = 7;
            this.btnGerarItensPrevistos.Text = "Gerir Itens Previstos";
            this.btnGerarItensPrevistos.UseVisualStyleBackColor = false;
            this.btnGerarItensPrevistos.Click += new System.EventHandler(this.btnGerarItensPrevistos_Click);
            // 
            // btnAdicionarNaoPrevistos
            // 
            this.btnAdicionarNaoPrevistos.BackColor = System.Drawing.Color.White;
            this.btnAdicionarNaoPrevistos.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionarNaoPrevistos.Location = new System.Drawing.Point(550, 341);
            this.btnAdicionarNaoPrevistos.Name = "btnAdicionarNaoPrevistos";
            this.btnAdicionarNaoPrevistos.Size = new System.Drawing.Size(230, 26);
            this.btnAdicionarNaoPrevistos.TabIndex = 10;
            this.btnAdicionarNaoPrevistos.Text = "Adicionar Itens Não Previstos";
            this.btnAdicionarNaoPrevistos.UseVisualStyleBackColor = false;
            this.btnAdicionarNaoPrevistos.Click += new System.EventHandler(this.btnAdicionarNaoPrevistos_Click);
            // 
            // FormEditarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelDataCriacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNomeCompra);
            this.Controls.Add(this.btnGuardarNome);
            this.Controls.Add(this.labelPrevistos);
            this.Controls.Add(this.btnGerarItensPrevistos);
            this.Controls.Add(this.dataGridViewPrevistos);
            this.Controls.Add(this.labelNaoPrevistos);
            this.Controls.Add(this.btnAdicionarNaoPrevistos);
            this.Controls.Add(this.dataGridViewNaoPrevistos);
            this.Name = "FormEditarCompra";
            this.Text = "Editar Compra";
            this.Load += new System.EventHandler(this.FormEditarCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrevistos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNaoPrevistos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelDataCriacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNomeCompra;
        private System.Windows.Forms.Button btnGuardarNome;
        private System.Windows.Forms.Label labelPrevistos;
        private System.Windows.Forms.DataGridView dataGridViewPrevistos;
        private System.Windows.Forms.Label labelNaoPrevistos;
        private System.Windows.Forms.DataGridView dataGridViewNaoPrevistos;
        private System.Windows.Forms.Button btnGerarItensPrevistos;
        private System.Windows.Forms.Button btnAdicionarNaoPrevistos;
    }
}
