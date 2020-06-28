using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.DAL
{
    public class Ordens
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Ordens> Select()
        {
            List<MODEL.Ordens> lstOrdens = new List<MODEL.Ordens>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Ordens";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Ordens ordem = new MODEL.Ordens();
                    ordem.idOrd = Convert.ToInt32(dados["idOrd"].ToString());
                    ordem.entrada = Convert.ToDateTime(dados["entrada"].ToString());
                    ordem.equipamento = dados["equipamento"].ToString();
                    ordem.defeito = dados["defeito"].ToString();
                    ordem.valor = Convert.ToSingle(dados["valor"].ToString());
                    ordem.situacao = Convert.ToInt32(dados["situacao"].ToString());
                    ordem.clienteID = Convert.ToInt32(dados["clienteID"].ToString());

                    Camadas.DAL.Clientes dalCli = new Clientes();
                    Camadas.MODEL.Clientes cliente = dalCli.SelectById(ordem.clienteID);
                    ordem.nomeCli = cliente.nome;

                    lstOrdens.Add(ordem);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta das Ordens...");
            }
            finally
            {
                conexao.Close();
            }
            return lstOrdens;
        }

        public List<MODEL.Ordens> SelectById(int id)
        {
            List<MODEL.Ordens> lstOrdens = new List<MODEL.Ordens>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Ordens WHERE idOrd=@idOrd";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idOrd", id);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Ordens ordem = new MODEL.Ordens();
                    ordem.idOrd = Convert.ToInt32(dados["idOrd"].ToString());
                    ordem.entrada = Convert.ToDateTime(dados["entrada"].ToString());
                    ordem.equipamento = dados["equipamento"].ToString();
                    ordem.defeito = dados["defeito"].ToString();
                    ordem.valor = Convert.ToSingle(dados["valor"].ToString());
                    ordem.situacao = Convert.ToInt32(dados["situacao"].ToString());
                    ordem.clienteID = Convert.ToInt32(dados["clienteID"].ToString());

                    Camadas.DAL.Clientes dalCli = new Clientes();
                    Camadas.MODEL.Clientes cliente = dalCli.SelectById(ordem.clienteID);
                    ordem.nomeCli = cliente.nome;

                    lstOrdens.Add(ordem);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta da Ordem por ID...");
            }
            finally
            {
                conexao.Close();
            }
            return lstOrdens;
        }

        public List<MODEL.Ordens> SelectByEquipamento(string equipamento)
        {
            List<MODEL.Ordens> lstOrdens = new List<MODEL.Ordens>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Ordens WHERE (equipamento LIKE @equipamento)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@equipamento", "%" + equipamento.Trim() + "%");
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Ordens ordem = new MODEL.Ordens();
                    ordem.idOrd = Convert.ToInt32(dados["idOrd"].ToString());
					ordem.entrada = Convert.ToDateTime(dados["entrada"].ToString());
                    ordem.equipamento = dados["equipamento"].ToString();
                    ordem.defeito = dados["defeito"].ToString();
					ordem.valor = Convert.ToSingle(dados["valor"].ToString());
					ordem.situacao = Convert.ToInt32(dados["situacao"].ToString());
					ordem.clienteID = Convert.ToInt32(dados["clienteID"].ToString());

                    Camadas.DAL.Clientes dalCli = new Clientes();
                    Camadas.MODEL.Clientes cliente = dalCli.SelectById(ordem.clienteID);
                    ordem.nomeCli = cliente.nome;

                    lstOrdens.Add(ordem);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta da Ordem por Equipamento...");
            }
            finally
            {
                conexao.Close();
            }
            return lstOrdens;
        }

        public void Insert(MODEL.Ordens ordem)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Ordens VALUES (@entrada, @equipamento, @defeito, @valor, @situacao, @clienteID)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@entrada", ordem.entrada);
            cmd.Parameters.AddWithValue("@equipamento", ordem.equipamento);
            cmd.Parameters.AddWithValue("@defeito", ordem.defeito);
            cmd.Parameters.AddWithValue("@valor", ordem.valor);
            cmd.Parameters.AddWithValue("@situacao", ordem.situacao);
            cmd.Parameters.AddWithValue("@clienteID", ordem.clienteID);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão da Ordem de Serviço...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Ordens ordem)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Ordens SET entrada=@entrada, equipamento=@equipamento, defeito=@defeito, valor=@valor, situacao=@situacao, clienteID=@clienteID WHERE idOrd=@idOrd";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idOrd", ordem.idOrd);
            cmd.Parameters.AddWithValue("@entrada", ordem.entrada);
            cmd.Parameters.AddWithValue("@equipamento", ordem.equipamento);
            cmd.Parameters.AddWithValue("@defeito", ordem.defeito);
            cmd.Parameters.AddWithValue("@valor", ordem.valor);
            cmd.Parameters.AddWithValue("@situacao", ordem.situacao);
            cmd.Parameters.AddWithValue("@clienteID", ordem.clienteID);
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

        public void Delete(int id)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Ordens WHERE idOrd=@idOrd";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idOrd", id);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na exclusão da Ordem de Serviço...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
