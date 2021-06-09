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
    public class DocumentoDAO : IDAO
    {
        public DocumentoDAO() { }

        public bool Salvar(EntidadeDominio entidadeDominio)
        {
            Documento documento = (Documento)entidadeDominio;

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
                //TipoDAO tipoDao = new TipoDAO();
                //tipoDao.Salvar(documento.GetTpDocumento());

                AlunoDAO aluno = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_documento (aluno_id, tpdoc_id, codigo, ");
                strSQL.Append("validade) VALUES (@aluno_id, @tpdoc_id, @codigo, @validade)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", aluno.ConsultarId());
                objComando.Parameters.AddWithValue("@tpdoc_id", documento.GetTpDocumento().GetId());
                objComando.Parameters.AddWithValue("@codigo", documento.GetCodigo());
                objComando.Parameters.AddWithValue("@validade", documento.GetValidade());
                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + documento.GetCodigo());
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
            log.SalvarLog("tb_documento", "Salvar", entidadeDominio);
            return true;
        }

        public bool Alterar(EntidadeDominio entidade)
        {
            Documento documento = (Documento)entidade;

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
                //TipoDAO tipoDao = new TipoDAO();
                //tipoDao.Alterar(documento.GetTpDocumento());                

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_documento SET ");
                strSQL.Append("tpdoc_id = @tpdoc_id, codigo = @codigo, validade = @validade ");
                strSQL.Append("WHERE aluno_id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@tpdoc_id", documento.GetTpDocumento().GetId());
                objComando.Parameters.AddWithValue("@codigo", documento.GetCodigo());
                objComando.Parameters.AddWithValue("@validade", documento.GetValidade());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + documento.GetCodigo());
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
            log.SalvarLog("tb_documento", "Alterar", entidade);
            return true;
        }

        public bool Excluir(EntidadeDominio entidade)
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

            StringBuilder strSQL = new StringBuilder();
            try
            {
                if (!entidade.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_documento WHERE aluno_id =@aluno_id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@aluno_id", entidade.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + entidade.GetId());
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
            log.SalvarLog("tb_documento", "Excluir", entidade);
            return true;
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            Documento documento = (Documento)entidadeDominio;

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
                strSQL.Append("tb_documento");
                strSQL.Append("WHERE");
                strSQL.Append("aluno_id = @aluno_id");
                strSQL.Append("tpdoc_id = @tpdoc_id");
                strSQL.Append("codigo = @codigo");
                strSQL.Append("validade = @validade");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", documento.GetAluno().GetId());
                objComando.Parameters.AddWithValue("@tpdoc_id", documento.GetTpDocumento().GetId());
                objComando.Parameters.AddWithValue("@codigo", documento.GetCodigo());
                objComando.Parameters.AddWithValue("@validade", documento.GetValidade());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao consultar registro " + documento.GetCodigo());
                }
                objConn.Close();

                List<EntidadeDominio> lst = new List<EntidadeDominio>();

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

        public List<Documento> ConsultarPorIdAluno(int id)
        {
            List<Documento> documentos = new List<Documento>();
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

                strSQL.Append("SELECT * FROM tb_documento ");
                strSQL.Append("WHERE ");
                strSQL.Append("aluno_id = @aluno_id");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", id);


                SqlDataReader reader = objComando.ExecuteReader();

                while (reader.Read())
                {
                    TipoDocumento tipoDocumento = new TipoDocumento();
                    tipoDocumento.SetId(Convert.ToInt32(reader["tpdoc_id"]));
                    Documento doc = new Documento(reader["codigo"].ToString(), Convert.ToDateTime(reader["validade"].ToString()), tipoDocumento, Convert.ToInt32(reader["id"]));
                    documentos.Add(doc);

                }

                objConn.Close();


                return documentos;

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
