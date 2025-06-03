namespace TerraAssistance.ProblemManagement.Application.Tests.CommandHandlers;

using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TerraAssistance.ProblemManagement.Application.CommandHandlers;
using TerraAssistance.ProblemManagement.Application.Commands;
using TerraAssistance.ProblemManagement.Application.Security;
using TerraAssistance.ProblemManagement.Domain.Entities;
using TerraAssistance.ProblemManagement.Domain.Interfaces;
using Xunit;

public class AddProblemCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAddProblemAndSaveChanges()
    {
        // Arrange
        var problemRepositoryMock = new Mock<IProblemRepository>();
        var userIdentityAccessorMock = new Mock<IUserIdentityAccessor>();
        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, "123") };
        var userIdentity = new UserIdentity(new ClaimsIdentity(claims));
        userIdentityAccessorMock.Setup(x => x.GetUserIdentityAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(userIdentity);

        var handler = new AddProblemCommandHandler(problemRepositoryMock.Object, userIdentityAccessorMock.Object);
        var command = new AddProblemCommand("Test Title", "Test Description", DateTime.UtcNow);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        problemRepositoryMock.Verify(x => x.Add(It.Is<Problem>(p => p.Title == command.Title && p.Description == command.Description && p.CreatedById == userIdentity.Id)), Times.Once);
        problemRepositoryMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}