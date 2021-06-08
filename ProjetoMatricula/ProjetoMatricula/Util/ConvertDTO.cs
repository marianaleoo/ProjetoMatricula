using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Util
{
    public class ConvertDTO
    {
        public DadosDTO GetDTO(EntidadeDominio entidade)
        {
            #region Conexão BD
            Conexao conn = new Conexao();
            var conexao = conn.Connection();
            var objConn = new SqlConnection(conexao);
            if (objConn.State == ConnectionState.Closed)
            {
                objConn.Open();
            }
            var objComando = new SqlCommand();
            objComando.Connection = objConn;
            #endregion

            try
            {
                objComando.CommandType = CommandType.Text;
                if (!entidade.GetId().Equals(0))
                {

                    objComando.CommandTimeout = 0;
                    objComando.CommandText = $@"select aluno.nome nomealuno, curso.nome nomecurso, disciplina.nome nomedisciplina, * from tb_aluno as aluno
                                                inner join tb_endereco as endereco on aluno.id = endereco.aluno_id
                                                inner join tb_documento as documento on aluno.id = documento.aluno_id
                                                inner join tb_curso as curso on aluno.id_curso = curso.id
                                                inner join tb_disciplina as disciplina on curso.id = disciplina.curso_id
                                                where aluno.id =" + entidade.GetId();


                }
                

                SqlDataReader reader = objComando.ExecuteReader();
                                
                DadosDTO dados = new DadosDTO();                

                while (reader.Read())
                {
                    dados.Id = Convert.ToInt32(reader["aluno_id"]);
                    dados.Aluno = reader["nomealuno"].ToString();
                    dados.RA = reader["ra"].ToString();
                    dados.DataNascimento = Convert.ToDateTime(reader["dt_nascimento"]);
                    dados.Cidade = reader["cidade"].ToString();
                    dados.Estado = reader["estado"].ToString();
                    dados.Logradouro = reader["logradouro"].ToString();
                    dados.Numero = reader["numero"].ToString();
                    dados.Cep = reader["cep"].ToString();
                    dados.Codigo = reader["codigo"].ToString();
                    dados.Validade = Convert.ToDateTime(reader["validade"]);   
                    dados.Curso = reader["nomecurso"].ToString();
                    dados.Disciplina = reader["nomedisciplina"].ToString();
                    dados.IdTpCurso = Convert.ToInt32(reader["tipoCurso_id"]);
                    dados.IdTpDocumento = Convert.ToInt32(reader["tpdoc_id"]);
                    dados.IdTpEndereco = Convert.ToInt32(reader["tpend_id"]);
                }
                objConn.Close();

                return dados;
            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao consultar registro " + ex.Message);
            }
        }
    }
}