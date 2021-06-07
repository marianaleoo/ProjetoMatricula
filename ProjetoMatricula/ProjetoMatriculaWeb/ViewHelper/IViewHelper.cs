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
        EntidadeDominio GetId(int id);
    }
}
