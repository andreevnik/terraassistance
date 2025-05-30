namespace TerraAssistance.ProblemManagement.Blazor.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TerraAssistance.ProblemManagement.Domain.Entities;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder.ToTable(nameof(Problem));

        builder.HasKey(problem => problem.Id);

        builder
            .Property(problem => problem.Id)
            .HasColumnName(nameof(Problem) + nameof(Problem.Id));

        builder
            .HasMany(problem => problem.Comments)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(problem => problem.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}