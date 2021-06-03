using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Documento : EntidadeDominio
    {
        private string codigo;
        private DateTime validade;
        private TipoDocumento tpDocumento;
        private Aluno aluno;

        public Documento() { }

        public Documento(string codigo, DateTime validade, TipoDocumento tpDocumento, int id) : base(id)
        {
            this.codigo = codigo;
            this.validade = validade;
            this.tpDocumento = tpDocumento;
        }

        public TipoDocumento GetTpDocumento()
        {
            return tpDocumento;
        }
        public void SetTpDocumento(TipoDocumento tpDocumento)
        {
            this.tpDocumento = tpDocumento;
        }
        public string GetCodigo()
        {
            return codigo;
        }
        public void SetCodigo(string codigo)
        {
            this.codigo = codigo;
        }
        public DateTime GetValidade()
        {
            return validade;
        }
        public void SetValidade(DateTime validade)
        {
            this.validade = validade;
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