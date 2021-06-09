using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using ProjetoMatricula.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorCpf : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {   
            Aluno aluno = (Aluno)entidadeDominio;

            AlunoDAO  alunoDao = new AlunoDAO();

            var tipo = alunoDao.ConsultarTpDocumento(entidadeDominio);
            var codigo = aluno.getDocumentos().FirstOrDefault().GetCodigo();     

            if (aluno.getDocumentos() != null)
            {
                if (tipo.Equals("CPF"))
                {                    
                    if (codigo == null || codigo.Length < 11)
                    {
                        return "CPF deve conter 11 digitos!";
                    }                    
                }   
            }
            else
            {
                return "Documento é obrigatório!";
            }

            return null;
        }

    }
}