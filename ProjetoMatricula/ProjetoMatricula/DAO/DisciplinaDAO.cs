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
    public class DisciplinaDAO : IDAO
    {
        public DisciplinaDAO() { }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            Disciplina disciplina = (Disciplina)entidadeDominio;

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

                strSQL.Append("INSERT INTO tb_curso(dt_cadastro, curso_id, descricao)");
                strSQL.Append("VALUES (@dt_cadastro, @curso_id, @aluno_id, @descricao)");


                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("dt_cadastro", disciplina.GetDataCadastro());
                objComando.Parameters.AddWithValue("curso_id", disciplina.GetCursos());
                objComando.Parameters.AddWithValue("descricao", disciplina.GetDescricao());

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
             Disciplina disciplina = (Disciplina)entidadeDominio;

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
                strSQL.Append("curso_id = @curso_id");
                strSQL.Append("descricao = @descricao");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", disciplina.GetDataCadastro());
                objComando.Parameters.AddWithValue("@curso_id", disciplina.GetCursos());
                objComando.Parameters.AddWithValue("@descricao", disciplina.GetDescricao());

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