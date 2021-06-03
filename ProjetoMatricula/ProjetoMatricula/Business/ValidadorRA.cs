using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorRA : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            IDAO dao = new AlunoDAO();

            List<DadosDTO> alunos = dao.Consultar(entidadeDominio);

            if (alunos != null && alunos.Count() > 0)
            {
                return "RA já cadastrado";
            }

            return null;
         
        }        

    }
}