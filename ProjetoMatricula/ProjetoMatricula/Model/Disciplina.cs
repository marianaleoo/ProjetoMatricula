using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Disciplina : EntidadeDominio
    {
        private List<Curso> cursos;
        private List<Aluno> alunos;
        private string nome;
        private Pessoa pessoa;

        public Disciplina() { }

        public Disciplina(List<Curso> cursos, List<Aluno> alunos, string nome)
        {
            this.cursos = cursos;
            this.alunos = alunos;
            this.nome = nome;
        }
        
        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.cursos = cursos;
        }

        public List<Aluno> GetAlunos()
        {
            return alunos;
        }

        public void SetAlunos(List<Aluno> alunos)
        {
            this.alunos = alunos;
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