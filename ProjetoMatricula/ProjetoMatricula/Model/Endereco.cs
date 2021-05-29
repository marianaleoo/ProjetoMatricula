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
        private TipoEndereco tpEndereco;

        public Endereco() { }

        public Endereco(string logradouro, string numero, string cep,
                 Cidade cidade, TipoEndereco tpEndereco)
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.cep = cep;            
            this.cidade = cidade;
            this.tpEndereco = tpEndereco;
        }

        public Pessoa GetPessoa()
        {
            return pessoa;
        }

        public void SetPessoa(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public TipoEndereco GetTpEndereco()
        {
            return tpEndereco;
        }

        public void SetTpEndereco(TipoEndereco tpEndereco)
        {
            this.tpEndereco = tpEndereco;
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