using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class TipoDocumento : Tipo
    {
        public TipoDocumento()
        {
        }

        public TipoDocumento(string descricao, int id) : base(descricao, id)
        {          
        }
    }
}