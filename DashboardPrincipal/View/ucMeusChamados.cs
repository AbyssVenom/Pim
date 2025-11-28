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
    public partial class ucMeusChamados : UserControl
    {
        public event EventHandler BotaoAbrirChamadoClicado;
        public event EventHandler<int> VerDetalhesClick;
        public ucMeusChamados()
        {
            InitializeComponent();
        }

        private void ucMeusChamados_Load(object sender, EventArgs e)
        {
            dgvChamados.AutoGenerateColumns = false;

            // Carrega os dados
            AtualizarGrade();
            AtualizarEstatisticas();
        }
        private void AtualizarGrade()
        {
            try
            {
                // 1. Pega os valores dos filtros
                string termo = txtPesquisa.Text;
                string status = cmbFiltroStatus.SelectedItem?.ToString() ?? "Todos";

                // 2. Verifica se é um Solicitante (para filtrar só os chamados dele)
                int? idUsuarioLogado = null;
                if (Sessao.UsuarioLogado.Tipo == "Solicitante")
                {
                    idUsuarioLogado = Sessao.UsuarioLogado.Id;
                }

                // 3. Busca no banco usando o novo método
                var lista = ChamadoRepository.BuscarComFiltros(termo, status, idUsuarioLogado);

                // 4. Atualiza a grade
                dgvChamados.DataSource = null;
                dgvChamados.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar: " + ex.Message);
            }
            AtualizarEstatisticas();
        }
        private void AtualizarEstatisticas()
        {
            // 1. Define quem é o usuário para filtrar
            int? idUsuario = null;

            // Se for Solicitante, filtra pelo ID dele.
            // Se for Admin/Atendente, deixa null para pegar TODOS os chamados do sistema.
            if (Sessao.UsuarioLogado.Tipo == "Solicitante")
            {
                idUsuario = Sessao.UsuarioLogado.Id;
            }

            // 2. Busca a lista completa (sem filtro de texto, mas com filtro de usuário se houver)
            var listaParaStats = ChamadoRepository.BuscarComFiltros("", "Todos", idUsuario);

            // 3. Calcula os totais baseados nessa lista
            int total = listaParaStats.Count;
            int abertos = listaParaStats.Count(c => c.Status == "Aberto");
            int andamento = listaParaStats.Count(c => c.Status == "Em Andamento");
            int resolvidos = listaParaStats.Count(c => c.Status == "Resolvido");

            // 4. Atualiza os Labels
            lblTotalCount.Text = total.ToString();
            lblAbertosCount.Text = abertos.ToString();
            lblAndamentoCount.Text = andamento.ToString();
            lblResolvidosCount.Text = resolvidos.ToString();
        }


        private void btAbrirChamado_Click(object sender, EventArgs e)
        {
            // 3. Dispare o "aviso" para quem estiver ouvindo (o FormPrincipal)
            BotaoAbrirChamadoClicado?.Invoke(this, EventArgs.Empty);
        }

        private void dgvChamados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se clicou na coluna de "Ações" (colAcoes) e não é cabeçalho
            if (e.RowIndex >= 0 && dgvChamados.Columns[e.ColumnIndex].Name == "colAcoes")
            {
                // Pega o objeto da linha clicada
                var chamadoSelecionado = (ChamadoViewModel)dgvChamados.Rows[e.RowIndex].DataBoundItem;

                // DISPARA O EVENTO enviando o ID real (int) do chamado
                VerDetalhesClick?.Invoke(this, chamadoSelecionado.Id);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            AtualizarGrade();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
