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
    public partial class FormAlterarStatus : Form
    {
        public string NovoStatus { get; private set; }
        public FormAlterarStatus()
        {
            InitializeComponent();
            // Adicione as opções manualmente ou via código
            cmbStatus.Items.Add("Aberto");
            cmbStatus.Items.Add("Em Andamento");
            cmbStatus.Items.Add("Resolvido");
            cmbStatus.SelectedIndex = 0;
        }

        private void FormAlterarStatus_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            NovoStatus = cmbStatus.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK; // Fecha com Sucesso
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
