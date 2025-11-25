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
            // Define as cores (ajuste conforme seu gosto)
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
                botaoAtivo.ForeColor = Color.Teal; // Ou sua cor de destaque
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
            CarregarTela(new ucDashboard());
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
            // Cria uma nova instância da nossa tela Dashboard
            ucDashboard telaDashboard = new ucDashboard();

            // Carrega ela no painel
            CarregarTela(telaDashboard);
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
                // (Quando tivermos a tela de usuários, carregaremos ela aqui)
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
    }
}
