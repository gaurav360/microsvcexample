using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;

namespace GatewayAPIOrchestration.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        static HttpClient client = new HttpClient();

        // GET api/values
        [HttpGet]
        public Task<IEnumerable<string>> Get()
        {
            var response = CallSomeMicroserviceAsync();
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        async Task<IEnumerable<string>> CallSomeMicroserviceAsync()
        {
            HttpResponseMessage httpResponse = await client.GetAsync("http://localhost:56855/api/values");
            List<string> result = await httpResponse.Content.ReadAsJsonAsync<List<string>>();
            return result;
        }
    }
}
