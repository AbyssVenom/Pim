namespace DashboardPrincipal
{
    partial class Dashboard
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableStats = new System.Windows.Forms.TableLayoutPanel();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.labelTotalChamados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAbertos = new System.Windows.Forms.Label();
            this.labelAbertosCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAndamento = new System.Windows.Forms.Label();
            this.labelAndamentoCount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelResolvido = new System.Windows.Forms.Label();
            this.labelResolvidoCount = new System.Windows.Forms.Label();
            this.dgvChamadosRecentes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prioridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcoes = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tableStats.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamadosRecentes)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(229, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dashboard";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(232, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Bem vindo ao sistema de suporte da solvIT";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(951, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "+        Abrir Novo Chamado";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tableStats
            // 
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
            this.tableStats.Location = new System.Drawing.Point(234, 140);
            this.tableStats.Name = "tableStats";
            this.tableStats.RowCount = 1;
            this.tableStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableStats.Size = new System.Drawing.Size(891, 150);
            this.tableStats.TabIndex = 10;
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.White;
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.labelTotalChamados);
            this.panelTotal.Controls.Add(this.labelTotalCount);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotal.Location = new System.Drawing.Point(5, 5);
            this.panelTotal.Margin = new System.Windows.Forms.Padding(5);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(212, 140);
            this.panelTotal.TabIndex = 0;
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCount.Location = new System.Drawing.Point(65, 35);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(54, 65);
            this.labelTotalCount.TabIndex = 11;
            this.labelTotalCount.Text = "0";
            // 
            // labelTotalChamados
            // 
            this.labelTotalChamados.AutoSize = true;
            this.labelTotalChamados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalChamados.Location = new System.Drawing.Point(17, 18);
            this.labelTotalChamados.Name = "labelTotalChamados";
            this.labelTotalChamados.Size = new System.Drawing.Size(138, 17);
            this.labelTotalChamados.TabIndex = 12;
            this.labelTotalChamados.Text = "TOTAL DE CHAMADOS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelAbertos);
            this.panel1.Controls.Add(this.labelAbertosCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(227, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 140);
            this.panel1.TabIndex = 1;
            // 
            // labelAbertos
            // 
            this.labelAbertos.AutoSize = true;
            this.labelAbertos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbertos.Location = new System.Drawing.Point(20, 18);
            this.labelAbertos.Name = "labelAbertos";
            this.labelAbertos.Size = new System.Drawing.Size(76, 17);
            this.labelAbertos.TabIndex = 12;
            this.labelAbertos.Text = "EM ABERTO";
            // 
            // labelAbertosCount
            // 
            this.labelAbertosCount.AutoSize = true;
            this.labelAbertosCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbertosCount.Location = new System.Drawing.Point(65, 35);
            this.labelAbertosCount.Name = "labelAbertosCount";
            this.labelAbertosCount.Size = new System.Drawing.Size(54, 65);
            this.labelAbertosCount.TabIndex = 11;
            this.labelAbertosCount.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelAndamento);
            this.panel2.Controls.Add(this.labelAndamentoCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(449, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 140);
            this.panel2.TabIndex = 2;
            // 
            // labelAndamento
            // 
            this.labelAndamento.AutoSize = true;
            this.labelAndamento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAndamento.Location = new System.Drawing.Point(14, 18);
            this.labelAndamento.Name = "labelAndamento";
            this.labelAndamento.Size = new System.Drawing.Size(111, 17);
            this.labelAndamento.TabIndex = 12;
            this.labelAndamento.Text = "EM ANDAMENTO";
            // 
            // labelAndamentoCount
            // 
            this.labelAndamentoCount.AutoSize = true;
            this.labelAndamentoCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAndamentoCount.Location = new System.Drawing.Point(65, 35);
            this.labelAndamentoCount.Name = "labelAndamentoCount";
            this.labelAndamentoCount.Size = new System.Drawing.Size(54, 65);
            this.labelAndamentoCount.TabIndex = 11;
            this.labelAndamentoCount.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelResolvido);
            this.panel3.Controls.Add(this.labelResolvidoCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(671, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 140);
            this.panel3.TabIndex = 3;
            // 
            // labelResolvido
            // 
            this.labelResolvido.AutoSize = true;
            this.labelResolvido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResolvido.Location = new System.Drawing.Point(26, 18);
            this.labelResolvido.Name = "labelResolvido";
            this.labelResolvido.Size = new System.Drawing.Size(71, 17);
            this.labelResolvido.TabIndex = 12;
            this.labelResolvido.Text = "Resolvidos";
            // 
            // labelResolvidoCount
            // 
            this.labelResolvidoCount.AutoSize = true;
            this.labelResolvidoCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResolvidoCount.Location = new System.Drawing.Point(65, 35);
            this.labelResolvidoCount.Name = "labelResolvidoCount";
            this.labelResolvidoCount.Size = new System.Drawing.Size(54, 65);
            this.labelResolvidoCount.TabIndex = 11;
            this.labelResolvidoCount.Text = "0";
            // 
            // dgvChamadosRecentes
            // 
            this.dgvChamadosRecentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamadosRecentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Titulo,
            this.Categoria,
            this.Prioridade,
            this.Status,
            this.Data,
            this.colAcoes});
            this.dgvChamadosRecentes.Location = new System.Drawing.Point(234, 321);
            this.dgvChamadosRecentes.Name = "dgvChamadosRecentes";
            this.dgvChamadosRecentes.Size = new System.Drawing.Size(768, 150);
            this.dgvChamadosRecentes.TabIndex = 11;
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
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1150, 624);
            this.Controls.Add(this.dgvChamadosRecentes);
            this.Controls.Add(this.tableStats);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableStats.ResumeLayout(false);
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamadosRecentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableStats;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label labelTotalChamados;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelResolvido;
        private System.Windows.Forms.Label labelResolvidoCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelAndamento;
        private System.Windows.Forms.Label labelAndamentoCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAbertos;
        private System.Windows.Forms.Label labelAbertosCount;
        private System.Windows.Forms.DataGridView dgvChamadosRecentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewLinkColumn colAcoes;
    }
}

