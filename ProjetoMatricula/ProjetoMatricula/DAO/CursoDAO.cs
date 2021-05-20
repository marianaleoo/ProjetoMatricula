using ProjetoMatricula.Model;
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

        public void Salvar(EntidadeDominio entidadeDominio)
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

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_curso(dt_cadastro, tipoCurso_id, descricao, modeloCurso)");
                strSQL.Append("VALUES (@dt_cadastro, @tipoCurso_id, @descricao, @modeloCurso)");


                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("dt_cadastro", curso.GetDataCadastro());
                objComando.Parameters.AddWithValue("tipoCurso_id", curso.GetTipoCurso());
                objComando.Parameters.AddWithValue("descricao", curso.GetDescricao());
                objComando.Parameters.AddWithValue("dt_cadastro", curso.GetModeloCurso());

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
        }

        public void Consultar(EntidadeDominio entidadeDominio)
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
                objComando.Parameters.AddWithValue("@descricao", curso.GetDescricao());
                objComando.Parameters.AddWithValue("@modeloCurso", curso.GetModeloCurso());

                objConn.Close();

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
