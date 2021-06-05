using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorCpf : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            bool cpf = false;

            Aluno aluno = (Aluno)entidadeDominio;
            var tipo = aluno.getDocumentos().FirstOrDefault().GetTpDocumento().GetDescricao();
            var codigo = aluno.getDocumentos().FirstOrDefault().GetCodigo();     

            if (aluno.getDocumentos() != null)
            {
                if (tipo.Equals("CPF"))
                {
                    cpf = true;
                    if (codigo == null || codigo.Length < 11)
                    {
                        return "CPF deve conter 11 digitos!";
                    }

                }

                if (!cpf)
                    return "CPF é obrigatório!";
            }
            else
            {
                return "CPF é obrigatório!";
            }

            return null;
        }
    }
}