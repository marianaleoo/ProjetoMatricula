using ProjetoMatricula.Model;
using ProjetoMatricula.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Business
{
    public class ValidadorExcluirCurso : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {  
            Curso curso = (Curso)entidadeDominio;
            var cursoId = curso.GetId();
            var qtdCurso = ConsultarAluno(cursoId);

            if (!qtdCurso.Equals(0))
            {
                return "Curso não pode ser excluído por haver aluno(s) matriculado(s)!";
            }
            return null;
        }

        public int ConsultarAluno(int id)
        {
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
                objComando.CommandText = $@"select count(id_curso) from tb_aluno where id_curso =" + id;


                lst = Convert.ToInt32(objComando.ExecuteScalar());

                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao consultar aluno" + ex.Message);
            }

            return lst;
        }
    }
}