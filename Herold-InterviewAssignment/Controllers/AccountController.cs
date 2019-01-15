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
using System.Text;

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
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
        public async Task<ObjectResult> Login([FromBody] User user)
        {
            string mycontent = "";
            var response = await this.httpClientWrapper.Post("http://staging.tangent.tngnt.co/api-token-auth/", user);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent content = response.Content)
                {
                    mycontent = await content.ReadAsStringAsync();
                    var JsonData = JsonConvert.DeserializeObject(mycontent);
                    JObject jsonDataObject = JObject.Parse(JsonData.ToString());

                    if (jsonDataObject["token"].ToString() != null)
                    {
                        var token = jsonDataObject["token"].ToString();

                        CurrentUserToken.CurrentUserTokenSession = token;
                    }
                    return StatusCode(200, mycontent);
                }
            }

            return StatusCode(500, "Error");
        }
    }
}