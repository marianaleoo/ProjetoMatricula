using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatriculaWeb.ViewHelper
{
    public class VhDisciplina : IViewHelper
    {  
        public EntidadeDominio GetEntidade(DadosDTO dados)
        {
            Curso curso = new Curso();
            curso.SetId(dados.IdCurso);
            Disciplina disciplina = new Disciplina(dados.Disciplina, dados.IdDisciplina, curso);

            return disciplina;
        }

        public EntidadeDominio GetId(int id)
        {
            Curso curso = new Curso();            
            Disciplina disciplina = new Disciplina(null, id, curso);

            return disciplina;
        }
    }
}