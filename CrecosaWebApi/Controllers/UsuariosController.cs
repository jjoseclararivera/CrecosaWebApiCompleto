using System;
using System.Net;
using System.Web.Configuration;
using System.Web.Http;
using ConectionApp;
using ConectionApp.DBContextMySql;

namespace CrecosaWebApi.Controllers
{

    public class UsuariosController : ApiController
    {
        public string Cifrador(string clave = "")
        {
            string contrasena = "";
            System.Security.Cryptography.SHA512Managed passwd = new System.Security.Cryptography.SHA512Managed();
            if (clave != null)
            {
                byte[] texto = System.Text.Encoding.ASCII.GetBytes(clave);
                byte[] textocifrado = passwd.ComputeHash(texto);
                contrasena = Convert.ToBase64String(textocifrado);
            }

            return contrasena;
        }
         [HttpGet]
        public IHttpActionResult GetUserName(string username, string pass)
        {         
            Usuario myuser = new Usuario();
            string USECORE = WebConfigurationManager.AppSettings.GetValues("CORE")[0];
            if (USECORE.Equals("ON"))
                myuser = Usuario.GetUsuario(username, pass);
            else
                myuser = Usuario.GetUsuario(username, Cifrador(pass));
            if (myuser.isFind)
            {
                return Ok(myuser);
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }


        [HttpGet]
        public IHttpActionResult GetCierr(string iduser)
        {
            Usuario o = new Usuario();
            try
            {
                return Ok(o.estCerrar(iduser));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(HttpStatusCode.NotFound);
            }

        }
    }
}

