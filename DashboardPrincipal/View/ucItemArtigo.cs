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
    public partial class ucItemArtigo : UserControl
    {
        public event EventHandler<int> LerMaisClick;
        public int IdArtigo { get; private set; }
        public ucItemArtigo(Artigo artigo)
        {
            InitializeComponent();
            this.IdArtigo = artigo.Id;
            lblTitulo.Text = artigo.Titulo;
            lblResumo.Text = artigo.Resumo;
            lblCategoria.Text = artigo.Categoria;
            this.Cursor = Cursors.Hand;
            this.Click += (s, e) => LerMaisClick?.Invoke(this, IdArtigo);
            lblTitulo.Click += (s, e) => LerMaisClick?.Invoke(this, IdArtigo);
            btnLer.Click += (s, e) => LerMaisClick?.Invoke(this, IdArtigo);
        }

        private void ucItemArtigo_Load(object sender, EventArgs e)
        {

        }
    }
}
