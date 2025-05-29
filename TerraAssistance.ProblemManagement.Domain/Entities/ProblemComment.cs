namespace TerraAssistance.ProblemManagement.Domain.Entities;

using System;
using TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

public class ProblemComment : Comment
{
    internal ProblemComment(string text, int createdById)
        : this(default, text, DateTime.UtcNow, createdById)
    {
    }

    protected ProblemComment(int id, string text, DateTime createdAt, int createdById)
        : base(id, text, createdAt, createdById)
    {
    }
}