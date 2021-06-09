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
    public class ValidadorRA : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            AlunoDAO alunoDAO = new AlunoDAO();
            int alunos = alunoDAO.ConsultarRA(entidadeDominio);

            if (!alunos.Equals(0))
            {
                return "RA já cadastrado";
            }
            
            return null;
         
        }        

    }
}