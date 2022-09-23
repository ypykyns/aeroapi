using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace aeroapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AeroAPIController : ControllerBase
    {
        Conn conn = new Conn();

        [HttpGet]
        [Route("GetPassageiro")]
        public string GetPassageiro(int id)
        {
            return conn.getPassageiro(id);
        }


        [HttpPost]
        [Route("CriarPassageiro")]
        public string PostPassageiro(string nome, int idade, string celular)
        {
            JObject passageiro = new JObject();
            passageiro.Add("Nome", nome);
            passageiro.Add("Idade", idade);
            passageiro.Add("Celular", celular);

            return conn.postPassageiro(passageiro);
        }

        [HttpPut]
        [Route("AlterarPassageiro")]
        public string PutPassageiro(int id, string nome, int idade, string celular)
        {
            JObject passageiro = new JObject();
            passageiro.Add("Id", id);
            passageiro.Add("Nome", nome);
            passageiro.Add("Idade", idade);
            passageiro.Add("Celular", celular);
           
           return conn.putPassageiro(passageiro);       
        }


        [HttpDelete]
        [Route("ExcluirPassageiro")]
        public string ExcluirPassageiro(int id)
        {           
            return conn.deletePassageiro(id);            
        }

    }
}
