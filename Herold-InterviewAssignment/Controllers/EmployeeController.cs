using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {

        }

        [Route("employees")]
        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    ////var token = "2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678";
                    client.BaseAddress = new Uri("http://staging.tangent.tngnt.co/api-token-auth/");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
                    
                        return Ok("success");
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Something went wrong: {httpRequestException.Message }");
                }
            }
        }
    }
}