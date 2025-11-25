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
    }
}
