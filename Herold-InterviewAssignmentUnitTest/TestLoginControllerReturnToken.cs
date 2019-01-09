using Herold_InterviewAssignment.Controllers;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Herold_InterviewAssignmentUnitTest
{
    public class TestLoginControllerReturnToken
    {
        AccountController account;
        EmployeeController employee;
        public readonly HttpClient client;

        public TestLoginControllerReturnToken(AccountController account)
        {
            account = this.account;
            //employee = new EmployeeController();
        }

        [Fact]
        public void TestingGet()
        {
            // Act
            var req = account.Testing();

            // Assert
            Assert.IsType<OkResult>(req);
        }

        [Fact]
        public void Add_InvalidCredentials_ReturnsBadRequest()
        {
            var user = new User()
            {
                Username = "pravin.gordhan ",
                Password = "pravin.gordhan"
            };

            //var httpCLientMock = Substitute.For<IHttpClientFactory>();

            //var MessageHandler = new AccountController(new HttpResponseMessage()
            //{
            //    StatusCode = HttpStatusCode.OK,
            //    Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            //});
            
            var res = account.Login(user);

            Assert.IsType<OkObjectResult>(res);
        }


        [Fact]
        public void TestEmployee()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://staging.tangent.tngnt.co/api/user/me/"),
                Method = HttpMethod.Get

            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.IsType<HttpResponseMessage>(response);
            }
        }

    }
}
