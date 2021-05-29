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
        public EntidadeDominio GetEntidade(DadosDTO dados)
        {
            TipoDocumento tipoDocumento = new TipoDocumento(dados.TipoDocumento);            

            Documento documento = new Documento(dados.Codigo, Convert.ToDateTime(dados.Validade), tipoDocumento);

            List<Documento> documentos = new List<Documento>();
            documentos.Add(documento);

            TipoEndereco tipoEndereco = new TipoEndereco(dados.TipoEndereco);

            Estado estado = new Estado(dados.Estado);

            Cidade cidade = new Cidade(dados.Cidade, estado);

            Endereco endereco = new Endereco(dados.Logradouro, dados.Numero, dados.Cep, cidade, tipoEndereco);

            List<Endereco> enderecos = new List<Endereco>();
            enderecos.Add(endereco);

            TipoCurso tipoCurso = new TipoCurso(dados.TipoCurso);

            Curso curso = new Curso(tipoCurso, dados.Curso, dados.Modelo);

            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);

            Disciplina disciplina = new Disciplina(dados.Disciplina);

            List<Disciplina> disciplinas = new List<Disciplina>();
            disciplinas.Add(disciplina);

            Aluno aluno = new Aluno(documentos, enderecos, disciplinas, cursos, dados.Aluno, dados.RA, Convert.ToDateTime(dados.DataNascimento));

            return aluno;
        }
    }
}