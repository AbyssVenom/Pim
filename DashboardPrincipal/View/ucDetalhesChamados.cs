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
using System.IO;

namespace Pim.View
{

    public partial class ucDetalhesChamados : UserControl
    {
        private int _idChamado;
        private ChamadoViewModel _chamadoAtual;
        public ucDetalhesChamados(int id)
        {
            InitializeComponent();
            _idChamado = id;
        }

        private void ucDetalhesChamados_Load(object sender, EventArgs e)
        {
            CarregarDados();
            AplicarPermissoes();
            CarregarHistorico();
        }
        private void CarregarHistorico()
        {
            var lista = HistoricoRepository.BuscarPorChamado(_idChamado);

            // Configurações visuais via código para garantir
            dgvHistorico.DataSource = null;
            dgvHistorico.Rows.Clear();
            dgvHistorico.Columns.Clear();

            // Recria colunas manualmente para controle total
            dgvHistorico.Columns.Add("Info", "Info"); // Coluna 0: Nome e Data
            dgvHistorico.Columns.Add("Msg", "Mensagem"); // Coluna 1: O Texto

            dgvHistorico.Columns[0].Width = 180;
            dgvHistorico.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHistorico.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Quebra de linha

            foreach (var item in lista)
            {
                // Adiciona a linha formatada
                // Coluna 1: "Carlos Silva (23/11 16:42)"
                // Coluna 2: "O problema foi resolvido..."
                string info = $"{item.NomeUsuario}\n{item.DataFormatada}";
                dgvHistorico.Rows.Add(info, item.Mensagem);
            }
        }
        private void AplicarPermissoes()
        {
            // Verifica o tipo do usuário logado na Sessão
            string tipoUsuario = Sessao.UsuarioLogado.Tipo;

            // Se for "Solicitante" (Cliente), ele NÃO pode ver os botões de ação
            if (tipoUsuario == "Solicitante")
            {
                // Supondo que você colocou os botões dentro de um GroupBox ou Panel chamado 'panelAcoes'
                // Se não colocou, oculte botão por botão:
                // btnMudarStatus.Visible = false;
                // btnMudarPrioridade.Visible = false;
                // btnAtribuir.Visible = false;

                // Se eles estiverem num painel, é mais fácil:
                panelAcoes.Visible = false;
            }
            else
            {
                // Se for Admin ou Atendente, deixa visível
                panelAcoes.Visible = true;
            }
        }
        private void CarregarDados()
        {
            // 1. Busca os dados completos
            _chamadoAtual = ChamadoRepository.BuscarPorId(_idChamado);

            if (_chamadoAtual != null)
            {
                // 2. Preenche a tela (Esquerda)
                lblTitulo.Text = _chamadoAtual.Titulo; // Ex: "Problema no Login"
                lblDescricao.Text = _chamadoAtual.Descricao;

                // Exibe ID formatado (Ex: Chamado TK-0003...)
                lblSubtitulo.Text = $"Chamado {_chamadoAtual.IdFormatado} • Aberto em {_chamadoAtual.DataFormatada}";

                // 3. Preenche a barra lateral (Direita)
                lblStatusValor.Text = _chamadoAtual.Status;
                lblPrioridadeValor.Text = _chamadoAtual.Prioridade;
                lblCategoriaValor.Text = _chamadoAtual.CategoriaNome; // <-- Vantagem do ViewModel!
                lblSolicitanteValor.Text = _chamadoAtual.NomeSolicitante;

                // Verifica se tem técnico
                if (string.IsNullOrEmpty(_chamadoAtual.NomeTecnico))
                    lblAtendenteValor.Text = "Não atribuído";
                else
                    lblAtendenteValor.Text = _chamadoAtual.NomeTecnico;
            }
        }
        private void btnMudarStatus_Click(object sender, EventArgs e)
        {

            FormAlterarStatus form = new FormAlterarStatus(_chamadoAtual.IdFormatado);
      

            if (form.ShowDialog() == DialogResult.OK)
            {
                ChamadoRepository.AtualizarStatus(_chamadoAtual.Id, form.NovoStatus);

                lblStatusValor.Text = form.NovoStatus;
                _chamadoAtual.Status = form.NovoStatus;

                // Dica: Adicione no histórico que mudou o status
                SalvarHistoricoAutomatico($"Status alterado para '{form.NovoStatus}'.");
            }
        }

        private void btnMudarPrioridade_Click(object sender, EventArgs e)
        {
            // Passa o ID aqui também
            FormAlterarPrioridade form = new FormAlterarPrioridade(_chamadoAtual.IdFormatado);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ChamadoRepository.AtualizarPrioridade(_chamadoAtual.Id, form.NovaPrioridade);
                lblPrioridadeValor.Text = form.NovaPrioridade;
                _chamadoAtual.Prioridade = form.NovaPrioridade;

                SalvarHistoricoAutomatico($"Prioridade alterada para '{form.NovaPrioridade}'.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // 1. Validação básica
            if (string.IsNullOrWhiteSpace(txtResposta.Text))
            {
                MessageBox.Show("Digite uma mensagem para enviar.");
                return;
            }

            try
            {
                // 2. Cria o objeto Histórico
                Historico novoComentario = new Historico();
                novoComentario.ChamadoId = _idChamado;
                novoComentario.UsuarioId = Sessao.UsuarioLogado.Id; // Quem está logado
                novoComentario.Mensagem = txtResposta.Text;
                novoComentario.DataHora = DateTime.Now;

                // 3. Salva no Banco
                HistoricoRepository.Salvar(novoComentario);

                // 4. Limpa o campo e recarrega a lista
                txtResposta.Text = "";
                CarregarHistorico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar mensagem: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void SalvarHistoricoAutomatico(string mensagem)
        {
            try
            {
                Historico log = new Historico();
                log.ChamadoId = _idChamado;
                log.UsuarioId = Sessao.UsuarioLogado.Id; // Quem fez a alteração
                log.Mensagem = mensagem;
                log.DataHora = DateTime.Now;

                // Salva no banco
                HistoricoRepository.Salvar(log);

                // Atualiza a lista de mensagens na tela imediatamente
                CarregarHistorico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar histórico automático: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Segurança básica
            if (_chamadoAtual == null) return;

            // 1. Cria e abre a janelinha
            FormAtribuirAtendente form = new FormAtribuirAtendente();

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 2. Atualiza no Banco de Dados
                    // (Usa o método que criamos anteriormente no ChamadoRepository)
                    ChamadoRepository.AtribuirAtendente(_chamadoAtual.Id, form.IdAtendenteSelecionado);

                    // 3. Atualiza a Tela Visualmente (Label da direita)
                    lblAtendenteValor.Text = form.NomeAtendenteSelecionado;

                    // Atualiza o objeto em memória também
                    _chamadoAtual.NomeTecnico = form.NomeAtendenteSelecionado;
                    _chamadoAtual.TecnicoId = form.IdAtendenteSelecionado;

                    // 4. Registra no Histórico/Chat
                    SalvarHistoricoAutomatico($"Chamado atribuído ao técnico: {form.NomeAtendenteSelecionado}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atribuir: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_chamadoAtual.AnexoPath) && File.Exists(_chamadoAtual.AnexoPath))
            {
                // Abre o arquivo com o programa padrão do Windows (Visualizador de fotos, PDF, etc)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = _chamadoAtual.AnexoPath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Este chamado não tem anexo ou o arquivo foi movido.");
            }
        }
    }

}
