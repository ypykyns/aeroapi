using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Json;

namespace aeroapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AeroAPIController : ControllerBase
    {
        Conn conn = new Conn();
        UtilsWS utils = new UtilsWS();

        [HttpGet]     
        [Route("GetPassageiro")]
        public string GetPassageiro(int id)
        {            
            return conn.getPassageiro(id);
        }


        [HttpPost]
        [Route("CriarPassageiro")]
        public string PostPassageiro(Object json)
        {
            JObject passageiro = JsonConvert.DeserializeObject<JObject>(json.ToString());

            if (utils.validaObjPost(passageiro))
            {
                JObject result = conn.postPassageiro(passageiro);
                return result.ToString();
            }
            else
            {
                return "Não foi possível criar o passageiro - Valores nulos ou não informados.";
            }
        }


        [HttpPut]
        [Route("AlterarPassageiro")]
        public string PutPassageiro(Object json)
        {
            JObject passageiro = JsonConvert.DeserializeObject<JObject>(json.ToString());

            if (utils.validaObjPut(passageiro))
            {
                JObject result = conn.putPassageiro(passageiro);
                return result.ToString();
            }
            else
            {
                return "Não foi possível criar o passageiro - Valores nulos ou não informados.";
            }


        }


        [HttpDelete]
        [Route("ExcluirPassageiro")]
        public string ExcluirPassageiro(int id)
        {
            return conn.deletePassageiro(id);
        }

    }
}
