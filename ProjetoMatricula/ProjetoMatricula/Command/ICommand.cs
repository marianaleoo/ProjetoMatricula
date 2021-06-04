using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMatricula.Command
{
    public interface ICommand
    {
        Object Executar(EntidadeDominio entidade);
    }
}
