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
    public class ValidadorExcluirCurso : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {  
            Curso curso = (Curso)entidadeDominio;
            CursoDAO cursoDAO = new CursoDAO();
            var cursoId = curso.GetId();
            var qtdCurso = cursoDAO.ConsultarAluno(cursoId);

            if (!qtdCurso.Equals(0))
            {
                return "Curso não pode ser excluído por haver aluno(s) matriculado(s)!";
            }
            return null;
        }        
    }
}