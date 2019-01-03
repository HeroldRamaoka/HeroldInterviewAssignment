using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HeroldAppCors")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {

        }

        [HttpGet]
        [Route("currentUser")]
        public async Task<IActionResult> GetToken()
        {
            using (HttpClient client = new HttpClient())
            {
                var accessToken = "2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678";
                client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);
                var response = await client.GetAsync("http://staging.tangent.tngnt.co/api/user/me/");

                if (response.StatusCode.ToString() == "OK")
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        var json = JsonConvert.DeserializeObject(mycontent);

                        return Ok(json);
                    }
                }
            }

            return BadRequest("Did not get data");
        }
    }
}