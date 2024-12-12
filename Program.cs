using Projeto_Controle_de_Vendas.br.com.project.view;
using System;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas
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
            Application.Run(new FrmClients());
        }
    }
}
