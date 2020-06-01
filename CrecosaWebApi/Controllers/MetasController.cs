using System;
using System.Net;
using System.Web.Http;
using ConectionApp;

namespace CrecosaWebApi.Controllers
{
    public class MetasController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMetas(DateTime fecha, string agrup,string val)
        {

            MetasDiarias myMeta = new MetasDiarias();
            try{
                return Ok(myMeta.GetMetas(fecha, agrup, val));
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(HttpStatusCode.NotFound);
            }

        }
    }
}
