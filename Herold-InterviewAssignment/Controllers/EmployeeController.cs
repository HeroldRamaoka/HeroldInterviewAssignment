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
        //private readonly HttpClient client;

        [HttpGet]
        [Route("currentUser")]
        public async Task<IActionResult> GetToken()
        {
            using (HttpClient client = new HttpClient())
            {

                string accessToken = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);
                var response = await client.GetAsync("http://staging.tangent.tngnt.co/api/user/me/");

                if (response.StatusCode.ToString() == "OK")
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        var json = JsonConvert.DeserializeObject(mycontent);

                        return Ok(json);
                    }
                }
            }
            return BadRequest("Did not get data");
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                var accessToken = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);

                var response = await client.GetAsync("http://staging.tangent.tngnt.co/api/employee/");

                if (response.StatusCode.ToString() == "OK")
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();

                        var jsonData = JsonConvert.DeserializeObject(mycontent);

                        return Ok(jsonData);
                    }
                }
            }

            return BadRequest("Did not get any data!");
        }

        [HttpGet]
        [Route("userProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            using (HttpClient client = new HttpClient())
            {
                var accessToken = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);

                var response = await client.GetAsync("http://staging.tangent.tngnt.co/api/employee/me/");

                if (response.StatusCode.ToString() == "OK")
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        var jsonData = JsonConvert.DeserializeObject(mycontent);

                        return Ok(jsonData);
                    }
                }
            }

            return BadRequest("Did not get data!");
        }
    }
}