using Projeto_Controle_de_Vendas.br.com.project.dao;
using Projeto_Controle_de_Vendas.br.com.project.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.project.view
{
    public partial class Frmfuncionarios : Form
    {
        public Frmfuncionarios()
        {
            InitializeComponent();
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            // Botao Salvar Funcionarios
            Funcionario obj = new Funcionario();

            // Receber os dados dos campos
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.nivel_acesso = cbnivel.SelectedItem.ToString();
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = txtuf.SelectedItem.ToString();
            obj.cargo = cbcargo.SelectedItem.ToString();

            // Criar o objeto FuncionarioDAO
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrarFuncionario(obj);
        }

        private void Frmfuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            // Botao Excluir
            Funcionario obj = new Funcionario();

            // Pegar o codigo
            obj.codigo = int.Parse(txtcodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.excluirFuncionario(obj);

            // Recarregar o DataGridView
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            // Recebe os dados dentro do objeto modelo de funcionario
            Funcionario obj = new Funcionario();

            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.cargo = cbcargo.Text;
            obj.nivel_acesso = cbnivel.SelectedItem.ToString();
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

            // Criar um objeto da classe ClienteDAO e chamar o metodo alterarFuncionario
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.alterarFuncionario(obj);

            // Recarregar o DataGridView
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
    }
}
