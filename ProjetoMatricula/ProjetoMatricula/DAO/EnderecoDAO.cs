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
    public class EnderecoDAO : IDAO
    {
        public EnderecoDAO() { }

        public bool Salvar(EntidadeDominio entidade)
        {
            Endereco endereco = (Endereco)entidade;

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

                AlunoDAO aluno = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_endereco (aluno_id, tpend_id, cidade, estado, ");
                strSQL.Append("logradouro, numero, cep) VALUES (@aluno_id, @tpend_id, @cidade, @estado, @logradouro, @numero, @cep)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", aluno.ConsultarId());
                objComando.Parameters.AddWithValue("@tpend_id", tipoDao.ConsultarId(endereco.GetTpEndereco()));
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().getDescricao());
                objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                objComando.Parameters.AddWithValue("@cep", endereco.GetCep());
                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + endereco.GetLogradouro());
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

        public bool Alterar(EntidadeDominio id, EntidadeDominio entidade)
        {
            Endereco endereco = (Endereco)entidade;
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
                tipoDao.Alterar(id, endereco.GetTpEndereco());                

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_endereco SET ");
                strSQL.Append("cidade = @cidade, estado = @estado, logradouro = @logradouro, numero = @numero, cep = @cep ");
                strSQL.Append("WHERE id = " + id.GetId());

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().getDescricao());
                objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

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


        public bool Excluir(EntidadeDominio entidade)
        {
            Endereco endereco = (Endereco)entidade;
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
                if (!endereco.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_endereco WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", endereco.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + endereco.GetId());
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
            return true;
        }

        public List<DadosDTO> Consultar(EntidadeDominio entidadeDominio)
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

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("SELECT * FROM tb_endereco");
                strSQL.Append("WHERE");
                strSQL.Append("aluno_id = @aluno_id");
                strSQL.Append("tpend_id =  @tpend_id");
                strSQL.Append("cidade   =  @cidade");
                strSQL.Append("estado   =  @estado");
                strSQL.Append("logradouro =  @logradouro");
                strSQL.Append("numero =  @numero");
                strSQL.Append("cep = @cep");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", endereco.GetPessoa().GetId());
                objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().getDescricao());
                objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

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
