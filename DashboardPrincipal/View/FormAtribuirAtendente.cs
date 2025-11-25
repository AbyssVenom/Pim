using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pim.Model;

namespace Pim.View
{
    public partial class FormAtribuirAtendente : Form
    {
        public int? IdAtendenteSelecionado { get; private set; }
        public string NomeAtendenteSelecionado { get; private set; }
        public FormAtribuirAtendente()
        {
            InitializeComponent();
        }

        private void FormAtribuirAtendente_Load(object sender, EventArgs e)
        {
            // 1. Busca os atendentes no banco
            var lista = UsuarioRepository.BuscarAtendentes();

            // 2. Configura o ComboBox
            cmbAtendentes.DataSource = lista;
            cmbAtendentes.DisplayMember = "Nome"; // Mostra o Nome
            cmbAtendentes.ValueMember = "Id";     // Guarda o ID

            // Opcional: Adicionar opção "Nenhum" (requer lógica extra, mas vamos manter simples por enquanto)
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbAtendentes.SelectedValue != null)
            {
                IdAtendenteSelecionado = (int)cmbAtendentes.SelectedValue;
                // Pega o objeto inteiro para saber o nome também (útil para a UI)
                Usuario u = (Usuario)cmbAtendentes.SelectedItem;
                NomeAtendenteSelecionado = u.Nome;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Selecione um atendente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
