using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Estado : EntidadeDominio
    {
        private string descricao;

        public Estado() { }
        public Estado(string descricao)
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