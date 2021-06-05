using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatriculaWeb.ViewHelper
{
    public class VhAluno : IViewHelper
    {
        public List<DadosDTO> GetDados(List<Curso> entidade)
        {
            throw new NotImplementedException();
        }

        public EntidadeDominio GetEntidade(DadosDTO dados)
        {  

            TipoDocumento tipoDocumento = new TipoDocumento(dados.TipoDocumento, dados.Id);            

            Documento documento = new Documento(dados.Codigo, Convert.ToDateTime(dados.Validade), tipoDocumento, dados.Id);

            List<Documento> documentos = new List<Documento>();
            documentos.Add(documento);

            TipoEndereco tipoEndereco = new TipoEndereco(dados.TipoEndereco, dados.Id);

            Estado estado = new Estado(dados.Estado);

            Cidade cidade = new Cidade(dados.Cidade, estado);

            Endereco endereco = new Endereco(dados.Logradouro, dados.Numero, dados.Cep, cidade, tipoEndereco, dados.Id);

            List<Endereco> enderecos = new List<Endereco>();
            enderecos.Add(endereco);

            TipoCurso tipoCurso = new TipoCurso(dados.TipoCurso, dados.Id);

            Curso curso = new Curso(tipoCurso, dados.Curso, dados.Modelo, dados.Id);

            Disciplina disciplina = new Disciplina(dados.Disciplina, dados.Id);

            List<Disciplina> disciplinas = new List<Disciplina>();
            disciplinas.Add(disciplina);

            Aluno aluno = new Aluno(documentos, enderecos, disciplinas, curso, dados.Aluno, dados.RA, Convert.ToDateTime(dados.DataNascimento), dados.Id);

            return aluno;
        }        
    }
}