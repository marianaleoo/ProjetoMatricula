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
        private TipoDocumento tipoDocumento;
        private Pessoa pessoa;

        public Documento() { }

        public Documento(string codigo, DateTime validade, TipoDocumento tipoDocumento)
        {
            this.codigo = codigo;
            this.validade = validade;
            this.tipoDocumento = tipoDocumento;
        }

        public TipoDocumento GetTipoDocumento()
        {
            return tipoDocumento;
        }
        public void SetTipoDocumento(TipoDocumento tipoDocumento)
        {
            this.tipoDocumento = tipoDocumento;
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