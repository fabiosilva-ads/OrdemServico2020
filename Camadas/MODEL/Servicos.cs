using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.MODEL
{
    public class Servicos
    {
        public int idSer { get; set; }        
        public DateTime saida { get; set; }
        public int ordemID { get; set; }

        public string nomeCli { get; set; }
    }
}
