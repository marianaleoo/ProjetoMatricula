using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Curso : EntidadeDominio
    {
        private TipoCurso tpCurso;
        private string descricao;
        private string modeloCurso;
        private Pessoa pessoa;

        public Curso() { }

        public Curso(TipoCurso tpCurso, string descricao, string modeloCurso)
        {
            this.tpCurso = tpCurso;
            this.descricao = descricao;
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

        public string GetDescricao()
        {
            return descricao;
        }

        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
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