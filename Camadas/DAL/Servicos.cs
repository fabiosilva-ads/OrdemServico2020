using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.DAL
{
    public class Servicos
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Servicos> Select()
        {
            List<MODEL.Servicos> lstServicos = new List<MODEL.Servicos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Servicos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Servicos servico = new MODEL.Servicos();
                    servico.idSer = Convert.ToInt32(dados["idSer"].ToString());
                    servico.saida = Convert.ToDateTime(dados["saida"].ToString());
                    servico.ordemID = Convert.ToInt32(dados["servicoID"].ToString());

                    //Camadas.DAL.Ordens dalOrd = new Ordens();
                    //Camadas.MODEL.Ordens ordem = dalOrd.SelectById(servico.ordemID);
                    //servico.nomeCli = cliente.nome;

                    lstServicos.Add(servico);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta dos Serviços...");
            }
            finally
            {
                conexao.Close();
            }
            return lstServicos;
        }

        public void Insert(MODEL.Servicos servico)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Servicos VALUES (@saida, @ordemID)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@saida", servico.saida);
            cmd.Parameters.AddWithValue("@ordemID", servico.@ordemID);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão do Serviço...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Servicos servico)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Servicos SET saida=@saida, ordemID=@ordemID WHERE idSer=@idSer";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idSer", servico.idSer);
            cmd.Parameters.AddWithValue("@saida", servico.saida);
            cmd.Parameters.AddWithValue("@ordemID", servico.ordemID);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na alteração da Ordem de Serviço...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
