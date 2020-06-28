using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.BLL
{
    public class Ordens
    {
        public List<MODEL.Ordens> Select()
        {
            DAL.Ordens dalOrd = new DAL.Ordens();
            return dalOrd.Select();
        }

        public List<MODEL.Ordens> SelectById(int id)
        {
            DAL.Ordens dalOrd = new DAL.Ordens();
            return dalOrd.SelectById(id);
        }

        public List<MODEL.Ordens> SelectByEquipamento(string equipamento)
        {
            DAL.Ordens dalOrd = new DAL.Ordens();
            return dalOrd.SelectByEquipamento(equipamento);
        }

        public void Insert(MODEL.Ordens ordem)
        {
            DAL.Ordens dalOrd = new DAL.Ordens();
            dalOrd.Insert(ordem);
        }

        public void Update(MODEL.Ordens ordem)
        {
            DAL.Ordens dalOrd = new DAL.Ordens();
            dalOrd.Update(ordem);
        }

        public void Delete(int id)
        {
            DAL.Ordens dalOrd = new DAL.Ordens();
            dalOrd.Delete(id);
        }
    }
}
