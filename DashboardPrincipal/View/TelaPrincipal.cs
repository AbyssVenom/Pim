using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DashboardPrincipal;
using Pim.Model;
using Pim.View;

namespace Pim
{
    
    public partial class TelaPrincipal : Form
    {
        Dashboard teladashboard;
        TelaChamados telachamados;
        public TelaPrincipal()
        {
            InitializeComponent();
            panelConteudo.Dock = DockStyle.Fill;
        }
        private void SetarBotaoAtivo(Button botaoAtivo)
        {
            // Define as cores 
            Color corInativa = Color.White;
            Color corAtiva = Color.Gainsboro; // Ou Color.LightGray

            // Reseta todos os botões do menu
            foreach (Control c in panelMenu.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = corInativa;
                    c.ForeColor = Color.Black;
                }
            }

            // Destaca o botão atual
            if (botaoAtivo != null)
            {
                botaoAtivo.BackColor = corAtiva;
                botaoAtivo.ForeColor = Color.Teal; 
            }
        }
        private void CarregarTela(UserControl tela)
        {
            // Limpa o painel de qualquer controle existente
            panelConteudo.Controls.Clear();

            // Define a tela para preencher todo o painel
            tela.Dock = DockStyle.Fill;

            // Adiciona a nova tela ao painel
            panelConteudo.Controls.Add(tela);
        }
     
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SetarBotaoAtivo(btnDashboard);

            // 1. Cria a nova dashboard
            ucDashboard telaDash = new ucDashboard();

            // 2. Liga o evento do botão novamente!
            telaDash.BotaoAbrirChamadoClicado += (s, ev) =>
            {
                AbrirTelaDeCriacaoDeChamado();
            };
            telaDash.VerDetalhesClick += (s, idChamado) =>
            {
                ucDetalhesChamados telaDetalhes = new ucDetalhesChamados(idChamado);
                CarregarTela(telaDetalhes);
            };

            // 3. Mostra a tela
            CarregarTela(telaDash);
        }

        private void Teladashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            teladashboard = null;
        }

        private void bchamados_Click(object sender, EventArgs e)
        {
            SetarBotaoAtivo(btnMeusChamados);
            ucMeusChamados telaChamados = new ucMeusChamados();

            telaChamados.BotaoAbrirChamadoClicado += (s, ev) =>
            {
                ucAbrirChamado telaAbrir = new ucAbrirChamado();
                // 3. Quando o aviso chegar, carregue a tela de Abrir Chamado
                telaAbrir.CancelarClick += (s2, ev2) => bchamados_Click(null, null);

                // 3. Carrega a tela de abrir chamado
                CarregarTela(telaAbrir);
            };

            telaChamados.VerDetalhesClick += (s, idChamado) =>
            {
                // Cria a tela de detalhes passando o ID que veio do evento
                ucDetalhesChamados telaDetalhes = new ucDetalhesChamados(idChamado);
                CarregarTela(telaDetalhes);
            };
            CarregarTela(telaChamados);
        }


        private void Telachamados_FormClosed(object sender, FormClosedEventArgs e)
        {
            telachamados = null;
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            // Se não tiver usuário logado, para tudo.
            if (Sessao.UsuarioLogado == null) return;

            // 2. Configura a Visibilidade do Menu 
            if (Sessao.UsuarioLogado.Tipo == "Solicitante")
            {
                // Solicitante vê pouca coisa
                btnDashboard.Visible = true;
                btnRelatorios.Visible = false;
                btnConfiguracoes.Visible = false;
                btnMeusChamados.Visible = true;
            }
            else if (Sessao.UsuarioLogado.Tipo == "Atendente")
            {
                // Atendente vê tudo, menos configuração de sistema
                btnDashboard.Visible = true;
                btnRelatorios.Visible = false;
                btnMeusChamados.Visible = true;
                btnConfiguracoes.Visible = false;
            }
            else // Admin
            {
                // Admin vê tudo
                btnDashboard.Visible = true;
                btnRelatorios.Visible = true;
                btnMeusChamados.Visible = true;
                btnConfiguracoes.Visible = true;
            }

            // 3. Decide qual tela abrir inicialmente
            if (Sessao.UsuarioLogado.Tipo != "Solicitante")
            {
                // --- SE FOR ADMIN OU ATENDENTE: ABRE A DASHBOARD ---
                SetarBotaoAtivo(btnDashboard);

                ucDashboard telaDash = new ucDashboard();

                telaDash.BotaoAbrirChamadoClicado += (s, ev) =>
                {
                    AbrirTelaDeCriacaoDeChamado();
                };
                telaDash.VerDetalhesClick += (s, idChamado) =>
                {
                    // Abre a tela de detalhes passando o ID
                    ucDetalhesChamados telaDetalhes = new ucDetalhesChamados(idChamado);
                    CarregarTela(telaDetalhes);
                };

                CarregarTela(telaDash);
            }
            else
            {
                // --- SE FOR SOLICITANTE: VAI DIRETO PARA MEUS CHAMADOS ---
                // Simula o clique no botão "Meus Chamados" para carregar a lista direto
                bchamados_Click(sender, e);
            }
        }
        private void AbrirTelaDeCriacaoDeChamado()
        {
            ucAbrirChamado telaAbrir = new ucAbrirChamado();

            // Se o usuário clicar em Cancelar, volta para a tela anterior
            telaAbrir.CancelarClick += (s2, ev2) =>
            {
                // Se for Solicitante, volta para Meus Chamados
                if (Sessao.UsuarioLogado.Tipo == "Solicitante")
                    bchamados_Click(null, null);
                else
                    // Se for Admin/Atendente, volta para Dashboard
                    button11_Click(null, null);
            };

            CarregarTela(telaAbrir);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Cria a tela de menu de configurações
            ucConfiguracoes telaConfig = new ucConfiguracoes();

            // 2. Assina (escuta) os eventos que vêm dela
            telaConfig.GerirCategoriasClick += (s, ev) =>
            {
                // Se o usuário clicar em "Gerir Categorias", carregue a tela de categorias
                CarregarTela(new ucGerirCategorias());
            };

            telaConfig.GerirUtilizadoresClick += (s, ev) =>
            {
                CarregarTela(new ucGerirUsuario());
            };

            // 3. Carrega a tela de menu de configurações
            CarregarTela(telaConfig);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 1. Destaca o botão visualmente (muda a cor)
            SetarBotaoAtivo(btnRelatorios);

            // 2. Cria e carrega a tela de relatórios
            CarregarTela(new ucRelatorios());
        }

        private void panelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetarBotaoAtivo(button6);

            ucBaseConhecimento telaKB = new ucBaseConhecimento();

            // Quando clicar em um card:
            telaKB.ArtigoSelecionado += (s, idArtigo) =>
            {
                // Cria a tela de detalhe
                ucDetalheArtigo telaLeitura = new ucDetalheArtigo(idArtigo);

                // Configura o botão voltar
                telaLeitura.VoltarClick += (s2, ev2) =>
                {
                    button6_Click(null, null); // Recarrega a lista
                };

                CarregarTela(telaLeitura);
            };

            CarregarTela(telaKB);
        }

        private void btnConfigPerfil_Click(object sender, EventArgs e)
        {
            SetarBotaoAtivo(btnConfigPerfil);
            // Abre a tela de perfil pessoal
            CarregarTela(new ucMeuPerfil());
        }
    }
}
