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

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_curso (tipoCurso_id, nome, modeloCurso) ");
                strSQL.Append("VALUES (@tipoCurso_id, @nome, @modeloCurso)");


                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@tipoCurso_id", curso.GetTipoCurso().GetId());
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

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_curso SET ");
                strSQL.Append("tipoCurso_id = @tipoCurso_id, nome = @nome, modeloCurso = @modeloCurso ");
                strSQL.Append("WHERE id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@tipoCurso_id", curso.GetTipoCurso().GetId());
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

        public List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            List<EntidadeDominio> lst = new List<EntidadeDominio>();

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
                    objComando.CommandText = $@"select * from tb_curso where id = " + entidade.GetId();
                }
                else
                {
                    objComando.CommandTimeout = 0;
                    objComando.CommandText = $@"select * from tb_curso";
                }

                SqlDataReader reader = objComando.ExecuteReader(); 

                while (reader.Read())
                {
                    TipoCurso tpCurso = new TipoCurso();
                    tpCurso.SetId(Convert.ToInt32(reader["tipoCurso_id"]));                    
                    Curso curso = new Curso();
                    curso.SetId(Convert.ToInt32(reader["id"]));
                    curso.SetTipoCurso(tpCurso);
                    curso.SetNome(reader["nome"].ToString());
                    curso.SetModeloCurso(reader["modeloCurso"].ToString());
                                      
                    lst.Add(curso);
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

        public Curso ConsultarPorId(int id)
        {
            Curso curso = new Curso();

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

                strSQL.Append("SELECT * FROM tb_curso ");
                strSQL.Append("WHERE ");
                strSQL.Append("id = @id");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@id", id);


                SqlDataReader reader = objComando.ExecuteReader();

                TipoDAO tipoDao = new TipoDAO();
                if (reader.Read())
                {
                    TipoCurso tipoCurso = new TipoCurso();
                    tipoCurso.SetId(Convert.ToInt32(reader["tipoCurso_id"]));
                    var tpCurso = tipoDao.Consultar(tipoCurso);
                    curso = new Curso((TipoCurso)tpCurso[0],  reader["nome"].ToString(), reader["modeloCurso"].ToString(), Convert.ToInt32(reader["id"]));


                }

                objConn.Close();


                return curso;

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
