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
        private Pessoa pessoa;

        public Curso() { }

        public Curso(TipoCurso tpCurso, string nome, string modeloCurso)
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