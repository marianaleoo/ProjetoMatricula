using ProjetoMatricula.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class Aluno : EntidadeDominio
    {        
        private string nome;
        private string ra;
        private DateTime dataNascimento;
        private List<Endereco> enderecos;
        private List<Disciplina> disciplinas;
        private List<Curso> cursos;
        public List<Documento> documentos;

        public Aluno() { }

        public Aluno(List<Documento> documentos, List<Endereco> enderecos, List<Disciplina> disciplinas, List<Curso> cursos, string nome, string ra, DateTime dataNascimento, int id) : base(id)
        {
            this.documentos = documentos;
            this.enderecos = enderecos;
            this.disciplinas = disciplinas;
            this.cursos = cursos;
            this.nome = nome;
            this.ra = ra;
            this.dataNascimento = dataNascimento;            
        }

        public List<Endereco> GetEnderecos()
        {
            return enderecos;
        }

        public void SetEnderecos(List<Endereco> enderecos)
        {
            this.enderecos = enderecos;
        }

        public List<Disciplina> GetDisciplinas()
        {
            return disciplinas;
        }

        public void SetDisciplinas(List<Disciplina> disciplinas)
        {
            this.disciplinas = disciplinas;
        }

        public List<Curso> GetCursos()
        {
            return cursos;
        }

        public void SetCurso(List<Curso> cursos)
        {
            this.cursos = cursos;
        }

        public void AddEndereco(Endereco endereco)
        {
            if (enderecos == null)
            {
                enderecos = new List<Endereco>();
            }
            enderecos.Add(endereco);
        }

        public string GetNome()
        {

            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetRa()
        {

            return ra;
        }

        public void SetRa(string ra)
        {
            this.ra = ra;
        }

        public DateTime GetDataNascimento()
        {

            return dataNascimento;
        }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            this.dataNascimento = dataNascimento;
        }

        public List<Documento> getDocumentos()
        {
            return documentos;
        }

        public void setDocumentos(List<Documento> documentos)
        {
            this.documentos = documentos;
        }

        public void addDocumento(Documento documento)
        {
            if (documentos == null)
            {
                documentos = new List<Documento>();
            }
            documentos.Add(documento);
        }
    }
}