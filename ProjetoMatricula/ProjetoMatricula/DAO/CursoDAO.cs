using ProjetoMatricula.Log;
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
    public class CursoDAO : IDAO
    {
        public CursoDAO() { }

        public bool Salvar(EntidadeDominio entidadeDominio)
        {
            Curso curso = (Curso)entidadeDominio;

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
                TipoDAO tipoDAO = new TipoDAO();
                tipoDAO.Salvar(curso.GetTipoCurso());

                AlunoDAO aluno = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_curso (aluno_id, tipoCurso_id, nome, modeloCurso) ");
                strSQL.Append("VALUES (@aluno_id, @tipoCurso_id, @nome, @modeloCurso)");


                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", aluno.ConsultarId());
                objComando.Parameters.AddWithValue("@tipoCurso_id", tipoDAO.ConsultarId(curso.GetTipoCurso()));
                objComando.Parameters.AddWithValue("@nome", curso.GetNome());
                objComando.Parameters.AddWithValue("@modeloCurso", curso.GetModeloCurso());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + curso.GetNome());
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
            RegistrarLog log = new RegistrarLog();
            log.SalvarLog("tb_curso", "Salvar", entidadeDominio);
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
                strSQL.Append("tb_curso");

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
            Curso curso = (Curso)entidade;

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
                TipoDAO tipoDao = new TipoDAO();
                tipoDao.Alterar(curso.GetTipoCurso());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_curso SET ");
                strSQL.Append("nome = @nome, modeloCurso = @modeloCurso ");
                strSQL.Append("WHERE id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();                
                objComando.Parameters.AddWithValue("@nome", curso.GetNome());
                objComando.Parameters.AddWithValue("@modeloCurso", curso.GetModeloCurso());

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
            RegistrarLog log = new RegistrarLog();
            log.SalvarLog("tb_curso", "Alterar", entidade);
            return true;
        }

        public bool Excluir(EntidadeDominio entidade)
        {
            Curso curso = (Curso)entidade;

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
                if (!curso.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_curso WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", curso.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + curso.GetId());
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
            RegistrarLog log = new RegistrarLog();
            log.SalvarLog("tb_curso", "Excluir", entidade);
            return true;
        }

        public List<DadosDTO> Consultar(EntidadeDominio entidadeDominio)
        {
            Curso curso = (Curso)entidadeDominio;

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

                strSQL.Append("SELECT * FROM");
                strSQL.Append("tb_curso");
                strSQL.Append("WHERE");
                strSQL.Append("dt_cadastro = @dt_cadastro");
                strSQL.Append("tipoCurso_id = @tipoCurso_id");
                strSQL.Append("descricao = @descricao ");
                strSQL.Append("modeloCurso = @modeloCurso ");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", curso.GetDataCadastro());
                objComando.Parameters.AddWithValue("@tipoCurso_id", curso.GetTipoCurso());
                objComando.Parameters.AddWithValue("@descricao", curso.GetNome());
                objComando.Parameters.AddWithValue("@modeloCurso", curso.GetModeloCurso());

                objConn.Close();

                List<DadosDTO> lst = new List<DadosDTO>();

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
