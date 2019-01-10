using HeroldInterviewAssignment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HeroldInterviewAssignment.Controllers
{
    public class HttpWrapper : IHttpWrapper
    {
        private readonly HttpClient httpClient;

        public HttpWrapper()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://staging.tangent.tngnt.co/");
        }

        public Task<HttpResponseMessage> Post(string url, object data)
        {
            return this.httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data)));
        }
    }

    public interface IHttpWrapper
    {
        Task<HttpResponseMessage> Post(string url, object data);
    }
}
