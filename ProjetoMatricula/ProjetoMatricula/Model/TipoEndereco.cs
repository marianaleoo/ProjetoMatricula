using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class TipoEndereco : Tipo
    {
        public TipoEndereco()
        {
        }

        public TipoEndereco(string descricao, int id) : base(descricao, id)
        {                        
        }
    }
}