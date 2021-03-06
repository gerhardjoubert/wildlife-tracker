﻿using System;
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
    public class LocationsController : ApiController
    {
        // GET api/locations
        [HttpGet]
        [Route("locations")]
        public async Task<HttpResponseMessage> Get()
        {
             LocationRepository lr = new LocationRepository();
            return Request.CreateResponse(HttpStatusCode.OK, await lr.SelectAll());
        }
    }
}
