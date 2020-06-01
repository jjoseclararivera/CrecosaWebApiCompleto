using System;
using System.Net;
using System.Web.Http;
using ConectionApp;

namespace CrecosaWebApi.Controllers
{
    public class ParametrosController: ApiController
    {

        [HttpGet]
    public IHttpActionResult GetParametros()
    {

            Parametros p = new Parametros();
        try
        {
            return Ok(p.GetParametros());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(HttpStatusCode.NotFound);
        }

    }
}
}