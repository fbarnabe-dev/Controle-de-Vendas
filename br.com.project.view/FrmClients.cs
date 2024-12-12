using Projeto_Controle_de_Vendas.br.com.project.model;
using System;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.project.view
{
    public partial class FrmClients : Form
    {
        public FrmClients()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            obj.nome = txtnome.Text;
            
        }
    }
}
