using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorEndereco : IStrategy
    {
        public String Processar(EntidadeDominio entidade)
        {

            Aluno aluno = (Aluno)entidade;
            //var tipoEndereco = aluno.GetEnderecos().FirstOrDefault().GetTpEndereco().GetDescricao();
            var logradouro = aluno.GetEnderecos().FirstOrDefault().GetLogradouro();
            var numero = aluno.GetEnderecos().FirstOrDefault().GetNumero();
            var cidade = aluno.GetEnderecos().FirstOrDefault().GetCidade().GetDescricao();
            var estado = aluno.GetEnderecos().FirstOrDefault().GetCidade().GetEstado().GetDescricao();


            if (logradouro == null || cidade == null || estado == null || numero == null)
            {
                return "Cidade, estado e numero no endereço são de preenchimento obrigatório!";
            }
            else if (logradouro.Trim().Equals("") || cidade.Trim().Equals("") || estado.Trim().Equals("") || numero.Trim().Equals(""))
            {
                return "Cidade, estado e numero no endereço são de preenchimento obrigatório!";
            }

            return null;

        }
    }
}