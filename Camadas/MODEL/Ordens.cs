using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.MODEL
{
    public class Ordens
    {
        public int idOrd { get; set; }
        public DateTime entrada { get; set; }
        public string equipamento { get; set; }
        public string defeito { get; set; }
        public float valor { get; set; }
        public string situacao { get; set; }
        public int clienteID { get; set; }
        public string nomeCli { get; set; }
    }
}
