using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Facade
{
    public interface IFachada
    {
        String Cadastrar(EntidadeDominio entidade);
        String Excluir(EntidadeDominio entidade);
        String Alterar(EntidadeDominio entidade);
        List<EntidadeDominio> Consultar(EntidadeDominio entidade);
    }
}