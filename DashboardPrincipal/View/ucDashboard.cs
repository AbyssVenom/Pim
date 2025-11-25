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
        public ucDashboard()
        {
            InitializeComponent();
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            CarregarEstatisticas();
            CarregarGridRecentes();
        }
        private void CarregarEstatisticas()
        {
            try
            {
                // 1. Busca a lista de todos os chamados
                var listaChamados = ChamadoRepository.BuscarTodosViewModel();

                // 2. Filtra a lista para obter as contagens
                int total = listaChamados.Count;
                int abertos = listaChamados.Count(c => c.Status == "Aberto");
                int emAndamento = listaChamados.Count(c => c.Status == "Em Andamento");
                int resolvidos = listaChamados.Count(c => c.Status == "Resolvido");

                // 3. Atualiza os labels na tela
                labelTotalCount.Text = total.ToString();
                labelAbertosCount.Text = abertos.ToString();
                labelAndamentoCount.Text = emAndamento.ToString();
                labelResolvidoCount.Text = resolvidos.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estatísticas: " + ex.Message, "Erro");
            }
        }

        // Crie este método para preencher a grade
        private void CarregarGridRecentes()
        {
            try
            {
                // Configura as colunas (Substitua pelos seus DataPropertyNames reais)
                dgvChamadosRecentes.AutoGenerateColumns = false;
                dgvChamadosRecentes.Columns["Id"].DataPropertyName = "IdFormatado";
                dgvChamadosRecentes.Columns["Titulo"].DataPropertyName = "Titulo";
                dgvChamadosRecentes.Columns["Categoria"].DataPropertyName = "CategoriaNome";
                dgvChamadosRecentes.Columns["Status"].DataPropertyName = "Status";
                dgvChamadosRecentes.Columns["Data"].DataPropertyName = "DataFormatada";

                // Busca os dados e preenche a grade
                dgvChamadosRecentes.DataSource = ChamadoRepository.BuscarTodosViewModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar chamados recentes: " + ex.Message, "Erro");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvChamadosRecentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
