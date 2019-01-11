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
        public async Task<ObjectResult> GetCurrentUser()
        {
            var response = await httpWrapper.Get("http://staging.tangent.tngnt.co/api/user/me/");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent content = response.Content)
                {
                    string mycontent = await content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject(mycontent);

                    return StatusCode(200, mycontent);
                }
            }

            return StatusCode(500, "No user found");
        }

        [HttpGet]
        [Route("employees")]
        public async Task<ObjectResult> GetAllEmployees()
        {
            var response = await httpWrapper.Get("http://staging.tangent.tngnt.co/api/employee/");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent content = response.Content)
                {
                    string myContent = await content.ReadAsStringAsync();

                    return StatusCode(200, myContent);
                }
            }

            return StatusCode(500, "Did not find any user");
        }

        [HttpGet]
        [Route("userProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var response = await httpWrapper.Get("http://staging.tangent.tngnt.co/api/employee/me/");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent content = response.Content)
                {
                    string myContent = await content.ReadAsStringAsync();

                    return StatusCode(200, myContent);
                }
            }

            return BadRequest("Did not get data!");
        }
    }
}