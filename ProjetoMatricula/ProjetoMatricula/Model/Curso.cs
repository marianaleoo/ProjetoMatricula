using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Curso : EntidadeDominio
    {
        private TipoCurso tpCurso;
        private string nome;
        private string modeloCurso;
        private Aluno aluno;

        public Curso() { }

        public Curso(TipoCurso tpCurso, string nome, string modeloCurso, int id) : base(id)
        {
            this.tpCurso = tpCurso;
            this.nome = nome;
            this.modeloCurso = modeloCurso;
        }

        public TipoCurso GetTipoCurso()
        {
            return tpCurso;
        }

        public void SetTipoCurso(TipoCurso tpCurso)
        {
            this.tpCurso = tpCurso;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetModeloCurso()
        {
            return modeloCurso;
        }

        public void SetModeloCurso(string modeloCurso)
        {
            this.modeloCurso = modeloCurso;
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