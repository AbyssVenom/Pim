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
    public partial class FormUsuarioDetalhe : Form
    {
        public Usuario UsuarioEditado { get; private set; }
        public FormUsuarioDetalhe()
        {
            InitializeComponent();
            UsuarioEditado = new Usuario();
            this.Text = "Novo Usuário";
            cmbTipo.SelectedIndex = 2;
        }
        public FormUsuarioDetalhe(Usuario usuario)
        {
            InitializeComponent();
            UsuarioEditado = usuario;
            this.Text = "Editar Usuário";

            // Preenche os campos
            txtNome.Text = usuario.Nome;
            txtEmail.Text = usuario.Email;

            // Seleciona o item correto no ComboBox
            if (cmbTipo.Items.Contains(usuario.Tipo))
                cmbTipo.SelectedItem = usuario.Tipo;

            
        }

        private void FormUsuarioDetalhe_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Nome e Email são obrigatórios.");
                return;
            }

            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Tipo de usuário.");
                return;
            }

            // Preenche o objeto
            UsuarioEditado.Nome = txtNome.Text;
            UsuarioEditado.Email = txtEmail.Text;
            UsuarioEditado.Tipo = cmbTipo.SelectedItem.ToString();

            // Data de registro (se for novo)
            if (UsuarioEditado.Id == 0) UsuarioEditado.DataRegistro = DateTime.Now;

            // Lógica da Senha
            if (!string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                // Se digitou algo, gera o hash
                UsuarioEditado.SenhaHash = DatabaseService.HashSenhaSimples(txtSenha.Text);
            }
            else if (UsuarioEditado.Id == 0)
            {
                // Se é novo e não digitou senha
                MessageBox.Show("Defina uma senha para o novo usuário.");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
