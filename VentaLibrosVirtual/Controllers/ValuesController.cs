using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VentaLibrosVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="Pillin, Admin")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
       public object Claims()
{
    return User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c =>
    new
    {
        Type = c.Type,
        Value = c.Value
    });
}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
