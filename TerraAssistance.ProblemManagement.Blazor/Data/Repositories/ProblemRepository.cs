namespace TerraAssistance.ProblemManagement.Blazor.Data.Repositories;

using TerraAssistance.ProblemManagement.Blazor.Data.Repositories.Abstract;
using TerraAssistance.ProblemManagement.Domain.Entities;
using TerraAssistance.ProblemManagement.Domain.Interfaces;

public class ProblemRepository : Repository<Problem>, IProblemRepository
{
    public ProblemRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}