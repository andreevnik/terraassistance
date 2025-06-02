namespace TerraAssistance.ProblemManagement.Blazor.Data.Repositories;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using TerraAssistance.ProblemManagement.Blazor.Data.Repositories.Abstract;
using TerraAssistance.ProblemManagement.Domain.Entities;
using TerraAssistance.ProblemManagement.Domain.Interfaces;

public class ProblemRepository : Repository<Problem>, IProblemRepository
{
    public ProblemRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    protected override IQueryable<Problem> Query()
    {
        return DbSet.Include(problem => problem.Comments);
    }
}