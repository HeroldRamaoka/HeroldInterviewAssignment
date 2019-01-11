using Herold_InterviewAssignment.Controllers;
using HeroldInterviewAssignment.Controllers;
using HeroldInterviewAssignment.Model;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeroldInterviewAssignmentNUnit
{
    [TestFixture]
    public class TestingLoginController
    {
        private Mock<IHttpWrapper> mock;

        public TestingLoginController()
        {

        }

        [SetUp]
        public void setup()
        {
            mock = new Mock<IHttpWrapper>();
        }

        [Test]
        public async Task TestingPositiveLoginMethod()
        {
            // Creating new instance of User
            User user = new User()
            {
                username = "pravin.gordhan",
                password = "pravin.gordhan"
            };
            //arrange
            mock.Setup(a => a.Post(It.IsAny<string>(), It.IsAny<User>())).ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject("{token: 43928742398742987439287429874}".ToString()), Encoding.UTF8, "appliction/json")
            });

            // Creating new Instance of Account controller
            var accountControllerInstance = new AccountController(mock.Object);

            //act
            // calling Login method from Account controller
            var result = await accountControllerInstance.Login(user);

            //assert
            // Testing the result
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task TestNegativeLoginMethod()
        {
            User user = new User
            {
                username = "pravin.gordhan",
                password = "pravin.gordsd"
            };

            // Arrange
            mock.Setup(a => a.Post(It.IsAny<string>(), It.IsAny<User>())).ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent(JsonConvert.SerializeObject("{token: 2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678}".ToString()), Encoding.UTF8, "application/json")
            });

            var accountControllerInstance = new AccountController(mock.Object);

            // Act
            var result = await accountControllerInstance.Login(user);

            // Assert
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
