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

namespace Pim.View
{
    public partial class ucGerirUsuario : UserControl
    {
        public ucGerirUsuario()
        {
            InitializeComponent();
        }
        private void ucGerirUsuarios_Load(object sender, EventArgs e)
        {
            AtualizarGrade();
        }
        private void AtualizarGrade()
        {
            // Certifique-se que o método BuscarTodos existe no UsuarioRepository
            var lista = UsuarioRepository.BuscarTodos();
            dgvUsuarios.AutoGenerateColumns = false; // Importante pois configuramos manualmente
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = lista;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Pega o usuário da linha clicada
            var usuarioSelecionado = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;

            // Botão Editar
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "colEditar")
            {
                FormUsuarioDetalhe form = new FormUsuarioDetalhe(usuarioSelecionado);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UsuarioRepository.Salvar(form.UsuarioEditado);
                    AtualizarGrade();
                }
            }

            // Botão Excluir
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "colExcluir")
            {
                if (MessageBox.Show($"Excluir {usuarioSelecionado.Nome}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    UsuarioRepository.Excluir(usuarioSelecionado.Id);
                    AtualizarGrade();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormUsuarioDetalhe form = new FormUsuarioDetalhe();
            if (form.ShowDialog() == DialogResult.OK)
            {
                UsuarioRepository.Salvar(form.UsuarioEditado);
                AtualizarGrade();
            }
        }
    }
}
