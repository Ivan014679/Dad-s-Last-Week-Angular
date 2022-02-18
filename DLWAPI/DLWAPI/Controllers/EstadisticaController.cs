using DLWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLWAPI.Controllers
{
    [RoutePrefix("Api/Estadisticas")]
    public class EstadisticaController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public List<Estadistica> GetVendors()
        {
            Estadistica estadistica = new Estadistica();
            return estadistica.Obtener();
        }
    }
}
