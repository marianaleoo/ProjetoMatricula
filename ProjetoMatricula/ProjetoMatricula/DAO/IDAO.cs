using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.DAO
{
    public interface IDAO
    {
        bool Salvar(EntidadeDominio entidade);
        bool Alterar(EntidadeDominio entidade);
        bool Excluir(EntidadeDominio entidade);        
        List<EntidadeDominio> Consultar(EntidadeDominio entidade);
    }
}