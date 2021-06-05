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
    public class ValidadorDisciplina : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            int disciplinas = ConsultarDisciplinas(entidadeDominio);

            if (disciplinas > 5)
            {
                return "Limite de disciplinas por aluno excedido";
            }

            return null;
        }

        public int ConsultarDisciplinas(EntidadeDominio entidadeDominio)
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
                objComando.CommandText = $@"select count(disciplina_id) from tb_aluno_disciplina where aluno_id =" + aluno.GetId();


                lst = Convert.ToInt32(objComando.ExecuteScalar());

                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao consultar Disciplina" + ex.Message);
            }

            return lst;
        }
    }
}
