using HeroldInterviewAssignment.Model;
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
        private HttpResponseMessage httpResponseMessage;

        public HttpWrapper(HttpClient httpClient)
        {
            httpClient = this.httpClient;
            httpClient.BaseAddress = new Uri("http://staging.tangent.tngnt.co/");
        }

        public Task<HttpResponseMessage> Post(string url)
        {
            return this.httpClient.PostAsync(url, new StringContent("JSONData"));
        }
    }

    public interface IHttpWrapper
    {
        Task<HttpResponseMessage> Post(string url);
    }
}
