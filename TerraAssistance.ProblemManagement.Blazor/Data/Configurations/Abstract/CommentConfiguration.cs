namespace TerraAssistance.ProblemManagement.Blazor.Data.Configurations.Abstract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

public abstract class CommentConfiguration<TComment> : IEntityTypeConfiguration<TComment>
    where TComment : Comment
{
    protected static string TableName => typeof(TComment).Name;

    public void Configure(EntityTypeBuilder<TComment> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(comment => comment.Id);

        builder
            .Property(comment => comment.Id)
            .HasColumnName(TableName + nameof(Comment.Id));

        builder
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(comment => comment.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}