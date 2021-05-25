using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Disciplina : EntidadeDominio
    {        
        private string nome;
        private Pessoa pessoa;

        public Disciplina() { }

        public Disciplina(string nome)
        {
            this.nome = nome;
        }
        
        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Pessoa GetPessoa()
        {
            return pessoa;
        }

        public void SetPessoa(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }
    }
}