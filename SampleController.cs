using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWithWebApi.Controllers
{
    //[RoutePrefix("api/sample")]
    public class SampleController : ApiController
    {
        // api/sample
       // [Route("")]
        public string Get()
        {
            return DateTime.Now.ToString();
        }

       // [Route("{id}")]
        //  api/sample/2
        public string Get(int id)
        {
            return DateTime.Now.AddDays(id).ToString();
        }
      //  [Route("{id}/{name}")]
        //api/sample/canarys
        public string Get(int id, string name)              // same no of args it will throw error
        {
            return "Hi " + name;
        }
       // [HttpPost]
       // [Route("")]
        //public string Post(int id, string name)
        //{
        //    var obj = new { Id = id, Name = name };
        //    JsonSerializer serializer = new JsonSerializer();
        //    StringWriter writer = new StringWriter();
        //    serializer.Serialize(writer, obj);
        //    writer.Flush();
        //    var outputString = writer.ToString();
        //    return outputString;
        //}
    }
}
