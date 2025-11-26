namespace Pim
{
    partial class ucConfiguracoes
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
            this.label1 = new System.Windows.Forms.Label();
            this.btGerirCategorias = new System.Windows.Forms.Button();
            this.btGerirUtilizadores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configurações do Sistema";
            // 
            // btGerirCategorias
            // 
            this.btGerirCategorias.Location = new System.Drawing.Point(89, 116);
            this.btGerirCategorias.Name = "btGerirCategorias";
            this.btGerirCategorias.Size = new System.Drawing.Size(235, 41);
            this.btGerirCategorias.TabIndex = 1;
            this.btGerirCategorias.Text = "Gerir Categorias";
            this.btGerirCategorias.UseVisualStyleBackColor = true;
            this.btGerirCategorias.Click += new System.EventHandler(this.btGerirCategorias_Click);
            // 
            // btGerirUtilizadores
            // 
            this.btGerirUtilizadores.Location = new System.Drawing.Point(89, 183);
            this.btGerirUtilizadores.Name = "btGerirUtilizadores";
            this.btGerirUtilizadores.Size = new System.Drawing.Size(235, 41);
            this.btGerirUtilizadores.TabIndex = 2;
            this.btGerirUtilizadores.Text = "Gerir Utilizadores";
            this.btGerirUtilizadores.UseVisualStyleBackColor = true;
            this.btGerirUtilizadores.Click += new System.EventHandler(this.btGerirUtilizadores_Click);
            // 
            // ucConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btGerirUtilizadores);
            this.Controls.Add(this.btGerirCategorias);
            this.Controls.Add(this.label1);
            this.Name = "ucConfiguracoes";
            this.Size = new System.Drawing.Size(1010, 628);
            this.Load += new System.EventHandler(this.ucConfigurações_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGerirCategorias;
        private System.Windows.Forms.Button btGerirUtilizadores;
    }
}
