using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tracker.Wildlife.Api.Repositories;

namespace Tracker.Wildlife.Api.Controllers
{
    [RoutePrefix("api")]
    public class MapDataController : ApiController
    {
        // GET api/mapdata
        [HttpGet]
        [Route("mapdata")]
        public async Task<HttpResponseMessage> Get()
        {
            MapDataRepository mdr = new MapDataRepository();
            return Request.CreateResponse(HttpStatusCode.OK, await mdr.SelectAll());
        }
    }
}
