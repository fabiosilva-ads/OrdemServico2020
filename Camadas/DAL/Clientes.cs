using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServico2020.Camadas.DAL
{
    public class Clientes
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Clientes> Select()
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.idCli = Convert.ToInt32(dados["idCli"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.endereco = dados["endereco"].ToString();
                    cliente.fone = dados["fone"].ToString();
                    lstClientes.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta dos Clientes...");
            }
            finally
            {
                conexao.Close();
            }
            return lstClientes;
        }

        public List<MODEL.Clientes> SelectById(int id)
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes WHERE idCli=@idCli";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCli", id);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.idCli = Convert.ToInt32(dados["idCli"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.endereco = dados["endereco"].ToString();
                    cliente.fone = dados["fone"].ToString();
                    lstClientes.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta do Cliente por ID...");
            }
            finally
            {
                conexao.Close();
            }
            return lstClientes;
        }

        public List<MODEL.Clientes> SelectByNome(string nome)
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes WHERE (nome LIKE @nome";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.idCli = Convert.ToInt32(dados["idCli"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.endereco = dados["endereco"].ToString();
                    cliente.fone = dados["fone"].ToString();
                    lstClientes.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta do Cliente por Nome...");
            }
            finally
            {
                conexao.Close();
            }
            return lstClientes;
        }

        public void Insert(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Clientes VALUES (@nome, @endereco, @fone)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@fone", cliente.fone);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão do Cliente...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Clientes SET nome=@nome, endereco=@endereco, fone=@fone WHERE idCli=@idCli";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCli", cliente.idCli);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@fone", cliente.fone);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na alteração do Cliente...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(int id)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Clientes WHERE idCli=@idCli";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCli", id);           
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na exclusão do Cliente...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }     
}
