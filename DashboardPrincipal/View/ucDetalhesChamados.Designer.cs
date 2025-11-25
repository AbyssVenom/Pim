namespace Pim.View
{
    partial class ucDetalhesChamados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAcoes = new System.Windows.Forms.Panel();
            this.labeltituloAcoes = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMudarStatus = new System.Windows.Forms.Button();
            this.btnMudarPrioridade = new System.Windows.Forms.Button();
            this.lblAtendenteValor = new System.Windows.Forms.Label();
            this.lblSolicitanteValor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCategoriaValor = new System.Windows.Forms.Label();
            this.lblPrioridadeValor = new System.Windows.Forms.Label();
            this.lblStatusValor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResposta = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelAcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelAcoes);
            this.panel1.Controls.Add(this.lblAtendenteValor);
            this.panel1.Controls.Add(this.lblSolicitanteValor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblCategoriaValor);
            this.panel1.Controls.Add(this.lblPrioridadeValor);
            this.panel1.Controls.Add(this.lblStatusValor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(793, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 634);
            this.panel1.TabIndex = 0;
            // 
            // panelAcoes
            // 
            this.panelAcoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAcoes.Controls.Add(this.labeltituloAcoes);
            this.panelAcoes.Controls.Add(this.button3);
            this.panelAcoes.Controls.Add(this.btnMudarStatus);
            this.panelAcoes.Controls.Add(this.btnMudarPrioridade);
            this.panelAcoes.Location = new System.Drawing.Point(37, 372);
            this.panelAcoes.Name = "panelAcoes";
            this.panelAcoes.Size = new System.Drawing.Size(200, 172);
            this.panelAcoes.TabIndex = 14;
            // 
            // labeltituloAcoes
            // 
            this.labeltituloAcoes.AutoSize = true;
            this.labeltituloAcoes.Location = new System.Drawing.Point(20, 20);
            this.labeltituloAcoes.Name = "labeltituloAcoes";
            this.labeltituloAcoes.Size = new System.Drawing.Size(37, 13);
            this.labeltituloAcoes.TabIndex = 8;
            this.labeltituloAcoes.Text = "Ações";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(34, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Atendente:";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnMudarStatus
            // 
            this.btnMudarStatus.Location = new System.Drawing.Point(34, 42);
            this.btnMudarStatus.Name = "btnMudarStatus";
            this.btnMudarStatus.Size = new System.Drawing.Size(117, 23);
            this.btnMudarStatus.TabIndex = 5;
            this.btnMudarStatus.Text = "Alterar Status";
            this.btnMudarStatus.UseVisualStyleBackColor = true;
            this.btnMudarStatus.Click += new System.EventHandler(this.btnMudarStatus_Click);
            // 
            // btnMudarPrioridade
            // 
            this.btnMudarPrioridade.Location = new System.Drawing.Point(34, 71);
            this.btnMudarPrioridade.Name = "btnMudarPrioridade";
            this.btnMudarPrioridade.Size = new System.Drawing.Size(117, 23);
            this.btnMudarPrioridade.TabIndex = 6;
            this.btnMudarPrioridade.Text = "Alterar Prioridade";
            this.btnMudarPrioridade.UseVisualStyleBackColor = true;
            this.btnMudarPrioridade.Click += new System.EventHandler(this.btnMudarPrioridade_Click);
            // 
            // lblAtendenteValor
            // 
            this.lblAtendenteValor.AutoSize = true;
            this.lblAtendenteValor.Location = new System.Drawing.Point(96, 312);
            this.lblAtendenteValor.Name = "lblAtendenteValor";
            this.lblAtendenteValor.Size = new System.Drawing.Size(35, 13);
            this.lblAtendenteValor.TabIndex = 13;
            this.lblAtendenteValor.Text = "label7";
            // 
            // lblSolicitanteValor
            // 
            this.lblSolicitanteValor.AutoSize = true;
            this.lblSolicitanteValor.Location = new System.Drawing.Point(96, 264);
            this.lblSolicitanteValor.Name = "lblSolicitanteValor";
            this.lblSolicitanteValor.Size = new System.Drawing.Size(45, 13);
            this.lblSolicitanteValor.TabIndex = 12;
            this.lblSolicitanteValor.Text = "nenhum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // lblCategoriaValor
            // 
            this.lblCategoriaValor.AutoSize = true;
            this.lblCategoriaValor.Location = new System.Drawing.Point(96, 234);
            this.lblCategoriaValor.Name = "lblCategoriaValor";
            this.lblCategoriaValor.Size = new System.Drawing.Size(45, 13);
            this.lblCategoriaValor.TabIndex = 10;
            this.lblCategoriaValor.Text = "nenhum";
            // 
            // lblPrioridadeValor
            // 
            this.lblPrioridadeValor.AutoSize = true;
            this.lblPrioridadeValor.Location = new System.Drawing.Point(93, 207);
            this.lblPrioridadeValor.Name = "lblPrioridadeValor";
            this.lblPrioridadeValor.Size = new System.Drawing.Size(47, 13);
            this.lblPrioridadeValor.TabIndex = 9;
            this.lblPrioridadeValor.Text = "Nenhum";
            // 
            // lblStatusValor
            // 
            this.lblStatusValor.AutoSize = true;
            this.lblStatusValor.Location = new System.Drawing.Point(81, 178);
            this.lblStatusValor.Name = "lblStatusValor";
            this.lblStatusValor.Size = new System.Drawing.Size(47, 13);
            this.lblStatusValor.TabIndex = 8;
            this.lblStatusValor.Text = "Nenhum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Atendente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Solicitante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prioridade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(46, 56);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(189, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Titulo do chamado";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(81, 91);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(116, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição do problema";
            this.lblDescricao.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(48, 91);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(13, 13);
            this.lblSubtitulo.TabIndex = 3;
            this.lblSubtitulo.Text = "0";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.ColumnHeadersVisible = false;
            this.dgvHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario,
            this.Data,
            this.Mensagem});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorico.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorico.Location = new System.Drawing.Point(24, 127);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.RowHeadersVisible = false;
            this.dgvHistorico.RowTemplate.Height = 60;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(703, 340);
            this.dgvHistorico.TabIndex = 4;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Mensagem
            // 
            this.Mensagem.HeaderText = "Mensagem";
            this.Mensagem.Name = "Mensagem";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Adicionar resposta";
            // 
            // txtResposta
            // 
            this.txtResposta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResposta.Location = new System.Drawing.Point(29, 508);
            this.txtResposta.Multiline = true;
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.Size = new System.Drawing.Size(698, 80);
            this.txtResposta.TabIndex = 6;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(652, 594);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // ucDetalhesChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtResposta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvHistorico);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Name = "ucDetalhesChamados";
            this.Size = new System.Drawing.Size(1093, 634);
            this.Load += new System.EventHandler(this.ucDetalhesChamados_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAcoes.ResumeLayout(false);
            this.panelAcoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblPrioridadeValor;
        private System.Windows.Forms.Label lblStatusValor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMudarPrioridade;
        private System.Windows.Forms.Button btnMudarStatus;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblCategoriaValor;
        private System.Windows.Forms.Label lblSolicitanteValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAtendenteValor;
        private System.Windows.Forms.Panel panelAcoes;
        private System.Windows.Forms.Label labeltituloAcoes;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensagem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.Button btnEnviar;
    }
}
