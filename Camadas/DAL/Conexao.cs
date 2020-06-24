using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.DAL
{
    public class Conexao
    {
        public static string getConexao()
        {
            return @"Data Source=SIMONE-PC\SQLEXPRESS2008;Initial Catalog=ORDEMSERVICO;Integrated Security=True";
        }
    }
}
