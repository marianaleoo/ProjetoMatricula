using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public interface IStrategy
    {
        String Processar(EntidadeDominio entidadeDominio);
    }
}