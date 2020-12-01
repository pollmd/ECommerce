using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiciiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursValutar : ControllerBase
    {
        // GET: api/<CursValutar>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CursValutar>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var curs = new Curs()
            {
                EUR = 20,
                USD = 17
            };

            return JsonSerializer.Serialize(curs);
        }

        // POST api/<CursValutar>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CursValutar>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CursValutar>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Curs
    {
        public float EUR { get; set; }
        public float USD { get; set; }
    }
}
