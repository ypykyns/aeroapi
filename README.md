Consultar Passageiro
Método GET aeroApi/GetPAssageio
Request - int Id

Retorno: 
{
"Id": int,
"Nome" : string,
"Idade": int,
"Celular": string
}

--------------------------------------------

Criar Passageiro
Método POST  aeroApi/CriarPassageiro
Request - Object
{
"Nome" : string,
"Idade": int,
"Celular": string
}
Retorno: String 
"Passageiro criado com sucesso Id: 1"

---------------------------------------------

AlterarPassageiro
Método PUT AeroApi/AlterarPassageiro
Request - Object
{
"Id": int,
"Nome" : string,
"Idade": int,
"Celular": string
}
Retorno: string
"Passageiro criado com sucesso"

------------------------------------------------

Excluir Passageiro
Método DELETE  AeroApi/ExcluirPassageiro
Request - int Id

Retorno: string
"Passageito Excluído com sucesso"

------------------------------------------------


