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
            this.Text = "Atribuir Técnico";
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FormAtribuirAtendente_Load(object sender, EventArgs e)
        {
            CarregarAtendentes();
        }
        private void CarregarAtendentes()
        {
            try
            {
                // 1. Busca usuários que são Admin ou Atendente
                // (Certifique-se que este método existe no UsuarioRepository - fizemos ele antes)
                var lista = UsuarioRepository.BuscarAtendentes();

                // 2. Configura o ComboBox
                cmbAtendentes.DataSource = lista;
                cmbAtendentes.DisplayMember = "Nome";
                cmbAtendentes.ValueMember = "Id";

                // Limpa a seleção inicial
                cmbAtendentes.SelectedIndex = -1;
                cmbAtendentes.Text = "-- Selecione um Técnico --";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar atendentes: " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbAtendentes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um atendente da lista.");
                return;
            }

            // Guarda os dados nas propriedades públicas
            IdAtendenteSelecionado = (int)cmbAtendentes.SelectedValue;

            // Pega o objeto inteiro para extrair o nome
            var usuario = (Usuario)cmbAtendentes.SelectedItem;
            NomeAtendenteSelecionado = usuario.Nome;

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
