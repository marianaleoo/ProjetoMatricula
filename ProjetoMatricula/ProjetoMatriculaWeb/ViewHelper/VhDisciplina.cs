﻿using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatriculaWeb.ViewHelper
{
    public class VhDisciplina : IViewHelper
    {
        public List<DadosDTO> GetDados(List<Curso> entidade)
        {
            throw new NotImplementedException();
        }

        public EntidadeDominio GetEntidade(DadosDTO dados)
        {
            Curso curso = new Curso();
            curso.SetId(dados.Id);
            Disciplina disciplina = new Disciplina(dados.Disciplina, dados.Id, curso);

            return disciplina;
        }
    }
}