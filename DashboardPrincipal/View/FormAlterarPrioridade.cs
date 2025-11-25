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
        public string NovaPrioridade{ get; private set; }
        public FormAlterarPrioridade()
        {
            InitializeComponent();
            cmbPrioridade.Items.Add("Baixa");
            cmbPrioridade.Items.Add("Media");
            cmbPrioridade.Items.Add("Alta");
            cmbPrioridade.SelectedIndex = 0;
        }

        private void cmbPrioridade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            NovaPrioridade = cmbPrioridade.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK; // Fecha com Sucesso
        }
    }
}
