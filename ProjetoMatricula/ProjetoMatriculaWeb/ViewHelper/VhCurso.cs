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

        public List<DadosDTO> GetDados(List<Curso> entidade)
        {
            List<DadosDTO> dados = new List<DadosDTO>();

            DadosDTO dado = new DadosDTO();  

            foreach (var item in entidade)
            {
                dado.Id = item.GetId();
                dado.TipoCurso = item.GetTipoCurso().GetDescricao();

                dados.Add(dado);
            }            

            return dados;
        }
    }
}