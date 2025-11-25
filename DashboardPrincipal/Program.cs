using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pim;
using Pim.View;


namespace DashboardPrincipal
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseService.InitDatabase();
            DatabaseService.RodarScriptDeTeste();
            FormLogin formLogin = new FormLogin();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                // Se o login foi bem-sucedido, abre o formulário principal
                Application.Run(new TelaPrincipal());
            }
            else
            {
                // Se o login falhou ou foi cancelado, encerra a aplicação
                Application.Exit();
            }
        }
    }
}
