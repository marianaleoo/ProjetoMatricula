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
    public class EnderecoDAO : IDAO
    {
        public EnderecoDAO() { }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            Endereco endereco = (Endereco)entidadeDominio;

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
                tipoDao.Salvar(endereco.GetTpEndereco());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_endereco(aluno_id, tpend_id, cidade, estado");
                strSQL.Append("logradouro, numero, cep) VALUES (aluno_id, @tpend_id, @cidade, @estado, @logradouro, @numero, @cep)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", endereco.GetPessoa().GetId());
                objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().getDescricao());
                objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

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
