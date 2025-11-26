namespace Pim.View
{
    partial class ucMeuPerfil
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSalvarPerfil = new System.Windows.Forms.Button();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lBio = new System.Windows.Forms.Label();
            this.lDepartamento = new System.Windows.Forms.Label();
            this.lTelefone = new System.Windows.Forms.Label();
            this.lNome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSalvarSenha = new System.Windows.Forms.Button();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.txtSenhaAtual = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSalvarPerfil);
            this.tabPage1.Controls.Add(this.txtBio);
            this.tabPage1.Controls.Add(this.txtTelefone);
            this.tabPage1.Controls.Add(this.txtDepartamento);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.lBio);
            this.tabPage1.Controls.Add(this.lDepartamento);
            this.tabPage1.Controls.Add(this.lTelefone);
            this.tabPage1.Controls.Add(this.lNome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1005, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Perfil";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnSalvarPerfil
            // 
            this.btnSalvarPerfil.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSalvarPerfil.ForeColor = System.Drawing.Color.White;
            this.btnSalvarPerfil.Location = new System.Drawing.Point(184, 234);
            this.btnSalvarPerfil.Name = "btnSalvarPerfil";
            this.btnSalvarPerfil.Size = new System.Drawing.Size(139, 36);
            this.btnSalvarPerfil.TabIndex = 11;
            this.btnSalvarPerfil.Text = "Salvar Alterações";
            this.btnSalvarPerfil.UseVisualStyleBackColor = false;
            this.btnSalvarPerfil.Click += new System.EventHandler(this.btnSalvarPerfil_Click);
            // 
            // txtBio
            // 
            this.txtBio.Location = new System.Drawing.Point(10, 197);
            this.txtBio.Name = "txtBio";
            this.txtBio.Size = new System.Drawing.Size(313, 20);
            this.txtBio.TabIndex = 9;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(10, 92);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(313, 20);
            this.txtTelefone.TabIndex = 8;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(10, 139);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(313, 20);
            this.txtDepartamento.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(10, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(313, 20);
            this.txtNome.TabIndex = 5;
            // 
            // lBio
            // 
            this.lBio.AutoSize = true;
            this.lBio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBio.Location = new System.Drawing.Point(6, 173);
            this.lBio.Name = "lBio";
            this.lBio.Size = new System.Drawing.Size(32, 21);
            this.lBio.TabIndex = 4;
            this.lBio.Text = "Bio";
            // 
            // lDepartamento
            // 
            this.lDepartamento.AutoSize = true;
            this.lDepartamento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDepartamento.Location = new System.Drawing.Point(6, 115);
            this.lDepartamento.Name = "lDepartamento";
            this.lDepartamento.Size = new System.Drawing.Size(110, 21);
            this.lDepartamento.TabIndex = 3;
            this.lDepartamento.Text = "Departamento";
            this.lDepartamento.Click += new System.EventHandler(this.txtDepartamento_Click);
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTelefone.Location = new System.Drawing.Point(6, 68);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(67, 21);
            this.lTelefone.TabIndex = 2;
            this.lTelefone.Text = "Telefone";
            this.lTelefone.Click += new System.EventHandler(this.lTelefone_Click);
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNome.Location = new System.Drawing.Point(6, 18);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(53, 21);
            this.lNome.TabIndex = 0;
            this.lNome.Text = "Nome";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnSalvarSenha);
            this.tabPage2.Controls.Add(this.txtConfirmarSenha);
            this.tabPage2.Controls.Add(this.txtNovaSenha);
            this.tabPage2.Controls.Add(this.txtSenhaAtual);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1005, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Segurança";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnSalvarSenha
            // 
            this.btnSalvarSenha.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSalvarSenha.ForeColor = System.Drawing.Color.White;
            this.btnSalvarSenha.Location = new System.Drawing.Point(161, 233);
            this.btnSalvarSenha.Name = "btnSalvarSenha";
            this.btnSalvarSenha.Size = new System.Drawing.Size(142, 42);
            this.btnSalvarSenha.TabIndex = 6;
            this.btnSalvarSenha.Text = "Atualizar Senha";
            this.btnSalvarSenha.UseVisualStyleBackColor = false;
            this.btnSalvarSenha.Click += new System.EventHandler(this.btnSalvarSenha_Click);
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Location = new System.Drawing.Point(18, 180);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(285, 20);
            this.txtConfirmarSenha.TabIndex = 5;
            this.txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Location = new System.Drawing.Point(18, 127);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(285, 20);
            this.txtNovaSenha.TabIndex = 4;
            this.txtNovaSenha.UseSystemPasswordChar = true;
            // 
            // txtSenhaAtual
            // 
            this.txtSenhaAtual.Location = new System.Drawing.Point(18, 75);
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.txtSenhaAtual.Size = new System.Drawing.Size(285, 20);
            this.txtSenhaAtual.TabIndex = 3;
            this.txtSenhaAtual.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Confirmar Senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nova Senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configurações do Perfil";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 87);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "Segurança da conta";
            // 
            // ucMeuPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ucMeuPerfil";
            this.Size = new System.Drawing.Size(1013, 498);
            this.Load += new System.EventHandler(this.ucMeuPerfil_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lBio;
        private System.Windows.Forms.Label lDepartamento;
        private System.Windows.Forms.Label lTelefone;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.TextBox txtSenhaAtual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.Button btnSalvarSenha;
        private System.Windows.Forms.Button btnSalvarPerfil;
        private System.Windows.Forms.Label label5;
    }
}
