using Herold_InterviewAssignment.Controllers;
using HeroldInterviewAssignment.Controllers;
using Moq;
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
    public class TestingEmployeeControllerForGetUserProfileMethod
    {
        private Mock<IHttpWrapper> mock;

        public TestingEmployeeControllerForGetUserProfileMethod()
        {

        }

        [SetUp]
        public void setup()
        {
            mock = new Mock<IHttpWrapper>();
        }

        [Test]
        public async Task TestingForPostiveResultOnGetUserProfileMethod()
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
            // Call GetUserProfile method from employee controller
            var result = await employeeControllerInstance.GetUserProfile();

            // Assert (testing the result)
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task TestingForNegativeOnGetUserProfileMethod()
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
            // Call GetUserProfile method
            var result = await employeecontroller.GetUserProfile();

            // Assert Test result
            Assert.AreEqual(500, result.StatusCode);

        }
    }
}
