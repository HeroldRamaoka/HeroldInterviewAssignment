using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HeroldAppCors")]
    //[Authorize]
    public class AccountController : ControllerBase
    {

        public AccountController()
        {

        }

        [HttpGet, Route("testing")]
        public IActionResult testing()
        {
            return Ok("Success");
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            string mycontent = "";
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("username", user.Username),
                    new KeyValuePair<string, string>("password", user.Password)
                };

            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsync("http://staging.tangent.tngnt.co/api-token-auth/", q))

                if (response.StatusCode.ToString() == "OK")
                {
                    using (HttpContent content = response.Content)
                    {
                        mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        var jsonData = JsonConvert.DeserializeObject(mycontent);

                        return Ok(jsonData);
                    }
                }

            return BadRequest("Unable to login, please check your credentials");
        }
    }
}