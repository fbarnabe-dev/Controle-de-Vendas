using MySql.Data.MySqlClient;
using System.Configuration;


namespace Projeto_Controle_de_Vendas.br.com.project.conection
{
    public class ConnectionFactory
    {
        // metodo que conecta o banco de dados

        public MySqlConnection GetConnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;

            return new MySqlConnection(conexao);
        }
    }
}
