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
    public class DisciplinaDAO : IDAO
    {
        public DisciplinaDAO() { }

        public bool Salvar(EntidadeDominio entidadeDominio)
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
                AlunoDAO aluno = new AlunoDAO();
                CursoDAO curso = new CursoDAO();
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_disciplina (aluno_id, curso_id, nome) ");
                strSQL.Append("VALUES (@aluno_id, @curso_id, @nome)");


                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", aluno.ConsultarId());
                objComando.Parameters.AddWithValue("@curso_id", curso.ConsultarId());
                objComando.Parameters.AddWithValue("@nome", disciplina.GetNome());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + disciplina.GetNome());
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
            log.SalvarLog("tb_disciplina", "Salvar", entidadeDominio);
            return true;
        }

        public bool Alterar(EntidadeDominio entidade)
        {
            Disciplina disciplina = (Disciplina)entidade;

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

                strSQL.Append("UPDATE tb_disciplina SET ");
                strSQL.Append("nome = @nome ");
                strSQL.Append("WHERE id = " + entidade.GetId());

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", disciplina.GetNome());                

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
            log.SalvarLog("tb_disciplina", "Alterar", entidade);
            return true;
        }

        public bool Excluir(EntidadeDominio entidade)
        {
            Disciplina disciplina = (Disciplina)entidade;

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
                if (!disciplina.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_disciplina WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", disciplina.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + disciplina.GetId());
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
            log.SalvarLog("tb_disciplina", "Excluir", entidade);
            return true;
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
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
                //objComando.Parameters.AddWithValue("@curso_id", disciplina.GetCursos());
                objComando.Parameters.AddWithValue("@descricao", disciplina.GetNome());

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

        public List<Disciplina> ConsultarPorIdAluno(int id)
        {
            List<Disciplina> disciplinas = new List<Disciplina>();
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

                strSQL.Append("SELECT d.* FROM tb_disciplina d ");
                strSQL.Append("inner join tb_aluno_disciplina ad ");
                strSQL.Append("on d.id = ad.disciplina_id ");
                strSQL.Append("where ad.aluno_id =  @aluno_id" );

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@aluno_id", id);


                SqlDataReader reader = objComando.ExecuteReader();

                while (reader.Read())
                {
                    Disciplina disciplina = new Disciplina(reader["nome"].ToString(), Convert.ToInt32(reader["id"]));
                    disciplinas.Add(disciplina);

                }

                objConn.Close();


                return disciplinas;

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