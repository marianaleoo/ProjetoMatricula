using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Tipo : EntidadeDominio
    {
        protected string nome;
        protected string descricao;

        public Tipo() { }

        protected Tipo(string descricao, string nome)
        {
            this.descricao = descricao;
            this.nome = nome;
        }

        public string GetDescricao()
        {
            return descricao;
        }
        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
        }
        public string GetNome()
        {
            return nome;
        }
        public void SetNome(string nome)
        {
            this.nome = nome;
        }

    }
}