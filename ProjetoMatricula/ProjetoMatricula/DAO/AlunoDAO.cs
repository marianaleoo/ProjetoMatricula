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
    public class AlunoDAO : IDAO
    {
        public AlunoDAO() { }

        public bool Salvar(EntidadeDominio entidade)
        {
            Aluno aluno = (Aluno)entidade;

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


                strSQL.Append("INSERT INTO tb_aluno (id_curso, dt_cadastro, ra, nome, dt_nascimento) ");
                strSQL.Append("VALUES (@id_curso, @dt_cadastro, @ra, @nome, @dt_nascimento)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@id_curso", aluno.GetCurso().GetId());
                objComando.Parameters.AddWithValue("@dt_cadastro", aluno.GetDataCadastro());
                objComando.Parameters.AddWithValue("@ra", aluno.GetRa());
                objComando.Parameters.AddWithValue("@nome", aluno.GetNome());
                objComando.Parameters.AddWithValue("@dt_nascimento", aluno.GetDataNascimento());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro");
                }
                objConn.Close();

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in aluno.GetEnderecos())
                {
                    item.SetAluno(aluno);
                    enderecoDao.Salvar(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in aluno.getDocumentos())
                {
                    item.SetAluno(aluno);
                    documentoDao.Salvar(item);
                }                              
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
            log.SalvarLog("tb_aluno", "Salvar", entidade);
            return true;
        }

        public int ConsultarId()
        {
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
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("SELECT MAX(id) FROM ");
                strSQL.Append("tb_aluno");

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

                throw new Exception("Erro ao consultar registro " + ex.Message);
            }
            return id;
        }

        public bool Alterar(EntidadeDominio entidade)
        {
            Aluno aluno = (Aluno)entidade;

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
                AlunoDAO alunoDao = new AlunoDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_aluno SET ");
                strSQL.Append("dt_cadastro = @dt_cadastro, ra = @ra, nome = @nome, dt_nascimento = @dt_nascimento ");
                strSQL.Append("WHERE id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", aluno.GetDataCadastro());
                objComando.Parameters.AddWithValue("@ra", aluno.GetRa());
                objComando.Parameters.AddWithValue("@nome", aluno.GetNome());
                objComando.Parameters.AddWithValue("@dt_nascimento", aluno.GetDataNascimento());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao alterar registro");
                }
                objConn.Close();

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in aluno.GetEnderecos())
                {
                    item.SetAluno(aluno);
                    enderecoDao.Alterar(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in aluno.getDocumentos())
                {
                    item.SetAluno(aluno);
                    documentoDao.Alterar(item);
                }

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
            log.SalvarLog("tb_aluno", "Alterar", entidade);
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
                EnderecoDAO enderecoDAO = new EnderecoDAO();
                enderecoDAO.Excluir(entidade);
                DocumentoDAO documentoDAO = new DocumentoDAO();
                documentoDAO.Excluir(entidade);
                if (!entidade.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_aluno WHERE id = " + entidade.GetId());
                    objComando.CommandText = strSQL.ToString();                    
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
            log.SalvarLog("tb_aluno", "Excluir", entidade);
            return true;
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {

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
                objComando.CommandType = CommandType.Text;
                if (!entidade.GetId().Equals(0))
                {

                    objComando.CommandTimeout = 0;
                    objComando.CommandText = $@"select * from tb_aluno where id = " + entidade.GetId();


                }
                else
                {
                    objComando.CommandTimeout = 0;
                    objComando.CommandText = $@"select * from tb_aluno";


                }

                SqlDataReader reader = objComando.ExecuteReader();
                EnderecoDAO enderecoDao = new EnderecoDAO();
                CursoDAO cursoDao = new CursoDAO();
                DisciplinaDAO disciplinaDao = new DisciplinaDAO();
                DocumentoDAO documentoDao = new DocumentoDAO();


                while (reader.Read())
                {
                    var enderecos = enderecoDao.ConsultarPorIdAluno(Convert.ToInt32(reader["id"]));
                    var curso = cursoDao.ConsultarPorId(Convert.ToInt32(reader["id_curso"]));
                    var disciplinas = disciplinaDao.ConsultarPorIdAluno(Convert.ToInt32(reader["id"]));
                    var documentos = documentoDao.ConsultarPorIdAluno(Convert.ToInt32(reader["id"]));
                    Aluno aluno = new Aluno();
                    aluno.SetNome(reader["nome"].ToString());
                    aluno.SetDataNascimento(Convert.ToDateTime(reader["dt_nascimento"]));
                    aluno.SetRa(reader["ra"].ToString());
                    aluno.SetDataCadastro(Convert.ToDateTime(reader["dt_cadastro"]));
                    aluno.SetId(Convert.ToInt32(reader["id"]));
                    aluno.SetEnderecos(enderecos);
                    aluno.setDocumentos(documentos);
                    aluno.SetCurso(curso);
                    aluno.SetDisciplinas(disciplinas);
                    lst.Add(aluno);

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


        public string ConsultarTpDocumento(EntidadeDominio entidadeDominio)
        {
            Aluno aluno = (Aluno)entidadeDominio;
            var tipoId = aluno.getDocumentos().FirstOrDefault().GetTpDocumento().GetId();
            var lst = String.Empty;

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

                objComando.CommandType = CommandType.Text;
                objComando.CommandTimeout = 0;
                objComando.CommandText = $@"select descricao from tb_tipodocumento where id =" + tipoId;


                lst = objComando.ExecuteScalar().ToString();

                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao consultar Tipo Documento" + ex.Message);
            }

            return lst;
        }

        public int ConsultarRA(EntidadeDominio entidadeDominio)
        {
            Aluno aluno = (Aluno)entidadeDominio;
            int lst = 0;

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

                objComando.CommandType = CommandType.Text;
                objComando.CommandTimeout = 0;
                objComando.CommandText = $@"select count(ra) from tb_aluno where ra =" + aluno.GetRa();


                lst = Convert.ToInt32(objComando.ExecuteScalar());

                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao consultar RA" + ex.Message);
            }

            return lst;
        }
    }
}