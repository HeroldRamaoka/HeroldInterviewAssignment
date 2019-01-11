using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HeroldInterviewAssignment;
using HeroldInterviewAssignment.Controllers;
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
        private readonly IHttpWrapper httpWrapper;

        public EmployeeController(IHttpWrapper httpWrapper)
        {
            this.httpWrapper = httpWrapper;
        }

        [HttpGet]
        [Route("currentUser")]
        public async Task<ObjectResult> GetToken()
        {

            //string accessToken = CurrentUserToken.CurrentUserTokenSession;
            ////var accessToken = "2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678";
            //client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);
            //var response = await httpWrapper.Get("http://staging.tangent.tngnt.co/api/user/me/", accessToken);

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    using (HttpContent content = response.Content)
            //    {
            //        string mycontent = await content.ReadAsStringAsync();
            //        var json = JsonConvert.DeserializeObject(mycontent);

            //        return Ok(json);
            //    }
            //}

            return BadRequest("Did not get data");
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                var accessToken = CurrentUserToken.CurrentUserTokenSession;
                //var accessToken = HttpContext.Session.GetString("token");
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
                var accessToken = CurrentUserToken.CurrentUserTokenSession;
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