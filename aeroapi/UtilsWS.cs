using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aeroapi
{
    public class UtilsWS
    {

        public bool validaObjPost(JObject passageiro)
        {
            bool nome = false;
            bool cel = false;
            bool idade = false;

            try
            {
                if (passageiro["Nome"].ToString() != null && !String.IsNullOrEmpty(passageiro["Nome"].ToString()))
                {
                    nome = true;
                }

                if (passageiro["Idade"].ToString() != null && !String.IsNullOrEmpty(passageiro["Idade"].ToString()))
                {
                    idade = true;
                }

                if (passageiro["Celular"].ToString() != null && !String.IsNullOrEmpty(passageiro["Celular"].ToString()))
                {
                    cel = true;
                }

                if (nome && cel && idade)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }


        }

        public bool validaObjPut(JObject passageiro)
        {
            bool nome = false;
            bool cel = false;
            bool idade = false;
            bool id = false;

            try
            {
                if (passageiro["Id"].ToString() != null && !String.IsNullOrEmpty(passageiro["Id"].ToString()))
                {
                    id = true;
                }

                if (passageiro["Nome"].ToString() != null && !String.IsNullOrEmpty(passageiro["Nome"].ToString()))
                {
                    nome = true;
                }

                if (passageiro["Idade"].ToString() != null && !String.IsNullOrEmpty(passageiro["Idade"].ToString()))
                {
                    idade = true;
                }

                if (passageiro["Celular"].ToString() != null && !String.IsNullOrEmpty(passageiro["Celular"].ToString()))
                {
                    cel = true;
                }

                if (nome && cel && idade && id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }


        }

    }
}
