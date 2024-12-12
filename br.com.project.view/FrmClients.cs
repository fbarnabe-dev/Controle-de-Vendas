using Projeto_Controle_de_Vendas.br.com.project.dao;
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

            // Recebe os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();
            
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = txtuf.Text;
            
            // Criar um objeto da classe ClienteDAO e chamar o metodo cadastraCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
        }

        private void txtendereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmClients_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.ListarClientes();
            
        }
    }
}
