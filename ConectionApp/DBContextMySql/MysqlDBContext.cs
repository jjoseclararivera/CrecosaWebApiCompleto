using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace ConectionApp.DBContextMySql
{
   class MysqlDBContext
    {
        string StringConnexionMicrofin= WebConfigurationManager.ConnectionStrings["MicroFinDBContext"].ToString();
        string StringConnexionCore = WebConfigurationManager.ConnectionStrings["CoreDBContext"].ToString();
        string USECORE = WebConfigurationManager.AppSettings.GetValues("CORE")[0];

        public MySqlConnection Connection;
        public  MysqlDBContext()
        {
             if (USECORE.Equals("ON"))
                Connection = new MySqlConnection(StringConnexionCore);
            else
                Connection = new MySqlConnection(StringConnexionMicrofin);
        }

        public bool Open()
        {
            try
            {
              Connection.Open();
              return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;    
            }
        }
        public bool Close()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }

        }


    }
  
}