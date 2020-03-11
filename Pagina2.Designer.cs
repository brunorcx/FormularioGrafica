namespace FormularioGrafica {
    partial class Pagina2 {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelNovosDados = new System.Windows.Forms.Label();
            this.labelNovoCPF = new System.Windows.Forms.Label();
            this.textBoxNovoCPF = new System.Windows.Forms.TextBox();
            this.labelNovoNome = new System.Windows.Forms.Label();
            this.textBoxNovoNome = new System.Windows.Forms.TextBox();
            this.dataGridTabelaClientes = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.labelCPF = new System.Windows.Forms.Label();
            this.textBoxCPF = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNovoTelefone = new System.Windows.Forms.TextBox();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNovosDados
            // 
            this.labelNovosDados.AutoSize = true;
            this.labelNovosDados.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelNovosDados.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelNovosDados.Location = new System.Drawing.Point(15, 224);
            this.labelNovosDados.Name = "labelNovosDados";
            this.labelNovosDados.Size = new System.Drawing.Size(185, 19);
            this.labelNovosDados.TabIndex = 132;
            this.labelNovosDados.Text = "Novos dados a modificar:";
            // 
            // labelNovoCPF
            // 
            this.labelNovoCPF.AutoSize = true;
            this.labelNovoCPF.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelNovoCPF.Location = new System.Drawing.Point(15, 310);
            this.labelNovoCPF.Name = "labelNovoCPF";
            this.labelNovoCPF.Size = new System.Drawing.Size(41, 19);
            this.labelNovoCPF.TabIndex = 127;
            this.labelNovoCPF.Text = "CPF:";
            // 
            // textBoxNovoCPF
            // 
            this.textBoxNovoCPF.Font = new System.Drawing.Font("Constantia", 12F);
            this.textBoxNovoCPF.Location = new System.Drawing.Point(98, 307);
            this.textBoxNovoCPF.MaxLength = 20;
            this.textBoxNovoCPF.Name = "textBoxNovoCPF";
            this.textBoxNovoCPF.Size = new System.Drawing.Size(103, 27);
            this.textBoxNovoCPF.TabIndex = 126;
            this.textBoxNovoCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNovoNome
            // 
            this.labelNovoNome.AutoSize = true;
            this.labelNovoNome.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelNovoNome.Location = new System.Drawing.Point(15, 262);
            this.labelNovoNome.Name = "labelNovoNome";
            this.labelNovoNome.Size = new System.Drawing.Size(56, 19);
            this.labelNovoNome.TabIndex = 125;
            this.labelNovoNome.Text = "Nome:";
            // 
            // textBoxNovoNome
            // 
            this.textBoxNovoNome.Font = new System.Drawing.Font("Constantia", 12F);
            this.textBoxNovoNome.Location = new System.Drawing.Point(98, 259);
            this.textBoxNovoNome.MaxLength = 40;
            this.textBoxNovoNome.Name = "textBoxNovoNome";
            this.textBoxNovoNome.Size = new System.Drawing.Size(295, 27);
            this.textBoxNovoNome.TabIndex = 124;
            // 
            // dataGridTabelaClientes
            // 
            this.dataGridTabelaClientes.AllowUserToAddRows = false;
            this.dataGridTabelaClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.dataGridTabelaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTabelaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTabelaClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTabelaClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dataGridTabelaClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Constantia", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTabelaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTabelaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle3.NullValue = "Algo";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTabelaClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridTabelaClientes.EnableHeadersVisualStyles = false;
            this.dataGridTabelaClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.dataGridTabelaClientes.Location = new System.Drawing.Point(98, 193);
            this.dataGridTabelaClientes.Name = "dataGridTabelaClientes";
            this.dataGridTabelaClientes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTabelaClientes.RowTemplate.Height = 25;
            this.dataGridTabelaClientes.Size = new System.Drawing.Size(536, 150);
            this.dataGridTabelaClientes.TabIndex = 123;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Nome";
            this.Column2.HeaderText = "Nome";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CPF";
            this.Column1.HeaderText = "CPF";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Telefone";
            this.Column3.HeaderText = "Telefone";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // buttonRemover
            // 
            this.buttonRemover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemover.Location = new System.Drawing.Point(585, 136);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(133, 34);
            this.buttonRemover.TabIndex = 122;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = false;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPesquisar.Location = new System.Drawing.Point(414, 71);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(133, 34);
            this.buttonPesquisar.TabIndex = 121;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = false;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.Location = new System.Drawing.Point(585, 71);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(133, 34);
            this.buttonCadastrar.TabIndex = 120;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlterar.Location = new System.Drawing.Point(414, 136);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(133, 34);
            this.buttonAlterar.TabIndex = 119;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = false;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Font = new System.Drawing.Font("Constantia", 12F);
            this.textBoxTelefone.Location = new System.Drawing.Point(297, 119);
            this.textBoxTelefone.MaxLength = 20;
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(96, 27);
            this.textBoxTelefone.TabIndex = 118;
            this.textBoxTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelTelefone.Location = new System.Drawing.Point(213, 122);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(74, 19);
            this.labelTelefone.TabIndex = 116;
            this.labelTelefone.Text = "Telefone:";
            this.labelTelefone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelCPF.Location = new System.Drawing.Point(15, 122);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(41, 19);
            this.labelCPF.TabIndex = 114;
            this.labelCPF.Text = "CPF:";
            // 
            // textBoxCPF
            // 
            this.textBoxCPF.Font = new System.Drawing.Font("Constantia", 12F);
            this.textBoxCPF.Location = new System.Drawing.Point(98, 119);
            this.textBoxCPF.MaxLength = 20;
            this.textBoxCPF.Name = "textBoxCPF";
            this.textBoxCPF.Size = new System.Drawing.Size(103, 27);
            this.textBoxCPF.TabIndex = 113;
            this.textBoxCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelNome.Location = new System.Drawing.Point(15, 74);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(56, 19);
            this.labelNome.TabIndex = 112;
            this.labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Constantia", 12F);
            this.textBoxNome.Location = new System.Drawing.Point(98, 71);
            this.textBoxNome.MaxLength = 40;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(295, 27);
            this.textBoxNome.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 110;
            this.label2.Text = "Cliente";
            // 
            // textBoxNovoTelefone
            // 
            this.textBoxNovoTelefone.Font = new System.Drawing.Font("Constantia", 12F);
            this.textBoxNovoTelefone.Location = new System.Drawing.Point(297, 307);
            this.textBoxNovoTelefone.MaxLength = 20;
            this.textBoxNovoTelefone.Name = "textBoxNovoTelefone";
            this.textBoxNovoTelefone.Size = new System.Drawing.Size(96, 27);
            this.textBoxNovoTelefone.TabIndex = 134;
            this.textBoxNovoTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Font = new System.Drawing.Font("Constantia", 12F);
            this.labelNovoTelefone.Location = new System.Drawing.Point(213, 310);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(74, 19);
            this.labelNovoTelefone.TabIndex = 133;
            this.labelNovoTelefone.Text = "Telefone:";
            this.labelNovoTelefone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(18, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(709, 120);
            this.pictureBox1.TabIndex = 135;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(18, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(709, 120);
            this.pictureBox2.TabIndex = 136;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Pagina2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.textBoxNovoTelefone);
            this.Controls.Add(this.labelNovoTelefone);
            this.Controls.Add(this.labelNovosDados);
            this.Controls.Add(this.labelNovoCPF);
            this.Controls.Add(this.textBoxNovoCPF);
            this.Controls.Add(this.labelNovoNome);
            this.Controls.Add(this.textBoxNovoNome);
            this.Controls.Add(this.dataGridTabelaClientes);
            this.Controls.Add(this.buttonRemover);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.textBoxTelefone);
            this.Controls.Add(this.labelTelefone);
            this.Controls.Add(this.labelCPF);
            this.Controls.Add(this.textBoxCPF);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "Pagina2";
            this.Size = new System.Drawing.Size(744, 346);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNovosDados;
        private System.Windows.Forms.Label labelNovoCPF;
        private System.Windows.Forms.TextBox textBoxNovoCPF;
        private System.Windows.Forms.Label labelNovoNome;
        private System.Windows.Forms.TextBox textBoxNovoNome;
        private System.Windows.Forms.DataGridView dataGridTabelaClientes;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.TextBox textBoxCPF;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNovoTelefone;
        private System.Windows.Forms.Label labelNovoTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
