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
using Dapper;

namespace Pim
{
    public partial class ucGerirCategorias : UserControl
    {
       
        public ucGerirCategorias()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void AtualizarGrade()
        {
            dgvCategorias.DataSource = null;
            // 7. Busque os dados direto do repositório
            dgvCategorias.DataSource = CategoriaRepository.BuscarTodas();
        }

        private void ucGerirCategorias_Load(object sender, EventArgs e)
        {
            
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.Columns["Nome"].DataPropertyName = "Nome";
            dgvCategorias.Columns["Descricao"].DataPropertyName = "Descricao";

            // 5. Chame o método para carregar os dados
            AtualizarGrade();
        }

        private void btCriar_Click(object sender, EventArgs e)
        {
            FormCategoriaDetalhe formDetalhe = new FormCategoriaDetalhe();
            DialogResult resultado = formDetalhe.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Categoria novaCategoria = formDetalhe.CategoriaEditada;

                // 9. Salve usando o repositório
                CategoriaRepository.Salvar(novaCategoria);

                AtualizarGrade();
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Categoria categoriaSelecionada = (Categoria)dgvCategorias.Rows[e.RowIndex].DataBoundItem;

            // ---- AÇÃO DE EDITAR ----
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "colEditar")
            {
                FormCategoriaDetalhe formDetalhe = new FormCategoriaDetalhe(categoriaSelecionada);
                DialogResult resultado = formDetalhe.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    // 11. Salve (atualize) usando o repositório
                    //    (O objeto 'categoriaSelecionada' já foi atualizado no formDetalhe)
                    CategoriaRepository.Salvar(categoriaSelecionada);
                    AtualizarGrade();
                }
            }

            if (dgvCategorias.Columns[e.ColumnIndex].Name == "colExcluir")
            {
                DialogResult confirmacao = MessageBox.Show(
    $"Tem certeza que deseja excluir a categoria '{categoriaSelecionada.Nome}'?",
    "Confirmar Exclusão",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);
                if (confirmacao == DialogResult.Yes)
                {
                    // 12. Exclua usando o repositório
                    CategoriaRepository.Excluir(categoriaSelecionada);
                    AtualizarGrade();
                }
            }
        }
    }

}
