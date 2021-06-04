using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Facade
{
    public interface IFachada
    {
        EntidadeDominio Cadastrar(EntidadeDominio entidade);
        EntidadeDominio Excluir(EntidadeDominio entidade);
        EntidadeDominio Alterar(EntidadeDominio entidade);
        List<EntidadeDominio> Consultar(EntidadeDominio entidade);
    }
}