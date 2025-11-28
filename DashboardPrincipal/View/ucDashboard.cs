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

namespace Pim
{
    public partial class ucDashboard : UserControl
    {
        public event EventHandler BotaoAbrirChamadoClicado;
        public event EventHandler<int> VerDetalhesClick;
        public ucDashboard()
        {
            InitializeComponent();
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            CarregarEstatisticas();
            CarregarGridRecentes();
        }
        private int? ObterIdUsuarioFiltro()
        {
            if (Sessao.UsuarioLogado.Tipo == "Solicitante")
            {
                return Sessao.UsuarioLogado.Id; // Retorna o ID dele
            }
            return null; // Retorna null (Admin/Atendente vê tudo)
        }

        private void CarregarEstatisticas()
        {
            try
            {
                // 1. Define quem é o usuário para filtrar
                int? idUsuario = ObterIdUsuarioFiltro();

                // 2. Busca a lista filtrada (Texto vazio, Status "Todos", Usuário Específico)
                var listaChamados = ChamadoRepository.BuscarComFiltros("", "Todos", idUsuario);

                // 3. Calcula os totais baseados nessa lista filtrada
                int total = listaChamados.Count;
                int abertos = listaChamados.Count(c => c.Status == "Aberto");
                int emAndamento = listaChamados.Count(c => c.Status == "Em Andamento");
                int resolvidos = listaChamados.Count(c => c.Status == "Resolvido");

                // 4. Atualiza os labels na tela
                lblTotalCount.Text = total.ToString();
                lblAbertosCount.Text = abertos.ToString();
                lblAndamentoCount.Text = emAndamento.ToString();
                lblResolvidosCount.Text = resolvidos.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estatísticas: " + ex.Message);
            }
        }

        // Crie este método para preencher a grade
        private void CarregarGridRecentes()
        {
            try
            {
                // Garante que a grade não crie colunas sozinhas
                dgvChamadosRecentes.AutoGenerateColumns = false;

                // 1. Pega o ID do usuário (se for Solicitante)
                int? idUsuario = ObterIdUsuarioFiltro();

                // 2. Busca a lista completa filtrada
                var lista = ChamadoRepository.BuscarComFiltros("", "Todos", idUsuario);

                // Pega apenas os 10 primeiros itens da lista para não travar a tela
                var recentes = lista.Take(10).ToList();

                // 4. Joga na grade
                dgvChamadosRecentes.DataSource = recentes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar chamados recentes: " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvChamadosRecentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se clicou na coluna de "Ações" e não é cabeçalho
            // IMPORTANTE: Verifique se o nome da sua coluna no Designer é "colAcoes" ou similar
            if (e.RowIndex >= 0 && dgvChamadosRecentes.Columns[e.ColumnIndex].Name == "colAcoes")
            {
                // Pega o objeto da linha clicada
                var chamadoSelecionado = (ChamadoViewModel)dgvChamadosRecentes.Rows[e.RowIndex].DataBoundItem;

                // DISPARA O EVENTO enviando o ID para o FormPrincipal
                VerDetalhesClick?.Invoke(this, chamadoSelecionado.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BotaoAbrirChamadoClicado?.Invoke(this, EventArgs.Empty);
        }
    }
}
