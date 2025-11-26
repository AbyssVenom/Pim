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
    public partial class ucBaseConhecimento : UserControl
    {
        public event EventHandler<int> ArtigoSelecionado;
        public ucBaseConhecimento()
        {
            InitializeComponent();
        }
        private void ucBaseConhecimento_Load(object sender, EventArgs e)
        {
            CarregarLista("");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarLista(txtPesquisa.Text);
        }
        private void CarregarLista(string termo)
        {
            flowArtigos.Controls.Clear();
            var lista = ArtigoRepository.BuscarTodos(termo);

            foreach (var artigo in lista)
            {
                // Cria o card visualmente
                ucItemArtigo card = new ucItemArtigo(artigo);
                card.Width = flowArtigos.Width - 40;
                card.Margin = new Padding(10, 10, 10, 0);

                // Ajusta a largura para preencher a tela
                card.Width = flowArtigos.Width - 30;

                // Escuta o clique do card
                card.LerMaisClick += (s, id) =>
                {
                    ArtigoSelecionado?.Invoke(this, id);
                };

                // Adiciona na tela
                flowArtigos.Controls.Add(card);
            }
        }

        private void flowArtigos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
