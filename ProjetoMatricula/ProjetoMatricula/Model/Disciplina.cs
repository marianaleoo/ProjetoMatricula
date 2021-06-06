using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Disciplina : EntidadeDominio
    {        
        public string nome;
        private Curso curso;


        public Disciplina() { }

        public Disciplina(string nome, int id, Curso curso) : base(id)
        {
            this.nome = nome;
            this.curso = curso;
        }
        
        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Curso GetCurso()
        {
            return curso;
        }

        public void SetCurso(Curso curso)
        {
            this.curso = curso;
        }
    }
}