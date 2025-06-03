namespace TerraAssistance.ProblemManagement.Domain.Tests;

using System;
using System.Reflection;
using TerraAssistance.ProblemManagement.Domain.Entities;
using Xunit;

public class ProblemCommentTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        var text = "Test comment";
        var createdById = 1;
        var before = DateTime.UtcNow;
        var ctor = typeof(ProblemComment).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            [typeof(string), typeof(int)],
            null);
        Assert.NotNull(ctor);
        var comment = (ProblemComment)ctor.Invoke([text, createdById]);
        var after = DateTime.UtcNow;
        Assert.Equal(text, comment.Text);
        Assert.Equal(createdById, comment.CreatedById);
        Assert.InRange(comment.CreatedAt, before, after);
    }

    [Fact]
    public void ProtectedConstructor_SetsAllProperties()
    {
        var now = DateTime.UtcNow;
        var ctor = typeof(ProblemComment).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            [typeof(int), typeof(string), typeof(DateTime), typeof(int)],
            null);
        Assert.NotNull(ctor);
        var comment = (ProblemComment)ctor.Invoke([10, "Text", now, 2]);
        Assert.Equal(10, comment.Id);
        Assert.Equal("Text", comment.Text);
        Assert.Equal(now, comment.CreatedAt);
        Assert.Equal(2, comment.CreatedById);
    }
}