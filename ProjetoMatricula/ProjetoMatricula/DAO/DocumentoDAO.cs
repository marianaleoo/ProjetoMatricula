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
                TipoDAO tipoDao = new TipoDAO();
                tipoDao.Salvar(documento.GetTpDocumento());

                AlunoDAO aluno = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_documento (aluno_id, tpdoc_id, codigo, ");
                strSQL.Append("validade) VALUES (@aluno_id, @tpdoc_id, @codigo, @validade)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", aluno.ConsultarId());
                objComando.Parameters.AddWithValue("@tpdoc_id", tipoDao.ConsultarId(documento.GetTpDocumento()));
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
                TipoDAO tipoDao = new TipoDAO();
                tipoDao.Alterar(documento.GetTpDocumento());                

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_documento SET ");
                strSQL.Append("codigo = @codigo, validade = @validade ");
                strSQL.Append("WHERE id = @id");

                objComando.CommandText = strSQL.ToString();
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
            return true;
        }

        public void Excluir(EntidadeDominio entidade)
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
            StringBuilder strSQL = new StringBuilder();
            try
            {
                if (!documento.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_documento WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", documento.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + documento.GetId());
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

        public List<DadosDTO> Consultar(EntidadeDominio entidadeDominio)
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
                objComando.Parameters.AddWithValue("@aluno_id", documento.GetPessoa().GetId());
                objComando.Parameters.AddWithValue("@tpdoc_id", documento.GetTpDocumento().GetId());
                objComando.Parameters.AddWithValue("@codigo", documento.GetCodigo());
                objComando.Parameters.AddWithValue("@validade", documento.GetValidade());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao consultar registro " + documento.GetCodigo());
                }
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
