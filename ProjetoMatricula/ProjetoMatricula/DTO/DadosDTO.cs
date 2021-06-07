using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Servico
{
    public class DadosDTO
    {
        public int Id { get; set; }        
        public string Aluno { get; set; }
        public string RA { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Codigo { get; set; }
        public DateTime Validade { get; set; }
        public string TipoDocumento { get; set; }        
        public string Curso{ get; set; }
        public string Modelo { get; set; }
        public string TipoCurso { get; set; }
        public string Disciplina { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string TipoEndereco { get; set; }
        public int IdTpCurso { get; set; }
        public int IdCurso { get; set; }
        public int IdDisciplina { get; set; }
        public int IdTpEndereco { get; set; }
        public int IdTpDocumento { get; set; }


    }
}