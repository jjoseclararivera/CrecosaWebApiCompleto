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
  
    public class Pago
    {



        public string CREDITO { get; set; }
        public string ID_GESTOR { get; set; }
        public decimal MONTO_PAGO { get; set; }
        public string TELEFONO_SMS { get; set; }
        public string OBSERVACION { get; set; }
        public string BANDERA { get; set; }
        public int SMS_SEND { get; set; }
    
        public Pago() { }

   
        public Pago(string CREDITO, string ID_GESTOR, decimal MONTO_PAGO , string TELEFONO_SMS, string OBSERVACION, string BANDERA, int SMS_SEND)
        {
            this.CREDITO= CREDITO;
            this.ID_GESTOR =ID_GESTOR;
            this.MONTO_PAGO = MONTO_PAGO;
            this.TELEFONO_SMS =TELEFONO_SMS;
            this.OBSERVACION =OBSERVACION;
            this.BANDERA= BANDERA;
            this.SMS_SEND = SMS_SEND;
        }


        public DataTable GetBuscarCredito(string id_usuario, string id_gestor, string busqueda, string  bandera)
        {
            MysqlDBContext _connect = new MysqlDBContext();
            DataTable dt = new DataTable();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "spCB_CAT_X_USER";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;

                comando.Parameters.Add("iduser", MySqlDbType.VarChar, 50).Value =id_usuario;
                comando.Parameters.Add("id_us", MySqlDbType.VarChar, 50).Value =id_gestor;
                comando.Parameters.Add("cat", MySqlDbType.VarChar,50).Value = busqueda;
                comando.Parameters.Add("bandera", MySqlDbType.VarChar, 50).Value =bandera;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);
                _connect.Close();
            }


            return dt;
        }


        public DataTable RealizaPago(Pago p)
        {
            MysqlDBContext _connect = new MysqlDBContext();
            DataTable dt = new DataTable();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "spCB_REALIZAPAGO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;
                comando.Parameters.Add("cred", MySqlDbType.VarChar, 50).Value = p.CREDITO;
                comando.Parameters.Add("idgestor", MySqlDbType.VarChar, 50).Value = p.ID_GESTOR;
                comando.Parameters.Add("monto_pago", MySqlDbType.Decimal).Value = p.MONTO_PAGO;
                comando.Parameters.Add("telsms", MySqlDbType.VarChar, 8).Value = p.TELEFONO_SMS;
                comando.Parameters.Add("obser", MySqlDbType.VarChar, 100).Value = p.OBSERVACION;
                comando.Parameters.Add("bandera", MySqlDbType.VarChar, 50).Value = p.BANDERA;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
               
                da.Fill(dt);
                _connect.Close();
            }


            return dt;
        }






  












    }
}
