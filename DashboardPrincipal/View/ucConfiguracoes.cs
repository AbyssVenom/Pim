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
    public partial class ucConfiguracoes : UserControl
    {
        public event EventHandler GerirCategoriasClick;
        public event EventHandler GerirUtilizadoresClick;
        public ucConfiguracoes()
        {
            InitializeComponent();
        }

        private void ucConfigurações_Load(object sender, EventArgs e)
        {

        }

        private void btGerirCategorias_Click(object sender, EventArgs e)
        {
            GerirCategoriasClick?.Invoke(this, EventArgs.Empty);
        }

        private void btGerirUtilizadores_Click(object sender, EventArgs e)
        {
            GerirUtilizadoresClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
