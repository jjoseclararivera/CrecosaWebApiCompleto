using ConectionApp.DBContextMySql;
using System;
using System.Data;
using MySql.Data.MySqlClient;



namespace ConectionApp
{
  public  class Parametros
    {
        public DataTable GetParametros()
        {
            MysqlDBContext _connect = new MysqlDBContext();
            DataTable dt = new DataTable();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "spCB_PARAMETROS";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;


                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);
            }


            return dt;
        }
    }
}
