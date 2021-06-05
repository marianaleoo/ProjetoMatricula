using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Disciplina : EntidadeDominio
    {        
        private string nome;
        private Aluno aluno;


        public Disciplina() { }

        public Disciplina(string nome, int id) : base(id)
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

        public Aluno GetAluno()
        {
            return aluno;
        }

        public void SetAluno(Aluno aluno)
        {
            this.aluno = aluno;
        }
    }
}