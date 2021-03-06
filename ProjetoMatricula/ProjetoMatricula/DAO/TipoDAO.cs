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
    public class TipoDAO : IDAO
    {
        public bool Salvar(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
            string nmClass = null;

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
                nmClass = entidade.GetType().Name.ToLower();                
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);
                strSQL.Append(" (descricao) ");
                strSQL.Append("VALUES (@descricao)");

                objComando.CommandText = strSQL.ToString();                
                objComando.Parameters.AddWithValue("@descricao", tipo.GetId());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tipo.GetDescricao());
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
            log.SalvarLog("tb_" + nmClass, "Salvar", entidade);
            return true;
        }

        public int ConsultarId(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
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
                var nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("SELECT MAX(id) FROM ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);

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
            Tipo tipo = (Tipo)entidade;
            string nmClass = null;

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
                nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("UPDATE ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);
                strSQL.Append(" SET ");
                strSQL.Append("descricao = @descricao ");
                strSQL.Append("WHERE id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();                
                objComando.Parameters.AddWithValue("@descricao", tipo.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tipo.GetDescricao());
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
            log.SalvarLog("tb_" + nmClass, "Alterar", entidade);
            return true;
        }

        public bool Excluir(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
            string nmClass = null;

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
                if (!tipo.GetId().Equals(0))
                {
                    nmClass = entidade.GetType().Name.ToLower();
                    strSQL.Append("DELETE FROM ");
                    strSQL.Append("tb_");
                    strSQL.Append(nmClass);
                    strSQL.Append("WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", tipo.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + tipo.GetId());
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
            log.SalvarLog("tb_" + nmClass, "Excluir", entidade);
            return true;
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
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
                var nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("SELECT * FROM ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);
                if (!entidade.GetId().Equals(0))
                {
                    strSQL.Append(" WHERE ");
                    strSQL.Append("id = " +  tipo.GetId());
                }

                objComando.CommandText = strSQL.ToString();

                SqlDataReader reader = objComando.ExecuteReader();

                while (reader.Read())
                {
                    if (nmClass.Equals("tipocurso"))
                    {
                        TipoCurso tipoCurso = new TipoCurso();
                        tipoCurso.SetId(Convert.ToInt32(reader["id"]));
                        tipoCurso.SetDescricao(reader["descricao"].ToString());
                        lst.Add(tipoCurso);
                    }
                    else if (nmClass.Equals("tipodocumento"))
                    {
                        TipoDocumento tipoDocumento = new TipoDocumento();
                        tipoDocumento.SetId(Convert.ToInt32(reader["id"]));
                        tipoDocumento.SetDescricao(reader["descricao"].ToString());
                        lst.Add(tipoDocumento);
                    }
                    else if (nmClass.Equals("tipoendereco"))
                    {
                        TipoEndereco tipoEndereco = new TipoEndereco();
                        tipoEndereco.SetId(Convert.ToInt32(reader["id"]));
                        tipoEndereco.SetDescricao(reader["descricao"].ToString());
                        lst.Add(tipoEndereco);
                    }
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
    }
}