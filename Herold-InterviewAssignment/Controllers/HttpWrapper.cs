﻿using HeroldInterviewAssignment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeroldInterviewAssignment.Controllers
{
    public class HttpWrapper : IHttpWrapper
    {
        private readonly HttpClient httpClient;

        public HttpWrapper()
        {
            httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> Post(string url, User data)
        {
            
            return this.httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }

        public Task<HttpResponseMessage> Get(string url)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Token " + CurrentUserToken.CurrentUserTokenSession);
            return this.httpClient.GetAsync(url);
        }
    }

    public interface IHttpWrapper
    {
        Task<HttpResponseMessage> Post(string url, User data);
        Task<HttpResponseMessage> Get(string url);
    }
}
