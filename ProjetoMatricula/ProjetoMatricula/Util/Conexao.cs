using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Util
{
    public class Conexao
    {
        public string Connection()
        {
            string strConnBD = Convert.ToString(ConfigurationSettings.AppSettings["connectionString"].ToString());

            return strConnBD;
        }
    }
}