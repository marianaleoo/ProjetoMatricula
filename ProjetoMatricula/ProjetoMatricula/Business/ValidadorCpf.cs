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

            if (aluno.getDocumentos() != null)
            {
                Documento documento = (Documento)entidadeDominio;

                if (documento.GetTpDocumento().GetDescricao().Equals("CPF"))
                {
                    cpf = true;
                    if (documento.GetCodigo() == null || documento.GetCodigo().Length < 11)
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