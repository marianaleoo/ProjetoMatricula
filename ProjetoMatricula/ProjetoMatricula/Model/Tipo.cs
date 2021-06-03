using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Tipo : EntidadeDominio
    {        
        protected string descricao;

        public Tipo() { }

        protected Tipo(string descricao, int id) : base(id)
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