using System;
using System.Net;
using System.Web.Http;
using ConectionApp;

namespace CrecosaWebApi.Controllers
{
    public class AgendadosController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(string id_gestor, string cred, DateTime fec_agen, string telsms, string bandera, int send_sms = 1)
        {

            Agendado A = new Agendado();
            try
            {
                return Ok(A.Get(id_gestor,cred,fec_agen,telsms,bandera));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(HttpStatusCode.NotFound);
            }

        }

    }
}