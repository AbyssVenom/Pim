using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Pim
{

    public partial class FormCategoriaDetalhe : Form
    {
        public Categoria CategoriaEditada { get; private set; }
        public FormCategoriaDetalhe()
        {
            InitializeComponent();
            this.Text = "Criar Nova Categoria";
            // Cria uma nova instância vazia
            CategoriaEditada = new Categoria();
        }
        public FormCategoriaDetalhe(Categoria categoriaParaEditar)
        {
            InitializeComponent();
            this.Text = "Editar Categoria";

            // Carrega a instância existente
            CategoriaEditada = categoriaParaEditar;

            // Preenche os campos da tela com os dados
            txtNome.Text = CategoriaEditada.Nome;
            txtDescricao.Text = CategoriaEditada.Descricao;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Atualizar o objeto CategoriaEditada com os dados da tela
            CategoriaEditada.Nome = txtNome.Text;
            CategoriaEditada.Descricao = txtDescricao.Text;

            // 3. Fechar o formulário com "OK"
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            // 1. Validação Simples: O Nome é obrigatório
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, digite o nome da categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus(); // Coloca o cursor de volta na caixa de texto
                return; 
            }

            // 2. Preenche o objeto com os dados da tela
            CategoriaEditada.Nome = txtNome.Text;
            CategoriaEditada.Descricao = txtDescricao.Text;

            // 3. Define o resultado como OK (Sucesso)
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormCategoriaDetalhe_Load(object sender, EventArgs e)
        {

        }
    }
}
