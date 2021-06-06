using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Tipo : EntidadeDominio
    {        
        public string descricao;

        public Tipo() { }

        public Tipo(string descricao, int id) : base(id)
        {
            this.descricao = descricao;           
        }

        public string GetDescricao()
        {
            return descricao;
        }
        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
        } 
    }
}