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
    public class DocumentoDAO : IDAO
    {
        public DocumentoDAO() { }

        public void Salvar(EntidadeDominio entidadeDominio)
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

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_documento(aluno_id, tpdoc_id, codigo, ");
                strSQL.Append("validade) VALUES (@aluno_id, @tpdoc_id, @codigo, @validade)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", documento.GetPessoa().GetId());
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
        }

    }
}