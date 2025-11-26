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
    public partial class ucDetalheArtigo : UserControl
    {
        public event EventHandler VoltarClick;
        public ucDetalheArtigo(int id)
        {
            InitializeComponent();
            CarregarDados(id);
        }
        private void CarregarDados(int id)
        {
            var artigo = ArtigoRepository.BuscarPorId(id);
            if (artigo != null)
            {
                lblTitulo.Text = artigo.Titulo;
                lblCategoria.Text = artigo.Categoria;

                // Se quiser apenas texto:
                txtConteudo.Text = artigo.Conteudo;
            }
        }

        private void ucDetalheArtigo_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            VoltarClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
