using GBGTechnicalTask.Api.Controllers;
using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Models;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace GBGTechnicalTask.Test.Controllers
{
    public class EnrollmentControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly EnrollmentController _enrollmentController;

        public EnrollmentControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _enrollmentController = new EnrollmentController(_mediatorMock.Object);
        }

        [Fact]
        public async Task ItShouldReturnsOkResult_WhenRegisterStudentToCourse()
        {
            // Arrange
            var enrollmentCommand = new AddEnrollmentCommand { CourseId = 1, StudentId = 3 };
            var addEnrollmentResponse = new AddEnrollmentResponse { CourseId = 1, StudentId = 3 };
            var expectedResponse = new Response<AddEnrollmentResponse>()
            {
                Data = addEnrollmentResponse,
                Succeeded = true,
                Message = "Succeeded",
                StatusCode = HttpStatusCode.Created
            };

            _mediatorMock.Setup(m => m.Send(enrollmentCommand, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _enrollmentController.RegisterStudentToCourse(enrollmentCommand);

            // Assert
            Assert.IsType<CreatedResult>(result);
            var createdResult = result as CreatedResult;
            Assert.Equal(expectedResponse, createdResult.Value);
        }
    }
}
