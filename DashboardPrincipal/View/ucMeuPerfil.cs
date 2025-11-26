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
    public partial class ucMeuPerfil : UserControl
    {
        public ucMeuPerfil()
        {
            InitializeComponent();
        }
        private void ucMeuPerfil_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private void CarregarDados()
        {
            // Pega o usuário da sessão (memória)
            // var u = Sessao.UsuarioLogado;

            var usuarioDoBanco = UsuarioRepository.BuscarPorId(Sessao.UsuarioLogado.Id);

            // 2. Atualiza a nossa "Sessão" global para ficar sincronizada
            Sessao.UsuarioLogado = usuarioDoBanco;

            // Preenche os campos da Aba Perfil
            txtNome.Text = usuarioDoBanco.Nome;
            // IMPORTANTE: Usamos '?? ""' para evitar erro se o campo estiver vazio (NULL) no banco
            txtTelefone.Text = usuarioDoBanco.Telefone ?? "";
            txtDepartamento.Text = usuarioDoBanco.Departamento ?? "";
            txtBio.Text = usuarioDoBanco.Bio ?? "";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtDepartamento_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Atualiza o objeto da sessão com o que foi digitado
                Sessao.UsuarioLogado.Nome = txtNome.Text;
                Sessao.UsuarioLogado.Telefone = txtTelefone.Text;
                Sessao.UsuarioLogado.Departamento = txtDepartamento.Text;
                Sessao.UsuarioLogado.Bio = txtBio.Text;

                // 2. Salva no Banco
                UsuarioRepository.AtualizarPerfil(Sessao.UsuarioLogado);

                MessageBox.Show("Perfil atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar perfil: " + ex.Message);
            }
        }

        private void btnSalvarSenha_Click(object sender, EventArgs e)
        {
            // 1. Validações de campo vazio
            if (string.IsNullOrWhiteSpace(txtSenhaAtual.Text) ||
                string.IsNullOrWhiteSpace(txtNovaSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            // 2. Verifica se a senha atual está correta
            // Gera o hash do que o usuário digitou
            string hashAtualDigitado = DatabaseService.HashSenhaSimples(txtSenhaAtual.Text);

            // Compara com o hash que está na sessão (banco)
            if (hashAtualDigitado != Sessao.UsuarioLogado.SenhaHash)
            {
                MessageBox.Show("A senha atual está incorreta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Verifica se a confirmação bate
            if (txtNovaSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("A nova senha e a confirmação não coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 4. Gera hash da nova senha
                string novoHash = DatabaseService.HashSenhaSimples(txtNovaSenha.Text);

                // 5. Salva no Banco
                UsuarioRepository.AlterarSenha(Sessao.UsuarioLogado.Id, novoHash);

                // 6. Atualiza a sessão
                Sessao.UsuarioLogado.SenhaHash = novoHash;

                MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa os campos
                txtSenhaAtual.Clear();
                txtNovaSenha.Clear();
                txtConfirmarSenha.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar senha: " + ex.Message);
            }
        }

        private void lTelefone_Click(object sender, EventArgs e)
        {

        }
    }
}
