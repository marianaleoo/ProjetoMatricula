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
        private string descricao;
        private Pessoa pessoa;

        public Disciplina() { }

        public Disciplina(List<Curso> cursos, List<Aluno> alunos, string descricao)
        {
            this.cursos = cursos;
            this.alunos = alunos;
            this.descricao = descricao;
        }

        public List<Curso> GetCursos()
        {
            return cursos;
        }

        public void SetDescricao(List<Curso> cursos)
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
        public string GetDescricao()
        {
            return descricao;
        }

        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
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