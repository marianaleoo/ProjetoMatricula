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

namespace ProjetoMatricula.Business
{
    public class ValidadorCurso : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            int cursos = ConsultarAluno(entidadeDominio);

            if (!cursos.Equals(0))
            {
                return "O aluno já esta matriculado em um curso!";
            }

            return null;
        }

        public int ConsultarAluno(EntidadeDominio entidadeDominio)
        {
            Aluno aluno = (Aluno)entidadeDominio;
            int curso = 0;

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
                objComando.CommandText = $@"select Count(id) from tb_curso where aluno_id =" + aluno.GetId();

                curso = Convert.ToInt32(objComando.ExecuteScalar());

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

            return curso;
        }

    }
}