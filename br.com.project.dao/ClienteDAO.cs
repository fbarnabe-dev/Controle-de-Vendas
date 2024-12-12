﻿using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.project.conection;
using Projeto_Controle_de_Vendas.br.com.project.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.project.dao
{
    public class ClienteDAO
    {

        private MySqlConnection conexao;
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        // Metodo CadastrarCliente

        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,endereco,numero,complemento,bairro,cidade,estado)
                                values (@nome, @rg, @cpf, @email, @telefone, @celular, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso!");
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        // Metodo AlterarCliente

        // Metodo ExcluirCliente

        // Metodo ListarClientes

        // Metodo BuscarClientePorCpf
    }
}
