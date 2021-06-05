using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMatriculaWeb.ViewHelper
{
    public interface IViewHelper
    {
        EntidadeDominio GetEntidade(DadosDTO dados);
        List<DadosDTO> GetDados(List<Curso> entidade);
    }
}
