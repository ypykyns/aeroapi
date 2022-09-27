using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace aeroapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AeroAPIController : ControllerBase
    {
        Service service = new Service();

        [HttpGet]
        [Route("GetPassageiro")]
        public string GetPassageiro(int id)
        {
            return service.getPassageiro(id);
        }

        [HttpDelete]
        [Route("ExcluirPassageiro")]
        public string ExcluirPassageiro(int id)
        {
            return service.deletePassageiro(id);
        }

        
        [HttpPost]
        [Route("CriarPassageiro")]
        public string PostPassageiro(Object passageiro)
        {
            return service.postPassageiro(passageiro);
        }

        [HttpPut]
        [Route("AlterarPassageiro")]
        public string PutPassageiro(Object passageiro)
        {
            return service.putPassageiro(passageiro);
        }


        
       
    }
}
