namespace Pim
{
    partial class ucMeusChamados
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
            this.components = new System.ComponentModel.Container();
            this.btAbrirChamado = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltroStatus = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvChamados = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prioridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcoes = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tableStats = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelResolvido = new System.Windows.Forms.Label();
            this.lblResolvidosCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAndamento = new System.Windows.Forms.Label();
            this.lblAndamentoCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAbertos = new System.Windows.Forms.Label();
            this.lblAbertosCount = new System.Windows.Forms.Label();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotalChamados = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).BeginInit();
            this.tableStats.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAbrirChamado
            // 
            this.btAbrirChamado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAbrirChamado.Location = new System.Drawing.Point(1041, 59);
            this.btAbrirChamado.Name = "btAbrirChamado";
            this.btAbrirChamado.Size = new System.Drawing.Size(180, 44);
            this.btAbrirChamado.TabIndex = 0;
            this.btAbrirChamado.Text = "Abrir novo chamado";
            this.btAbrirChamado.UseVisualStyleBackColor = true;
            this.btAbrirChamado.Click += new System.EventHandler(this.btAbrirChamado_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltros.Controls.Add(this.label9);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.label2);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.cmbFiltroStatus);
            this.panelFiltros.Controls.Add(this.txtPesquisa);
            this.panelFiltros.Location = new System.Drawing.Point(64, 292);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1152, 126);
            this.panelFiltros.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "Filtros e Pesquisa";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.Location = new System.Drawing.Point(840, 74);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(272, 31);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(398, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pesquisar por titulo ou ID:";
            // 
            // cmbFiltroStatus
            // 
            this.cmbFiltroStatus.FormattingEnabled = true;
            this.cmbFiltroStatus.Items.AddRange(new object[] {
            "Todos",
            "Aberto ",
            "Em Andamento",
            "Resolvido"});
            this.cmbFiltroStatus.Location = new System.Drawing.Point(403, 84);
            this.cmbFiltroStatus.Name = "cmbFiltroStatus";
            this.cmbFiltroStatus.Size = new System.Drawing.Size(370, 21);
            this.cmbFiltroStatus.TabIndex = 1;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(15, 85);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(284, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dgvChamados
            // 
            this.dgvChamados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChamados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Titulo,
            this.Categoria,
            this.Prioridade,
            this.Status,
            this.Data,
            this.colAcoes});
            this.dgvChamados.Location = new System.Drawing.Point(64, 438);
            this.dgvChamados.Name = "dgvChamados";
            this.dgvChamados.Size = new System.Drawing.Size(1152, 150);
            this.dgvChamados.TabIndex = 3;
            this.dgvChamados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamados_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "IdFormatado";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Titulo
            // 
            this.Titulo.DataPropertyName = "Titulo";
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.Name = "Titulo";
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "CategoriaNome";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // Prioridade
            // 
            this.Prioridade.DataPropertyName = "Prioridade";
            this.Prioridade.HeaderText = "Prioridade";
            this.Prioridade.Name = "Prioridade";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataFormatada";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // colAcoes
            // 
            this.colAcoes.HeaderText = "Ações";
            this.colAcoes.Name = "colAcoes";
            this.colAcoes.Text = "Ver Detalhes";
            this.colAcoes.UseColumnTextForLinkValue = true;
            // 
            // tableStats
            // 
            this.tableStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableStats.BackColor = System.Drawing.Color.Transparent;
            this.tableStats.ColumnCount = 4;
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.Controls.Add(this.panel3, 3, 0);
            this.tableStats.Controls.Add(this.panel2, 2, 0);
            this.tableStats.Controls.Add(this.panel1, 1, 0);
            this.tableStats.Controls.Add(this.panelTotal, 0, 0);
            this.tableStats.Location = new System.Drawing.Point(59, 123);
            this.tableStats.Name = "tableStats";
            this.tableStats.RowCount = 1;
            this.tableStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableStats.Size = new System.Drawing.Size(1162, 150);
            this.tableStats.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.labelResolvido);
            this.panel3.Controls.Add(this.lblResolvidosCount);
            this.panel3.Location = new System.Drawing.Point(875, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 140);
            this.panel3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Solucionados com sucesso";
            // 
            // labelResolvido
            // 
            this.labelResolvido.AutoSize = true;
            this.labelResolvido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResolvido.Location = new System.Drawing.Point(14, 18);
            this.labelResolvido.Name = "labelResolvido";
            this.labelResolvido.Size = new System.Drawing.Size(71, 17);
            this.labelResolvido.TabIndex = 12;
            this.labelResolvido.Text = "Resolvidos";
            // 
            // lblResolvidosCount
            // 
            this.lblResolvidosCount.AutoSize = true;
            this.lblResolvidosCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolvidosCount.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblResolvidosCount.Location = new System.Drawing.Point(6, 35);
            this.lblResolvidosCount.Name = "lblResolvidosCount";
            this.lblResolvidosCount.Size = new System.Drawing.Size(54, 65);
            this.lblResolvidosCount.TabIndex = 11;
            this.lblResolvidosCount.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelAndamento);
            this.panel2.Controls.Add(this.lblAndamentoCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(585, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 140);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sendo processados pela equipe";
            // 
            // labelAndamento
            // 
            this.labelAndamento.AutoSize = true;
            this.labelAndamento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAndamento.Location = new System.Drawing.Point(8, 18);
            this.labelAndamento.Name = "labelAndamento";
            this.labelAndamento.Size = new System.Drawing.Size(111, 17);
            this.labelAndamento.TabIndex = 12;
            this.labelAndamento.Text = "EM ANDAMENTO";
            // 
            // lblAndamentoCount
            // 
            this.lblAndamentoCount.AutoSize = true;
            this.lblAndamentoCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAndamentoCount.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAndamentoCount.Location = new System.Drawing.Point(3, 35);
            this.lblAndamentoCount.Name = "lblAndamentoCount";
            this.lblAndamentoCount.Size = new System.Drawing.Size(54, 65);
            this.lblAndamentoCount.TabIndex = 11;
            this.lblAndamentoCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelAbertos);
            this.panel1.Controls.Add(this.lblAbertosCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(295, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 140);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Aguardando atendimento";
            // 
            // labelAbertos
            // 
            this.labelAbertos.AutoSize = true;
            this.labelAbertos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbertos.Location = new System.Drawing.Point(3, 18);
            this.labelAbertos.Name = "labelAbertos";
            this.labelAbertos.Size = new System.Drawing.Size(76, 17);
            this.labelAbertos.TabIndex = 12;
            this.labelAbertos.Text = "EM ABERTO";
            // 
            // lblAbertosCount
            // 
            this.lblAbertosCount.AutoSize = true;
            this.lblAbertosCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbertosCount.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblAbertosCount.Location = new System.Drawing.Point(3, 35);
            this.lblAbertosCount.Name = "lblAbertosCount";
            this.lblAbertosCount.Size = new System.Drawing.Size(54, 65);
            this.lblAbertosCount.TabIndex = 11;
            this.lblAbertosCount.Text = "0";
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.White;
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.label6);
            this.panelTotal.Controls.Add(this.labelTotalChamados);
            this.panelTotal.Controls.Add(this.lblTotalCount);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotal.Location = new System.Drawing.Point(5, 5);
            this.panelTotal.Margin = new System.Windows.Forms.Padding(5);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(280, 140);
            this.panelTotal.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Todos Chamados Registrados";
            // 
            // labelTotalChamados
            // 
            this.labelTotalChamados.AutoSize = true;
            this.labelTotalChamados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalChamados.Location = new System.Drawing.Point(3, 18);
            this.labelTotalChamados.Name = "labelTotalChamados";
            this.labelTotalChamados.Size = new System.Drawing.Size(138, 17);
            this.labelTotalChamados.TabIndex = 12;
            this.labelTotalChamados.Text = "TOTAL DE CHAMADOS";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(3, 35);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(54, 65);
            this.lblTotalCount.TabIndex = 11;
            this.lblTotalCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 40);
            this.label7.TabIndex = 22;
            this.label7.Text = "Meus Chamados";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(55, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(397, 21);
            this.label8.TabIndex = 23;
            this.label8.Text = "Visualize e gerencie todos os seus chamados de suporte";
            // 
            // ucMeusChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tableStats);
            this.Controls.Add(this.dgvChamados);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.btAbrirChamado);
            this.Name = "ucMeusChamados";
            this.Size = new System.Drawing.Size(1311, 623);
            this.Load += new System.EventHandler(this.ucMeusChamados_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).EndInit();
            this.tableStats.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAbrirChamado;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.ComboBox cmbFiltroStatus;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvChamados;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewLinkColumn colAcoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TableLayoutPanel tableStats;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelResolvido;
        private System.Windows.Forms.Label lblResolvidosCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelAndamento;
        private System.Windows.Forms.Label lblAndamentoCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAbertos;
        private System.Windows.Forms.Label lblAbertosCount;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotalChamados;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
