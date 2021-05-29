using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using ProjetoMatricula.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoMatricula.DAO
{
    public class AlunoDAO : IDAO
    {
        public AlunoDAO() { }

        public bool Salvar(EntidadeDominio entidadeDominio)
        {
            Aluno aluno = (Aluno)entidadeDominio;

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
                StringBuilder strSQL = new StringBuilder();


                strSQL.Append("INSERT INTO tb_aluno (dt_cadastro, ra, nome, dt_nascimento) ");
                strSQL.Append("VALUES (@dt_cadastro, @ra, @nome, @dt_nascimento)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", aluno.GetDataCadastro());
                objComando.Parameters.AddWithValue("@ra", aluno.GetRa());
                objComando.Parameters.AddWithValue("@nome", aluno.GetNome());
                objComando.Parameters.AddWithValue("@dt_nascimento", aluno.GetDataNascimento());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro");
                }
                objConn.Close();

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in aluno.GetEnderecos())
                {
                    item.SetPessoa(aluno);
                    enderecoDao.Salvar(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in aluno.getDocumentos())
                {
                    item.SetPessoa(aluno);
                    documentoDao.Salvar(item);
                }

                CursoDAO cursoDao = new CursoDAO();
                foreach (var item in aluno.GetCursos())
                {
                    item.SetPessoa(aluno);
                    cursoDao.Salvar(item);
                }

                DisciplinaDAO disciplinaDao = new DisciplinaDAO();
                foreach (var item in aluno.GetDisciplinas())
                {
                    item.SetPessoa(aluno);
                    disciplinaDao.Salvar(item);
                }                
            }

            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao inserir registro " + ex.Message);
            }
            return true;
        }

        public int ConsultarId()
        {
            int id = 0;
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
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("SELECT MAX(id) FROM ");
                strSQL.Append("tb_aluno");

                objComando.CommandText = strSQL.ToString();

                id = Convert.ToInt32(objComando.ExecuteScalar());

                objConn.Close();
            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao inserir registro " + ex.Message);
            }
            return id;
        }

        public bool Alterar(EntidadeDominio entidade)
        {
            Aluno aluno = (Aluno)entidade;
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
                AlunoDAO alunoDao = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_aluno SET ");
                strSQL.Append("dt_cadastro = @dt_cadastro, ra = @ra, nome = @nome, dt_nascimento = @dt_nascimento ");
                strSQL.Append("WHERE id = @id");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", aluno.GetDataCadastro());
                objComando.Parameters.AddWithValue("@ra", aluno.GetRa());
                objComando.Parameters.AddWithValue("@nome", aluno.GetNome());
                objComando.Parameters.AddWithValue("@dt_nascimento", aluno.GetDataNascimento());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro");
                }
                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao inserir registro " + ex.Message);
            }
            return true;
        }

        public void Excluir(EntidadeDominio entidade)
        {
            Aluno aluno = (Aluno)entidade;
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
            StringBuilder strSQL = new StringBuilder();
            try
            {
                if (!aluno.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_aluno WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", aluno.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + aluno.GetId());
                }
                objConn.Close();
            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao excluir registro " + ex.Message);
            }
        }

        public List<DadosDTO> Consultar(EntidadeDominio entidade)
        {
            //Aluno aluno = (Aluno)entidade;

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
                objComando.CommandTimeout = 0;
                objComando.CommandText = @"select aluno.nome, aluno.ra, curso.nome, disciplina.nome 
                                            from tb_aluno aluno
                                            inner join tb_curso curso on aluno.id = curso.aluno_id
                                            inner join tb_disciplina disc on aluno.id = disc.aluno_id";

                List<DadosDTO> lst = new List<DadosDTO>();
                SqlDataReader reader = objComando.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new DadosDTO
                    {
                       Aluno = reader["nome"].ToString(),
                       RA = reader["ra"].ToString(),
                       Curso = reader["curso"].ToString(),
                       Disciplina = reader["disciplina"].ToString()
                    });
                }
                                
                objConn.Close();

                return lst;
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