using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;

namespace aeroapi
{
    public class Conn
    {
        UtilsWS utils = new UtilsWS();
        SqlConnection DBConnection;
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aeroapi;Integrated Security=False;Connect Timeout=30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlDataReader ExecuteQuery(string query)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DBConnection;
            reader = cmd.ExecuteReader();
            return reader;
        }


        public string getPassageiro(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                JObject result = new JObject();
                con.Open();

                SqlCommand cmd = new SqlCommand("consultaPassageiro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    result.Add("Id", id);
                    result.Add("Nome", dr["Nome"].ToString());
                    result.Add("Idade", dr["Idade"].ToString());
                    result.Add("Celular", dr["Celular"].ToString());

                    con.Close();
                    return result.ToString();
                }
                else
                {
                    con.Close();
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public JObject postPassageiro(JObject passageiro)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string nome = passageiro["Nome"].ToString();
            int idade = (int)passageiro["Idade"];
            string celular = passageiro["Celular"].ToString();
            JObject result = new JObject();

            try
            {
                SqlCommand cmd = new SqlCommand("criarPassageiro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Idade", idade);
                cmd.Parameters.AddWithValue("@Celular", celular);
                SqlDataReader dr = cmd.ExecuteReader();

                con.Close();

                result.Add("Result", "Passageiro criado.");
                return result;
            }
            catch (Exception ex)
            {
                con.Close();
                result.Add("Result", "Falha ao tentar criar passageiro.");
                return result;
            }

        }

        public JObject putPassageiro(JObject passageiro)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            int id = (int)passageiro["Id"];
            string nome = passageiro["Nome"].ToString();
            int idade = (int)passageiro["Idade"];
            string celular = passageiro["Celular"].ToString();
            JObject result = new JObject();

            try
            {
                SqlCommand cmd = new SqlCommand("atualizarPassageiro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Idade", idade);
                cmd.Parameters.AddWithValue("@Celular", celular);
                SqlDataReader dr = cmd.ExecuteReader();

                result.Add("Result", dr.RecordsAffected == 1 ? "Passageiro atualizado com sucesso!" : "Passageiro não encontrado com esse id.");

                con.Close();

                return result;
            }
            catch (Exception ex)
            {
                con.Close();
                result.Add("Result", "Falha ao criar passageiro - " + ex.Message);
                return result;
            }

        }

        public string deletePassageiro(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string result = "";
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("excluirPassageiro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                result = dr.RecordsAffected == 1 ? "Passageiro excluído com sucesso!" : "Passageiro não encontrado com esse id.";

                con.Close();

                return result;
            }
            catch (Exception ex)
            {
                con.Close();
                return "Falha ao excluir passageiro - " + ex.Message;
            }
        }    
               
    }

} 
