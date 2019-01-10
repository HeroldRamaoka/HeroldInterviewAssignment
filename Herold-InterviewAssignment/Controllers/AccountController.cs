using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using HeroldInterviewAssignment.Controllers;
using System.Net;
using HeroldInterviewAssignment;

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HeroldAppCors")]
    public class AccountController : ControllerBase
    {
        //private readonly HttpClient client;
        private readonly IHttpWrapper httpClientWrapper;

        public AccountController(IHttpWrapper httpClientWrapper)
        {
            this.httpClientWrapper = httpClientWrapper;
        }

        [HttpGet]
        public IActionResult Testing()
        {
            return Ok();
        }

        [HttpPost]
        [Route("token")]
        public async Task<ObjectResult> Login([FromBody] object user)
        {
            var response = await this.httpClientWrapper.Post("http://staging.tangent.tngnt.co/api-token-auth/", user);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var body = await response.Content.ReadAsStringAsync();

                return StatusCode(200, await response.Content.ReadAsStringAsync());
            }

            return StatusCode(500, "Error");
        }

        [HttpGet]
        [Route("logout")]
        public void LogOut()
        {
            HttpContext.Session.Remove("token");
        }
    }
}