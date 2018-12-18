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
        public async Task<IActionResult> GetEmployees()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //var token = "2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678";
                    client.BaseAddress = new Uri("http://staging.tangent.tngnt.co/api-auth/login/?next=/api/username=pravin.gordhan&username&password=pravin.gordhan");
                    var response = await client.GetAsync($"api/employee/");
                    
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var jsonData = JsonConvert.DeserializeObject<Employee>(stringResult);

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