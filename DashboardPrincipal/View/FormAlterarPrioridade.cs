using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pim.View
{
    public partial class FormAlterarPrioridade : Form
    {
        public string NovaPrioridade { get; private set; }
        public FormAlterarPrioridade(string tituloChamado)
        {
            InitializeComponent();
            lblTituloJanela.Text = $"Alterar Prioridade de {tituloChamado}";

            // Adiciona as opções
            cmbPrioridade.Items.Add("Baixa");
            cmbPrioridade.Items.Add("Média");
            cmbPrioridade.Items.Add("Alta");

            // Seleciona um padrão
            cmbPrioridade.SelectedIndex = 1; // Média
        }

        private void FormAlterarPrioridade_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbPrioridade.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma prioridade.");
                return;
            }

            NovaPrioridade = cmbPrioridade.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
