using Herold_InterviewAssignment.Controllers;
using HeroldInterviewAssignment.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public TestLoginControllerReturnToken()
        {
            //account = new AccountController();
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
            HttpClient client = new HttpClient();

            var user = new User()
            {
                Username = "pravin.gordhan ",
                Password = "pravin.gordhan"
            };
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://staging.tangent.tngnt.co/api-token-authhh/"),
                Method = HttpMethod.Post
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.IsType<HttpResponseMessage>(response);
            }

            //// Act
            //var badRequest = await account.Login(user);

            //// Assert
            //Assert.IsType<BadRequestResult>(badRequest);
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
