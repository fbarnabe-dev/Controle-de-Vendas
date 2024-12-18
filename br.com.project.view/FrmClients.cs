﻿using Projeto_Controle_de_Vendas.br.com.project.dao;
using Projeto_Controle_de_Vendas.br.com.project.model;
using System;
using System.Data;
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

            // Recarregar o DataGridView
            tabelaCliente.DataSource = dao.ListarClientes();
        }

        private void txtendereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmClients_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.ListarClientes();
            
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pega os dados da linha selecionada na tela consulta 
            txtcodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtcomplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            txtuf.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            // Alterar para a guia Dados Pessoais
            tabClientes.SelectedTab = tabPage1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            // Exibir mensagem de confirmação
            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir este cliente?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Verificar se o usuário clicou em "Sim"
            if (confirmacao == DialogResult.Yes)
            {
                Cliente obj = new Cliente();

                // Pegar o código do cliente
                obj.codigo = int.Parse(txtcodigo.Text);

                ClienteDAO dao = new ClienteDAO();
                dao.excluirCliente(obj);

                // Recarregar o DataGridView
                tabelaCliente.DataSource = dao.ListarClientes();

                // Limpar o formulário após a exclusão
                new Helpers().LimparTela(this);

                // Mensagem de sucesso
                MessageBox.Show("Cliente excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Caso o usuário clique em "Não"
                MessageBox.Show("Exclusão cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
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

            obj.codigo = int.Parse(txtcodigo.Text);

            // Criar um objeto da classe ClienteDAO e chamar o metodo alterarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            // Recarregar o DataGridView
            tabelaCliente.DataSource = dao.ListarClientes();
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            // Botao Pesquisar
            string nome = txtpesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.BuscarClientesPorNome(nome);

            if(tabelaCliente.Rows.Count > 0 )
            {
                // Recarregar o DataGridView
                tabelaCliente.DataSource = dao.ListarClientes();
            }
        }

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.ListarClientesPorNome(nome);

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Botao consultar cep
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/"+cep+"/xml/";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado, por favor digite manualmente.");
            }
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
    }
}
