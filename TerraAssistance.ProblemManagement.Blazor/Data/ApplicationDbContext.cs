namespace TerraAssistance.ProblemManagement.Blazor.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TerraAssistance.ProblemManagement.Blazor.Data.Configurations;
using TerraAssistance.ProblemManagement.Domain.Entities;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationIdentityRole, int>(options)
{
    public DbSet<Problem> Problems { get; set; } = null!;

    public DbSet<ProblemComment> ProblemComments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ProblemConfiguration());
        builder.ApplyConfiguration(new ProblemCommentConfiguration());
    }
}