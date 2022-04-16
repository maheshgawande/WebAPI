using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{

    [Route("api/v1/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobsRepo jobsRepo = new();

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Jobs body)
        {
            string JSONString = string.Empty;


            JSONString = JsonConvert.SerializeObject(jobsRepo.Insert(body));

            return Ok(body);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jobs>> Get(int id)
        {
            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(jobsRepo.Get(id));

            return Ok(JSONString);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(jobsRepo.Delete(id));

            return Ok(JSONString);
        }
    }
}
