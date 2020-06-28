using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.BLL
{
    public class Servicos
    {
        public List<MODEL.Servicos> Select()
        {
            DAL.Servicos dalSer = new DAL.Servicos();
            return dalSer.Select();
        }

        public List<MODEL.Servicos> SelectById(int id)
        {
            DAL.Servicos dalSer = new DAL.Servicos();
            return dalSer.SelectById(id);
        }

        public void Insert(MODEL.Servicos servico)
        {
            BLL.Ordens bllOrdem = new Ordens();
            List<MODEL.Ordens> lstOrdens = bllOrdem.SelectById(servico.ordemID);
            MODEL.Ordens ordem = lstOrdens[0];
            ordem.situacao = 2;
            bllOrdem.Update(ordem);

            DAL.Servicos dalSer = new DAL.Servicos();
            dalSer.Insert(servico);
        }

        public void Update(MODEL.Servicos servico)
        {
            DAL.Servicos dalSer = new DAL.Servicos();
            dalSer.Update(servico);
        }

        public void Delete(int id)
        {
            DAL.Servicos dalSer = new DAL.Servicos();
            dalSer.Delete(id);
        }
    }
}
