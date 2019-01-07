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

namespace Herold_InterviewAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HeroldAppCors")]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        
        [TempData]
        public string accessTokennnn { get; set; }

        public AccountController()
        {

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
                        var jsonData = JsonConvert.DeserializeObject(mycontent);
                        JObject jsonDataParse = JObject.Parse(jsonData.ToString());
                        var token = jsonDataParse["token"].ToString();

                        HttpContext.Session.SetString("token", token);

                        return Ok(jsonData);
                    }
                }

            return BadRequest("Unable to login, please check your credentials");
        }

        [HttpGet]
        [Route("logout")]
        public void LogOut()
        {
            HttpContext.Session.Remove("token");
        }
    }
}