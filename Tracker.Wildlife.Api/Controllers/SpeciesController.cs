using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tracker.Wildlife.Api.Models;
using Tracker.Wildlife.Api.Repositories;

namespace Tracker.Wildlife.Api.Controllers
{
    [RoutePrefix("api")]
    public class SpeciesController : ApiController
    {
        // GET api/species
        [HttpGet]
        [Route("species")]
        public HttpResponseMessage Get()
        {
           
                AnimalRepository ar = new AnimalRepository();
                return Res ResponseMessage( ar.SelectAll();
               
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message, e.InnerException);
            //}

            //return Ok<List<Animal>>(result);
        }

        // POST api/species
        [HttpPost]
        [Route("species")]
        public HttpResponseMessage Post([FromBody] Species speciesModel)
        {
            if (speciesModel == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID Number is required");
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID Number should have a length of 13");

            try
            {
                bool isValid = speciesModel.idNumber.IsValid(speciesModel.idNumber);
                if (!isValid)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID Number is invalid");

                return Request.CreateResponse(HttpStatusCode.OK, "ID Number is valid");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}
