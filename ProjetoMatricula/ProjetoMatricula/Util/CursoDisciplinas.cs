using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Util
{
    public class CursoDisciplinas
    {
        public List<EntidadeDominio> GetCursoDisciplinas(EntidadeDominio entidade)
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

            try
            {
                objComando.CommandType = CommandType.Text;
                objComando.CommandTimeout = 0;
                objComando.CommandText = $@"select nome from tb_disciplina
                                            where curso_id =" + entidade.GetId(); 

                SqlDataReader reader = objComando.ExecuteReader();

                List<EntidadeDominio> lst = new List<EntidadeDominio>();               

                while (reader.Read())
                {
                    Disciplina disciplina = new Disciplina();
                    disciplina.SetNome(reader["nome"].ToString());
                    lst.Add(disciplina);                    
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