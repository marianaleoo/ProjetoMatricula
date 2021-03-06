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
                //TipoDAO tipoDao = new TipoDAO();
                //tipoDao.Salvar(endereco.GetTpEndereco());

                AlunoDAO aluno = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_endereco (aluno_id, tpend_id, cidade, estado, ");
                strSQL.Append("logradouro, numero, cep) VALUES (@aluno_id, @tpend_id, @cidade, @estado, @logradouro, @numero, @cep)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", aluno.ConsultarId());
                objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().GetDescricao());
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
            RegistrarLog log = new RegistrarLog();
            log.SalvarLog("tb_endereco", "Salvar", entidade);
            return true;
        }

        public bool Alterar(EntidadeDominio entidade)
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
                //TipoDAO tipoDao = new TipoDAO();
                //tipoDao.Alterar(endereco.GetTpEndereco());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_endereco SET ");
                strSQL.Append("tpend_id = @tpend_id, cidade = @cidade, estado = @estado, logradouro = @logradouro, numero = @numero, cep = @cep ");
                strSQL.Append("WHERE aluno_id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().GetDescricao());
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
            RegistrarLog log = new RegistrarLog();
            log.SalvarLog("tb_endereco", "Alterar", entidade);
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
                    strSQL.Append("DELETE FROM tb_endereco WHERE aluno_id =@aluno_id");
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
            log.SalvarLog("tb_endereco", "Excluir", entidade);
            return true;
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
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
                objComando.Parameters.AddWithValue("@aluno_id", endereco.GetAluno().GetId());
                objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().GetDescricao());
                objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

                SqlDataReader reader = objComando.ExecuteReader();

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


        public List<Endereco> ConsultarPorIdAluno(int id)
        {
            List<Endereco> enderecos = new List<Endereco>();
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

                strSQL.Append("SELECT * FROM tb_endereco ");
                strSQL.Append("WHERE ");
                strSQL.Append("aluno_id = @aluno_id");
                //strSQL.Append("tpend_id =  @tpend_id");
                //strSQL.Append("cidade   =  @cidade");
                //strSQL.Append("estado   =  @estado");
                //strSQL.Append("logradouro =  @logradouro");
                //strSQL.Append("numero =  @numero");
                //strSQL.Append("cep = @cep");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", id);
                //objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                //objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                //objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().GetDescricao());
                //objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                //objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                //objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

                SqlDataReader reader = objComando.ExecuteReader();

                while (reader.Read())
                {
                    Cidade cidade = new Cidade();
                    cidade.SetDescricao(reader["cidade"].ToString());
                    TipoEndereco tipoEndereco = new TipoEndereco();
                    tipoEndereco.SetId(Convert.ToInt32(reader["tpend_id"]));
                    Endereco end = new Endereco(reader["logradouro"].ToString(), reader["numero"].ToString(), reader["cep"].ToString(), cidade, tipoEndereco, Convert.ToInt32(reader["id"]));
                    enderecos.Add(end);

                }

                objConn.Close();


                return enderecos;

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
