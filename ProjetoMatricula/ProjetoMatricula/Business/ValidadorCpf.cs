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
    public class ValidadorCpf : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            bool cpf = false;

            Aluno aluno = (Aluno)entidadeDominio;
            var tipo = ConsultarTpDocumento(entidadeDominio);
            var codigo = aluno.getDocumentos().FirstOrDefault().GetCodigo();     

            if (aluno.getDocumentos() != null)
            {
                if (tipo.Equals("CPF"))
                {
                    cpf = true;
                    if (codigo == null || codigo.Length < 11)
                    {
                        return "CPF deve conter 11 digitos!";
                    }

                }
                if (!cpf)
                    return "CPF é obrigatório!";
            }
            else
            {
                return "CPF é obrigatório!";
            }

            return null;
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
    }
}