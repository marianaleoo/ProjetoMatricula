using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
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

            List<Servico.DadosDTO> alunos = dao.Consultar(entidadeDominio);

            //if(alunos.GetRa() != null && aluno.GetRa().Count() > 0)
            //{
            //    return "RA já cadastrado";
            //}

            return null;
         
        }

    }
}