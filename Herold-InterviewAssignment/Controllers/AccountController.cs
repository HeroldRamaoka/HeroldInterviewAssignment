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

        [Route("login")]
        [HttpPost]
        async static void PostAsync()
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("username", "pravin.gordhan"),
                    new KeyValuePair<string, string>("password", "pravin.gordhan")
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

                        Console.WriteLine(mycontent);
                    }
                }
            }
        }
    }
}