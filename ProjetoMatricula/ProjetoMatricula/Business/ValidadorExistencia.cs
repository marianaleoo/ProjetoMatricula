using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using ProjetoMatricula.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorExistencia : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            AlunoDAO alunoDAO = new AlunoDAO();
            int existe = alunoDAO.ConsultarExistenciaAluno(entidadeDominio);

            if (!existe.Equals(0))
            {
                return "O documento inserido já consta na base de dados!";
            }

            return null;
        }  
    }
}