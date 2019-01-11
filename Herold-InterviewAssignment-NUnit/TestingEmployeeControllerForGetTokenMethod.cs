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
using System.Threading.Tasks;

namespace HeroldInterviewAssignmentNUnit
{
    [TestFixture]
    public class TestingEmployeeControllerForGetTokenMethod
    {
        private Mock<IHttpWrapper> mock;

        public TestingEmployeeControllerForGetTokenMethod()
        {

        }

        [SetUp]
        public void setup()
        {
            mock = new Mock<IHttpWrapper>();
        }

        [Test]
        public async Task TestingForPostiveResultOnGetCurrentUserMethod()
        {
            // Arrange
            mock.Setup(a => a.Get(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("")
            });

            // Create new Instance of Employee controller
            var employeeControllerInstance = new EmployeeController(mock.Object);

            // Act
            // Call GetCurrentUser method from employee controller
            var result = await employeeControllerInstance.GetCurrentUser();


            // Assert (testing the result)
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task TestingForNegativeOnGetCurrentUserMethod()
        {
            // Arrange
            mock.Setup(a => a.Get(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadGateway,
                Content = new StringContent("")
            });

            // Create new instance of employee controller
            var employeecontroller = new EmployeeController(mock.Object);

            // Act
            // Call GetCurrentUser method
            var result = await employeecontroller.GetAllEmployees();

            // Assert Test result
            Assert.AreEqual(500, result.StatusCode);

        }
    }
}
