using System;
using System.Net;
using System.Web.Http;
using ConectionApp;
using CrecosaWebApi.ServiceSMS;

namespace CrecosaWebApi.Controllers
{
    public class PagosController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(string id_usuario, string id_gestor, string busquera, string bandera)
        {

            Pago p = new Pago();
            try
            {
                return Ok(p.GetBuscarCredito(id_usuario,id_gestor,busquera,bandera));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(HttpStatusCode.NotFound);
            }

        }



        public IHttpActionResult PostPago(Pago p)
        {
            try
            {
               
             /*
                if (p.SMS_SEND == 0)
                {
                    EnviarSMS(Convert.ToInt32(p.TELEFONO_SMS), "prueba sms:" + Convert.ToString(p.MONTO_PAGO));
                  
                }
                */
                return Ok(p.RealizaPago(p));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(HttpStatusCode.NotFound);
            }

        }
        /*
        public void EnviarSMS(int t = 0, string m1 = "")
        {
            string resp = "";
            try
            {
                if (t.ToString().Length == 8)
                {
                    string st = "505" + t.ToString();
                    string u = "Credicobros", c = "cr3d1$26987", r = "CRECOSA";
                    wsAPISmsCorpSoapClient client = new wsAPISmsCorpSoapClient("wsAPISmsCorpSoap"); client.Open();
                    var ev = client.enviarSMS(u, c, st, m1, r);
                    resp = ev.esEnvioExitoso == true ? "Se ha enviado el SMS al N°: " + t + " : " + Environment.NewLine + m1 : "No se envio el msj"; client.Close();
                }
                else
                    resp = "Longitud de N° debe de ser de 505 más 8 dígitos.";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
      
            return resp;
        }*/
    }
}