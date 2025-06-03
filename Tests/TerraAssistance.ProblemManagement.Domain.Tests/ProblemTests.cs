namespace TerraAssistance.ProblemManagement.Domain.Tests;

using System;
using System.Reflection;
using TerraAssistance.ProblemManagement.Domain.Entities;
using TerraAssistance.ProblemManagement.Domain.Enums;
using Xunit;

public class ProblemTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        var title = "Test Problem";
        var description = "Test Description";
        var createdById = 1;
        var estimatedAt = DateTime.UtcNow.AddDays(1);

        var problem = new Problem(title, description, createdById, estimatedAt);

        Assert.Equal(title, problem.Title);
        Assert.Equal(description, problem.Description);
        Assert.Equal(createdById, problem.CreatedById);
        Assert.Equal(ProblemStatus.New, problem.Status);
        Assert.Equal(estimatedAt, problem.EstimatedAt);
        Assert.True((DateTime.UtcNow - problem.CreatedAt).TotalSeconds < 5);
    }

    [Fact]
    public void ProtectedConstructor_SetsAllProperties()
    {
        var now = DateTime.UtcNow;
        var ctor = typeof(Problem).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            [typeof(int), typeof(int), typeof(int), typeof(string), typeof(string), typeof(ProblemStatus), typeof(DateTime), typeof(DateTime?), typeof(DateTime?), typeof(string)],
            null);
        Assert.NotNull(ctor);
        var problem = (Problem)ctor.Invoke(
        [
            10,
            2,
            5,
            "Title",
            "Desc",
            ProblemStatus.InProgress,
            now,
            now.AddDays(2),
            now.AddDays(3),
            "Resolved"
        ]);
        Assert.Equal(10, problem.Id);
        Assert.Equal(2, problem.CreatedById);
        Assert.Equal(5, problem.SpentTimeHours);
        Assert.Equal("Title", problem.Title);
        Assert.Equal("Desc", problem.Description);
        Assert.Equal(ProblemStatus.InProgress, problem.Status);
        Assert.Equal(now, problem.CreatedAt);
        Assert.Equal(now.AddDays(2), problem.EstimatedAt);
        Assert.Equal(now.AddDays(3), problem.ClosedAt);
        Assert.Equal("Resolved", problem.CloseResolution);
    }
}
