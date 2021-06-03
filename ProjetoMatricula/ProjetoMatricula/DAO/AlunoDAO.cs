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


                strSQL.Append("INSERT INTO tb_aluno (dt_cadastro, ra, nome, dt_nascimento) ");
                strSQL.Append("VALUES (@dt_cadastro, @ra, @nome, @dt_nascimento)");

                objComando.CommandText = strSQL.ToString();
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

                CursoDAO cursoDao = new CursoDAO();
                foreach (var item in aluno.GetCursos())
                {
                    item.SetAluno(aluno);
                    cursoDao.Salvar(item);
                }

                DisciplinaDAO disciplinaDao = new DisciplinaDAO();
                foreach (var item in aluno.GetDisciplinas())
                {
                    item.SetAluno(aluno);
                    disciplinaDao.Salvar(item);
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

                throw new Exception("Erro ao inserir registro " + ex.Message);
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
                    throw new Exception("Erro ao inserir registro");
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

                CursoDAO cursoDao = new CursoDAO();
                foreach (var item in aluno.GetCursos())
                {
                    item.SetAluno(aluno);
                    cursoDao.Alterar(item);
                }

                DisciplinaDAO disciplinaDao = new DisciplinaDAO();
                foreach (var item in aluno.GetDisciplinas())
                {
                    item.SetAluno(aluno);
                    disciplinaDao.Alterar(item);
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

        public List<DadosDTO> Consultar(EntidadeDominio entidade)
        {
                   
            List<DadosDTO> lst = new List<DadosDTO>();

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
                if (!entidade.GetId().Equals(0))
                {
                    objComando.CommandType = CommandType.Text;
                    objComando.CommandTimeout = 0;
                    objComando.CommandText = $@"select aluno.id, aluno.nome nomealuno, aluno.ra, aluno.dt_nascimento, curso.nome nomecurso, curso.modeloCurso, disciplina.nome nomedisciplina,
                                                documento.codigo, documento.validade, endereco.cidade, endereco.estado, endereco.logradouro, endereco.numero, endereco.cep, 
		                                        tpcurso.descricao tpcursodescricao, tpdocumento.descricao tpdocumentodescricao, tpendereco.descricao tpenderecodescricao
                                                from tb_aluno as aluno
                                                inner join tb_curso as curso on aluno.id = curso.aluno_id
                                                inner join tb_disciplina as disciplina on aluno.id = disciplina.aluno_id
                                                inner join tb_documento as documento on aluno.id = documento.aluno_id
                                                inner join tb_endereco as endereco on aluno.id = endereco.aluno_id
                                                inner join tb_tipocurso as tpcurso on curso.tipoCurso_id = tpcurso.id
                                                inner join tb_tipodocumento as tpdocumento on documento.tpdoc_id = tpdocumento.id
                                                inner join tb_tipoendereco as tpendereco on endereco.tpend_id = tpendereco.id
                                                where aluno.id =" + entidade.GetId();


                    SqlDataReader reader = objComando.ExecuteReader();

                    while (reader.Read())
                    {
                        lst.Add(new DadosDTO
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Aluno = reader["nomealuno"].ToString(),
                            RA = reader["ra"].ToString(),
                            DataNascimento = Convert.ToDateTime(reader["dt_nascimento"]),
                            Codigo = reader["codigo"].ToString(),
                            Validade = Convert.ToDateTime(reader["validade"]),
                            TipoDocumento = reader["tpdocumentodescricao"].ToString(),
                            Curso = reader["nomecurso"].ToString(),
                            Modelo = reader["modeloCurso"].ToString(),
                            Disciplina = reader["nomedisciplina"].ToString(),
                            TipoCurso = reader["tpcursodescricao"].ToString(),
                            Logradouro = reader["logradouro"].ToString(),
                            Numero = reader["numero"].ToString(),
                            Cep = reader["cep"].ToString(),
                            Cidade = reader["cidade"].ToString(),
                            Estado = reader["estado"].ToString(),
                            TipoEndereco = reader["tpenderecodescricao"].ToString()
                        });
                    }
                }
                else
                {
                    objComando.CommandType = CommandType.Text;
                    objComando.CommandTimeout = 0;
                    objComando.CommandText = @"select aluno.id, aluno.nome, aluno.ra, curso.nome nomecurso, curso.modeloCurso, tpcurso.descricao
                                                from tb_aluno aluno
                                                inner join tb_curso curso on aluno.id = curso.aluno_id
                                                inner join tb_tipocurso tpcurso on curso.tipoCurso_id = tpcurso.id";
                    
                    SqlDataReader reader = objComando.ExecuteReader();

                    while (reader.Read())
                    {
                        lst.Add(new DadosDTO
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Aluno = reader["nome"].ToString(),
                            RA = reader["ra"].ToString(),
                            Curso = reader["nomecurso"].ToString(),
                            Modelo = reader["modeloCurso"].ToString(),
                            TipoCurso = reader["descricao"].ToString()
                        });
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