using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatriculaWeb.ViewHelper
{
    public class VhCurso : IViewHelper
    {
        public EntidadeDominio GetEntidade(DadosDTO dados)
        {
            TipoCurso tipoCurso = new TipoCurso(dados.TipoCurso, dados.Id);

            Curso curso = new Curso(tipoCurso, dados.Curso, dados.Modelo, dados.Id); 
            
            return curso;
        }
    }
}