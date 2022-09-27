using Newtonsoft.Json.Linq;
using System;


// essa classe tem os métodos para validar se o objeto recebido pelo controller contém 
// todos os dados para fazer a requisição
// considerando que todos os campos sãop obrigatórios, e retornando falso 
// caso alguma tag do objeto venha vazia, ou caso o obejto venha sem alguma tag.

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

            try
            {
                // tenta fazer a conversão para um valor inteiro
                // se o cast falhar cai no catch e retorna false.
                int passageiroId = (int)passageiro["Id"];                                

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

                // se todas as condições forem true, retorna ok na validação;
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

    }

}

