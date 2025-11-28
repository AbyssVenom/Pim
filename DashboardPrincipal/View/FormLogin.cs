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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CentralizarElementos();
        }
        private void FormLogin_Resize(object sender, EventArgs e)
        {
            CentralizarElementos();
        }
        private void CentralizarElementos()
        {
            // 1. Centraliza o CARD (Painel Branco) exatamente no meio da tela
            int xCard = (this.ClientSize.Width - pnlCard.Width) / 2;
            int yCard = (this.ClientSize.Height - pnlCard.Height) / 2;
            pnlCard.Location = new Point(xCard, yCard);

            // ---------------------------------------------------------

            // 2. Posiciona o SUBTÍTULO (Imediatamente acima do Card)
            if (lblSubtitulo != null)
            {
                int xSub = (this.ClientSize.Width - lblSubtitulo.Width) / 2;
                int ySub = pnlCard.Top - lblSubtitulo.Height - 20;

                lblSubtitulo.Location = new Point(xSub, ySub);
            }

            // ---------------------------------------------------------

            // 3. Posiciona o LOGO "SolvIT + Support" (Acima do Subtítulo)
            if (lblSolvit != null)
            {
                int yLogo = lblSubtitulo.Top - lblSolvit.Height - 10;

                // Centraliza o "SolvIT"
                int xSolvit = (this.ClientSize.Width - lblSolvit.Width) / 2;

                // Se o "Support" existe, ajusta o centro visualmente para a esquerda
                if (lblSupport != null)
                {
                    xSolvit -= (lblSupport.Width / 2);
                }

                lblSolvit.Location = new Point(xSolvit, yLogo);

                // 4. Cola o "Support" do lado direito do "SolvIT"
                if (lblSupport != null)
                {
                    int xSupport = lblSolvit.Right + 6; 
                                                        
                    int ySupport = lblSolvit.Top + ((lblSolvit.Height - lblSupport.Height) / 2);

                    lblSupport.Location = new Point(xSupport, ySupport);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha o email e a senha.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tenta autenticar o usuário
            Usuario usuarioLogado = UsuarioRepository.Autenticar(email, senha);

            if (usuarioLogado != null)
            {
                // Login bem-sucedido
                MessageBox.Show($"Bem-vindo, {usuarioLogado.Nome} ({usuarioLogado.Tipo})!", "Login Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Armazena o usuário logado em algum lugar acessível para o resto do sistema
                Sessao.UsuarioLogado = usuarioLogado;

                this.DialogResult = DialogResult.OK; // Sinaliza que o login foi OK
                this.Close();
            }
            else
            {
                // Login falhou
                MessageBox.Show("Email ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Clear(); // Limpa a senha para nova tentativa
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Sinaliza que o usuário cancelou/saiu
            this.Close();
        }
    }
}
