namespace Pim
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.btnConfigPerfil = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnMeusChamados = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.btnConfigPerfil);
            this.panelMenu.Controls.Add(this.label18);
            this.panelMenu.Controls.Add(this.btnConfiguracoes);
            this.panelMenu.Controls.Add(this.label19);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.btnRelatorios);
            this.panelMenu.Controls.Add(this.button6);
            this.panelMenu.Controls.Add(this.btnMeusChamados);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(222, 661);
            this.panelMenu.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.DarkCyan;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(99, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 24);
            this.label18.TabIndex = 13;
            this.label18.Text = " Support";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkCyan;
            this.label19.Location = new System.Drawing.Point(5, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 32);
            this.label19.TabIndex = 12;
            this.label19.Text = "SolvIT";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(222, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 50);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 99);
            this.panel2.TabIndex = 1;
            // 
            // panelConteudo
            // 
            this.panelConteudo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConteudo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelConteudo.Location = new System.Drawing.Point(222, 50);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(1047, 611);
            this.panelConteudo.TabIndex = 6;
            this.panelConteudo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelConteudo_Paint);
            // 
            // btnConfigPerfil
            // 
            this.btnConfigPerfil.BackColor = System.Drawing.Color.White;
            this.btnConfigPerfil.FlatAppearance.BorderSize = 0;
            this.btnConfigPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigPerfil.ForeColor = System.Drawing.Color.Black;
            this.btnConfigPerfil.Image = global::Pim.Properties.Resources.user_avatar;
            this.btnConfigPerfil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigPerfil.Location = new System.Drawing.Point(11, 318);
            this.btnConfigPerfil.Name = "btnConfigPerfil";
            this.btnConfigPerfil.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConfigPerfil.Size = new System.Drawing.Size(180, 49);
            this.btnConfigPerfil.TabIndex = 14;
            this.btnConfigPerfil.Text = "Configurações do Perfil";
            this.btnConfigPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigPerfil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfigPerfil.UseVisualStyleBackColor = false;
            this.btnConfigPerfil.Click += new System.EventHandler(this.btnConfigPerfil_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackColor = System.Drawing.Color.White;
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.Black;
            this.btnConfiguracoes.Image = global::Pim.Properties.Resources.gear;
            this.btnConfiguracoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.Location = new System.Drawing.Point(11, 279);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConfiguracoes.Size = new System.Drawing.Size(180, 33);
            this.btnConfiguracoes.TabIndex = 12;
            this.btnConfiguracoes.Text = "Configurações do Sistema";
            this.btnConfiguracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguracoes.UseVisualStyleBackColor = false;
            this.btnConfiguracoes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Image = global::Pim.Properties.Resources.dashboards;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(11, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(130, 44);
            this.btnDashboard.TabIndex = 11;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.BackColor = System.Drawing.Color.White;
            this.btnRelatorios.FlatAppearance.BorderSize = 0;
            this.btnRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorios.ForeColor = System.Drawing.Color.Black;
            this.btnRelatorios.Image = global::Pim.Properties.Resources.infographic_bars_1202;
            this.btnRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.Location = new System.Drawing.Point(11, 228);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRelatorios.Size = new System.Drawing.Size(113, 33);
            this.btnRelatorios.TabIndex = 10;
            this.btnRelatorios.Text = "Relatorios";
            this.btnRelatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRelatorios.UseVisualStyleBackColor = false;
            this.btnRelatorios.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Image = global::Pim.Properties.Resources.book_8567784;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(11, 184);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(159, 38);
            this.button6.TabIndex = 10;
            this.button6.Text = "Base de Conhecimento";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnMeusChamados
            // 
            this.btnMeusChamados.BackColor = System.Drawing.Color.White;
            this.btnMeusChamados.FlatAppearance.BorderSize = 0;
            this.btnMeusChamados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeusChamados.ForeColor = System.Drawing.Color.Black;
            this.btnMeusChamados.Image = global::Pim.Properties.Resources.ticket_3435842;
            this.btnMeusChamados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeusChamados.Location = new System.Drawing.Point(11, 143);
            this.btnMeusChamados.Name = "btnMeusChamados";
            this.btnMeusChamados.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMeusChamados.Size = new System.Drawing.Size(145, 35);
            this.btnMeusChamados.TabIndex = 10;
            this.btnMeusChamados.Text = "Meus Chamados";
            this.btnMeusChamados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeusChamados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeusChamados.UseVisualStyleBackColor = false;
            this.btnMeusChamados.Click += new System.EventHandler(this.bchamados_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 661);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "TelaPrincipal";
            this.Text = "SolvIT Support";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnMeusChamados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelConteudo;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnConfigPerfil;
    }
}