using ConectionApp.DBContextMySql;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ConectionApp
{
    public class Usuario
    {
        [Required]
        public string ID_USUARIO { get; set; }
        public int ID_OFICINA { get; set; }
        public string NOMBRE { get; set; }
        public int ROLL { get; set; }

        public string CERRADO { get; set; }
        public bool isFind { get; set; }

       public Usuario(){ }
  
        public Usuario(string  ID_USUARIO, int ID_OFICINA, string CLAVE, string USUARIO, string NOMBRE, int ROLL)
        {
            this.ID_USUARIO = ID_USUARIO;
            this.ID_OFICINA = ID_OFICINA;
            this.NOMBRE = NOMBRE;
            this.ROLL = ROLL;
        }

        public static Usuario GetUsuario(string user, string pass)
        {
            MysqlDBContext _connect = new MysqlDBContext();
            Usuario myuser = new Usuario();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "spCB_ENTRY";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;

                comando.Parameters.Add("userid", MySqlDbType.VarChar, 10).Value = user;
                comando.Parameters.Add("pass", MySqlDbType.VarChar, 300).Value = pass;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                DataTable dt = new DataTable();
                da.Fill(dt);

                myuser.ID_USUARIO = Convert.ToString(dt.Rows[0]["ID_USUARIO"]);
                myuser.ID_OFICINA = Convert.ToInt32(dt.Rows[0]["ID_OFICINA"]);
                //myuser.CLAVE = Convert.ToString(dt.Rows[0]["CLAVE"]);
                myuser.CERRADO = Convert.ToString(dt.Rows[0]["CERRADO"]);
                myuser.NOMBRE = Convert.ToString(dt.Rows[0]["NOMBRE"]);
                myuser.ROLL = Convert.ToInt32(dt.Rows[0]["ROLL"]);
                myuser.isFind = true;

            }
            else
                myuser.isFind = false;

            return myuser;
        }


        public DataTable estCerrar(string id_gestor)
        {
            MysqlDBContext _connect = new MysqlDBContext();
            DataTable dt = new DataTable();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "spCB_ESTADOCERR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;

                comando.Parameters.Add("idgestor", MySqlDbType.VarChar, 50).Value = id_gestor;
       
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);
                _connect.Close();
            }


            return dt;
        }
       
        


    }


}
