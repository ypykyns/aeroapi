using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace aeroapi

// essa classe tem a configuração para executar as stored procedures com as chamadas ao banco de dados;
{
    public class Conn
    {
        // string com os dados para conectar ao banco de dados;
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aeroapi;Integrated Security=False;Connect Timeout=30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con = new SqlConnection(connectionString);

        public SqlDataReader ExecuteQueryGetOrDelete(string procedure,int id)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(procedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();                
                return dr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExecuteQueryPost(string procedure,JObject passageiro)
        {
            try
            {
                con.Open();
                string nome = passageiro["Nome"].ToString();
                int idade = (int)passageiro["Idade"];
                string celular = passageiro["Celular"].ToString();

                SqlCommand cmd = new SqlCommand("criarPassageiro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Idade", idade);
                cmd.Parameters.AddWithValue("@Celular", celular);

                int modified = (int)cmd.ExecuteScalar();

                return modified;
            }
            catch{
                return 0;
            }
        }

        public SqlDataReader ExecuteQueryPut(string procedure, JObject passageiro)
        {
            try
            {
                con.Open();

                int id = (int)passageiro["Id"];
                string nome = passageiro["Nome"].ToString();
                int idade = (int)passageiro["Idade"];
                string celular = passageiro["Celular"].ToString();

                SqlCommand cmd = new SqlCommand(procedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Idade", idade);
                cmd.Parameters.AddWithValue("@Celular", celular);
                SqlDataReader dr = cmd.ExecuteReader();

                return dr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Close() {
            con.Close();
        }       

    }
}
