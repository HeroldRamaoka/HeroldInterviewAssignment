using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Login([FromForm] User user)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("username", user.Username),
                    new KeyValuePair<string, string>("password", user.Password)
                };

            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync("http://staging.tangent.tngnt.co/api-token-auth/", q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        if (mycontent.Length > 0)
                        {
                            return Ok(mycontent);
                        }
                    }
                }
            }

            return BadRequest("Invalid credentials provided");
        }
    }
}