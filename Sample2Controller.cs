using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWithWebApi.Controllers
{
    public class Sample2Controller : ApiController
    {
        //public HttpResponseMessage Get(int id)
        //{
        //    //create a response stream 
        //    var response = Request.CreateResponse();
        //    //add conte t to t he response stream , content can be string/object
        //    response.Content = new StringContent(
        //        content: "The input was " + id.ToString() + " and the reponse is sent");
        //    if (id > 10)
        //        response.StatusCode = HttpStatusCode.OK;
        //    else
        //        response.StatusCode = HttpStatusCode.BadRequest;
        //    response.ReasonPhrase = "The request is processed. ";
        //    return response;
        //}
        [HttpGet]
        //[ActionName("check"]
        [Route("api/sample2")]
        public IHttpActionResult CheckInputReturnString(/*int id*/)
        {
            var id = 10;

            if (id > 10)
            {
                return Ok("The input was " + id.ToString() + " and the response is sent");
            }
            else
            { 
                return BadRequest("Some required data is  missing.");
            }
        }

    }
}
