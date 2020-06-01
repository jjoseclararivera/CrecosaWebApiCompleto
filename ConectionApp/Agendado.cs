using ConectionApp.DBContextMySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectionApp
{

    public class Agendado
    {
        public DataTable Get(string id_gestor, string cred, DateTime fec_agen, string telsms, string bandera)
        {
            MysqlDBContext _connect = new MysqlDBContext();
            DataTable dt = new DataTable();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "spCB_AGENDAR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;

                comando.Parameters.Add("idgestor", MySqlDbType.VarChar, 50).Value = id_gestor;
                comando.Parameters.Add("cred", MySqlDbType.VarChar, 50).Value = cred;
                comando.Parameters.Add("fecha_agenda", MySqlDbType.DateTime).Value = fec_agen;
                comando.Parameters.Add("telsms", MySqlDbType.VarChar, 8).Value = telsms;
                comando.Parameters.Add("bandera", MySqlDbType.VarChar, 50).Value = bandera;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);
                _connect.Close();
            }


            return dt;
        }
    }
}
