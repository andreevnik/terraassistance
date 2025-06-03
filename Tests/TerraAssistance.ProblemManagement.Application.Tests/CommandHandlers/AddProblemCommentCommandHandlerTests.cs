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

public class AddProblemCommentCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAddCommentAndSaveChanges()
    {
        // Arrange
        var problemRepositoryMock = new Mock<IProblemRepository>();
        var userIdentityAccessorMock = new Mock<IUserIdentityAccessor>();
        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, "123") };
        var userIdentity = new UserIdentity(new ClaimsIdentity(claims));
        userIdentityAccessorMock.Setup(x => x.GetUserIdentityAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(userIdentity);

        var problem = new Problem("title", "desc", 123, DateTime.UtcNow);
        problemRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(problem);

        var handler = new AddProblemCommentCommandHandler(problemRepositoryMock.Object, userIdentityAccessorMock.Object);
        var command = new AddProblemCommentCommand(1, "Test comment");

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Single(problem.Comments);
        Assert.Equal("Test comment", problem.Comments.First().Text);
        Assert.Equal(123, problem.Comments.First().CreatedById);
        problemRepositoryMock.Verify(x => x.Update(problem), Times.Once);
        problemRepositoryMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}