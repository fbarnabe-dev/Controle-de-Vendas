using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Controle_de_Vendas.br.com.project.model
{
    public class Funcionario : Cliente
    {
        //atributos e Getter e Setter
        public string senha { get; set; }
        public string cargo { get; set; }
        public string nivel_acesso { get; set; }
    }
}
