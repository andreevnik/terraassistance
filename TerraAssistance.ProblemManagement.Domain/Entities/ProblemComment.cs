namespace TerraAssistance.ProblemManagement.Domain.Entities;

using System;
using TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

public class ProblemComment : Comment
{
    public ProblemComment(string content, int createdById)
        : this(default, content, DateTime.UtcNow, createdById)
    {
    }

    protected ProblemComment(int id, string content, DateTime createdAt, int createdById)
        : base(id, content, createdAt, createdById)
    {
    }
}