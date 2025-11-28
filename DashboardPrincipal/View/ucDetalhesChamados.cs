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
            // 1. Busca os dados do banco
            var lista = HistoricoRepository.BuscarPorChamado(_idChamado);

            // 2. LIMPEZA TOTAL (Remove dados antigos e colunas antigas)
            dgvHistorico.DataSource = null; // Desvincula qualquer fonte de dados anterior
            dgvHistorico.Rows.Clear();
            dgvHistorico.Columns.Clear();   // <--- OBRIGATÓRIO PARA RECRIA-LAS ABAIXO

            // 3. CRIA AS COLUNAS MANUALMENTE (Isso resolve o seu erro)
            dgvHistorico.Columns.Add("colInfo", "Informações"); // Coluna 0
            dgvHistorico.Columns.Add("colMsg", "Mensagem");     // Coluna 1

            // 4. FORMATAÇÃO VISUAL DAS COLUNAS
            dgvHistorico.Columns[0].Width = 180; // Largura da coluna de Data/Nome
            dgvHistorico.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Mensagem preenche o resto
            dgvHistorico.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Permite quebra de linha (texto longo)
            dgvHistorico.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Ajusta altura da linha ao conteúdo

            // =================================================================
            // 5. ADICIONAR A DESCRIÇÃO DO CHAMADO (PRIMEIRA LINHA)
            // =================================================================
            if (_chamadoAtual != null)
            {
                string infoInicial = $"{_chamadoAtual.NomeSolicitante} (Solicitante)\n{_chamadoAtual.DataFormatada}";

                // Adiciona a linha e pega o índice dela
                int index = dgvHistorico.Rows.Add(infoInicial, _chamadoAtual.Descricao);

                // Pinta de azul claro para destacar
                dgvHistorico.Rows[index].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            }

            // =================================================================
            // 6. ADICIONAR O HISTÓRICO DO BANCO (LOOP)
            // =================================================================
            foreach (var item in lista)
            {
                string info = $"{item.NomeUsuario}\n{item.DataFormatada}";
                dgvHistorico.Rows.Add(info, item.Mensagem);
            }

            // (Opcional) Tira a seleção da primeira linha para ficar mais bonito
            dgvHistorico.ClearSelection();
        }
        private void AplicarPermissoes()
        {
            // Verifica o tipo do usuário logado na Sessão
            string tipoUsuario = Sessao.UsuarioLogado.Tipo;

            // Se for "Solicitante" (Cliente), ele NÃO pode ver os botões de ação
            if (tipoUsuario == "Solicitante")
            {

                panelAcoes.Visible = false;
            }
            else
            {
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
                

                // Exibe ID formatado (Ex: Chamado TK-0003...)
                lblSubtitulo.Text = $"Chamado {_chamadoAtual.IdFormatado} • Aberto em {_chamadoAtual.DataFormatada}";

                // 3. Preenche a barra lateral (Direita)
                lblStatusValor.Text = _chamadoAtual.Status;
                lblPrioridadeValor.Text = _chamadoAtual.Prioridade;
                lblCategoriaValor.Text = _chamadoAtual.CategoriaNome; 
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
                novoComentario.UsuarioId = Sessao.UsuarioLogado.Id; 
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

        private void dgvHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
