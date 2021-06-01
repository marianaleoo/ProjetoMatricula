using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorEndereco
    {
        public String Processar(EntidadeDominio entidade)
        {
            Endereco endereco = (Endereco)entidade;

            String cidade = endereco.GetCidade().GetDescricao();
            String logradouro = endereco.GetLogradouro();
            String estado = endereco.GetCidade().GetEstado().GetDescricao();
            String numero = endereco.GetNumero();
            String tipoEndereco = endereco.GetTpEndereco().GetDescricao();

            if (logradouro == null || cidade == null || estado == null || numero == null)
            {
                return "Cidade, estado e numero no endereço:" + tipoEndereco + "são de preenchimento obrigat�rio!";
            }
            else if (logradouro.Trim().Equals("") || cidade.Trim().Equals("") || estado.Trim().Equals("") || numero.Trim().Equals(""))
            {
                return "Cidade, estado e numero no endere�o:" + tipoEndereco + "são de preenchimento obrigatório!";
            }
            else
            {
                return "Deve ser registrado um endereco!";
            }

        }
    }
}