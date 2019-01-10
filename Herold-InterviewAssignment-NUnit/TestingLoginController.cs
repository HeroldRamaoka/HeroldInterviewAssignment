using Herold_InterviewAssignment.Controllers;
using HeroldInterviewAssignment.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        public async Task TestingLoginMethod()
        {
            //arrange
            mock.Setup(a => a.Post(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(new System.Net.Http.HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("")
            });

            var controller_instance = new AccountController(mock.Object);

            //act
            var result = await controller_instance.Login(It.IsAny<object>());

            //assert            
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
