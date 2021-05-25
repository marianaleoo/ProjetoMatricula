using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.DAO
{
    public interface IDAO
    {
        bool Salvar(EntidadeDominio entidade);
        void Alterar(EntidadeDominio entidade);
        void Excluir(EntidadeDominio entidade);
        void Consultar(EntidadeDominio entidade);
        //List<EntidadeDominio> Consultar(EntidadeDominio entidade);
    }
}