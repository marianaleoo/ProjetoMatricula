using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Endereco : EntidadeDominio
    {
        private Pessoa pessoa;
        private string logradouro;
        private string numero;
        private string cep;        
        private Cidade cidade;
        private TipoEndereco tipoEndereco;

        public Endereco() { }

        public Endereco(string logradouro, string numero, string cep,
                string complemento, Cidade cidade, TipoEndereco tipoEndereco)
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.cep = cep;            
            this.cidade = cidade;
            this.tipoEndereco = tipoEndereco;
        }

        public Pessoa GetPessoa()
        {
            return pessoa;
        }

        public void SetPessoa(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public TipoEndereco GetTipoEndereco()
        {
            return tipoEndereco;
        }

        public void SetTipoEndereco(TipoEndereco tipoEndereco)
        {
            this.tipoEndereco = tipoEndereco;
        }

        public string GetLogradouro()
        {
            return logradouro;
        }

        public void SetLogradouro(string logradouro)
        {
            this.logradouro = logradouro;
        }

        public string GetNumero()
        {
            return numero;
        }

        public void SetNumero(string numero)
        {
            this.numero = numero;
        }

        public string GetCep()
        {
            return cep;
        }

        public void SetCep(string cep)
        {
            this.cep = cep;
        }

        public Cidade GetCidade()
        {
            return cidade;
        }

        public void SetCidade(Cidade cidade)
        {
            this.cidade = cidade;
        }
    }
}