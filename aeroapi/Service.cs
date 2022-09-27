using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;


namespace aeroapi
{
    public class Service
    {
        Conn conn = new Conn();
        UtilsWS utils = new UtilsWS();

        public string getPassageiro(int id)
        {
            JObject result = new JObject();
            try
            {
                SqlDataReader dr = conn.ExecuteQueryGetOrDelete("consultaPassageiro", id);

                if (dr.Read())
                {
                    result.Add("Id", id);
                    result.Add("Nome", dr["Nome"].ToString());
                    result.Add("Idade", dr["Idade"].ToString());
                    result.Add("Celular", dr["Celular"].ToString());

                    conn.Close();
                    return result.ToString();
                }
                else
                {
                    conn.Close();
                    result.Add("Message", "Passageiro não encontrado com ID " + id);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                result.Add("Message", "Erro ao consultar passageiro! - " + ex.Message);
                return result.ToString();
            }
        }

        public string postPassageiro(Object receivedInfo)
        {
            JObject result = new JObject();

            try
            {
                // valida se o objeto recebido está no formato correto, e sem valores vazios ou nulos
                if (utils.validaObjPost(JObject.Parse(receivedInfo.ToString())))
                {

                    int modified = conn.ExecuteQueryPost("criarPassageiro", JObject.Parse(receivedInfo.ToString()));

                    if (modified > 0)
                    {
                        conn.Close();
                        result.Add("Result", "Passageiro criado - ID: " + modified);
                        return result.ToString();
                    }
                    else
                    {
                        conn.Close();
                        result.Add("Result", "Falha ao tentar criar passageiro");
                        return result.ToString();
                    }
                }
                else
                {
                    result.Add("Result", "Verifique a sua requisão - Valores nulos ou vazios.");
                    return result.ToString();
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                result.Add("Result", "Falha ao tentar criar passageiro - " + ex.Message);
                return result.ToString();
            }

        }

        public string putPassageiro(Object receivedInfo)
        {
            JObject result = new JObject();
            try
            {
                // valida se o objeto recebido está no formato correto, e sem valores vazios ou nulos
                if (utils.validaObjPut(JObject.Parse(receivedInfo.ToString())))
                {

                    SqlDataReader dr = conn.ExecuteQueryPut("atualizarPassageiro", JObject.Parse(receivedInfo.ToString()));

                    result.Add("Result", dr.RecordsAffected == 1 ? "Passageiro alterado com sucesso!" : "Passageiro não encontrado com esse id.");

                    conn.Close();
                    return result.ToString();

                }
                else
                {
                    result.Add("Result", "Verifique a sua requisão - Valores nulos ou vazios.");
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                result.Add("Result", "Falha ao alterar passageiro - " + ex.Message);
                return result.ToString();
            }
        }

        public string deletePassageiro(int id)
        {
            JObject result = new JObject();
            try
            {
                SqlDataReader dr = conn.ExecuteQueryGetOrDelete("excluirPassageiro", id);

                result.Add("Message", dr.RecordsAffected == 1 ? "Passageiro excluído com sucesso!" : "Passageiro não encontrado com esse id.");
                conn.Close();

                return result.ToString();
            }
            catch (Exception ex)
            {
                conn.Close();
                result.Add("Message", "Falha ao excluir passageiro - " + ex.Message);
                return result.ToString();
            }
        }
    }
}
