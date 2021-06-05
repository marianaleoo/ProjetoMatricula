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
            curso.SetId(dados.Id);
            Disciplina disciplina = new Disciplina(dados.Disciplina, dados.Id, curso);

            return disciplina;
        }
    }
}