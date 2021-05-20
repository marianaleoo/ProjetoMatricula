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
    public class AlunoDAO : IDAO
    {
        public AlunoDAO() { }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            Aluno aluno = (Aluno)entidadeDominio;

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


                strSQL.Append("INSERT INTO tb_aluno(dt_cadastro, ra, nome, dt_nascimento)");
                strSQL.Append("VALUES (@dt_cadastro, @ra, @nome, @dt_nascimento)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", aluno.GetDataCadastro());
                objComando.Parameters.AddWithValue("@ra", aluno.GetRa());
                objComando.Parameters.AddWithValue("@nome", aluno.GetNome());
                objComando.Parameters.AddWithValue("@dt_nascimento", aluno.GetDataNascimento());

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in aluno.GetEnderecos())
                {
                    item.SetPessoa(aluno);
                    enderecoDao.Salvar(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in aluno.getDocumentos())
                {
                    item.SetPessoa(aluno);
                    documentoDao.Salvar(item);
                }

                DisciplinaDAO disciplinaDao = new DisciplinaDAO();
                foreach (var item in aluno.GetDisciplinas())
                {
                    item.SetPessoa(aluno);
                    disciplinaDao.Salvar(item);
                }

                CursoDAO cursoDao = new CursoDAO();
                foreach (var item in aluno.GetCursos())
                {
                    item.SetPessoa(aluno);
                    cursoDao.Salvar(item);
                }

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

        }

        public void Consultar(EntidadeDominio entidadeDominio)
        {
            Aluno aluno = (Aluno)entidadeDominio;

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
                strSQL.Append("tb_aluno");
                strSQL.Append("WHERE");
                strSQL.Append("dt_cadastro = @dt_cadastro");
                strSQL.Append("ra = @ra");
                strSQL.Append("nome = @nome");
                strSQL.Append("dt_nascimento = @dt_nascimento");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", aluno.GetDataCadastro());
                objComando.Parameters.AddWithValue("@ra", aluno.GetRa());
                objComando.Parameters.AddWithValue("@nome", aluno.GetNome());
                objComando.Parameters.AddWithValue("@dt_nascimento", aluno.GetDataNascimento());

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in aluno.GetEnderecos())
                {
                    item.SetPessoa(aluno);
                    enderecoDao.Consultar(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in aluno.getDocumentos())
                {
                    item.SetPessoa(aluno);
                    documentoDao.Consultar(item);
                }

                DisciplinaDAO disciplinaDao = new DisciplinaDAO();
                foreach (var item in aluno.GetDisciplinas())
                {
                    item.SetPessoa(aluno);
                    disciplinaDao.Consultar(item);
                }

                CursoDAO cursoDao = new CursoDAO();
                foreach (var item in aluno.GetCursos())
                {
                    item.SetPessoa(aluno);
                    cursoDao.Consultar(item);
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao consultar registro");
                }
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