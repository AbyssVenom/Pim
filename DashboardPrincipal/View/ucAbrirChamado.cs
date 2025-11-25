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
    public partial class ucAbrirChamado : UserControl
    {
        public event EventHandler CancelarClick;
        public ucAbrirChamado()
        {
            InitializeComponent();
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btAbrirChamado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("O campo 'Título' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma 'Categoria'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbPrioridade.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma 'Prioridade'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Criar o objeto Chamado com os dados da tela
            Chamado novoChamado = new Chamado();
            novoChamado.Titulo = txtTitulo.Text;
            novoChamado.Descricao = txtDescricao.Text;
            novoChamado.DataAbertura = DateTime.Now;
            novoChamado.Status = "Aberto"; // Status inicial padrão

            // Pega o ID da categoria selecionada no ComboBox
            novoChamado.CategoriaId = (int)cmbCategoria.SelectedValue;

            // Pega o texto da prioridade
            novoChamado.Prioridade = cmbPrioridade.SelectedItem.ToString();

            try
            {
                // 3. Salvar no banco usando o novo repositório
                ChamadoRepository.Salvar(novoChamado);

                MessageBox.Show("Chamado aberto com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Limpar o formulário para um próximo chamado
                LimparCampos();

                // 5. (Opcional) Dispara o evento de cancelar para voltar à lista
                CancelarClick?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o chamado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            CancelarClick?.Invoke(this, EventArgs.Empty);

        }
        private void LimparCampos()
        {
            txtTitulo.Text = "";
            txtDescricao.Text = "";
            cmbCategoria.SelectedIndex = -1;
            cmbPrioridade.SelectedIndex = -1;
            cmbCategoria.Text = "-- Selecione uma Categoria --";
            cmbPrioridade.Text = "-- Selecione uma Prioridade --";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ucAbrirChamado_Load(object sender, EventArgs e)
        {
            // 1. Busca as categorias do nosso repositório central
            //    (Certifique-se que o CategoriaRepository.cs existe e funciona)
            var categorias = CategoriaRepository.BuscarTodas();

            // 2. Carrega a lista no ComboBox
            cmbCategoria.DataSource = categorias;

            // 3. (Importante!) Define qual coluna mostrar e qual usar como valor
            cmbCategoria.DisplayMember = "Nome"; // O que o usuário vê
            cmbCategoria.ValueMember = "Id";   // O que o código usa

            // 4. Limpa a seleção inicial
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = "-- Selecione uma Categoria --";

            // --- Para a Prioridade (Manual) ---
            cmbPrioridade.Items.Clear(); // Limpa itens de design-time
            cmbPrioridade.Items.Add("Baixa");
            cmbPrioridade.Items.Add("Média");
            cmbPrioridade.Items.Add("Alta");
            cmbPrioridade.Text = "-- Selecione uma Prioridade --";
        }
    }
}
