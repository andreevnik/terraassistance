#nullable disable

namespace TerraAssistance.ProblemManagement.Blazor.Data.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddDomainEntitites : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Problem",
            columns: table => new
            {
                ProblemId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                Title = table.Column<string>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: true),
                Status = table.Column<int>(type: "INTEGER", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                EstimatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                ClosedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                CloseResolution = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Problem", x => x.ProblemId);
                table.ForeignKey(
                    name: "FK_Problem_AspNetUsers_CreatedById",
                    column: x => x.CreatedById,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ProblemComment",
            columns: table => new
            {
                ProblemCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ProblemId = table.Column<int>(type: "INTEGER", nullable: false),
                Text = table.Column<string>(type: "TEXT", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                CreatedById = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProblemComment", x => x.ProblemCommentId);
                table.ForeignKey(
                    name: "FK_ProblemComment_AspNetUsers_CreatedById",
                    column: x => x.CreatedById,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ProblemComment_Problem_ProblemId",
                    column: x => x.ProblemId,
                    principalTable: "Problem",
                    principalColumn: "ProblemId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Problem_CreatedById",
            table: "Problem",
            column: "CreatedById");

        migrationBuilder.CreateIndex(
            name: "IX_ProblemComment_CreatedById",
            table: "ProblemComment",
            column: "CreatedById");

        migrationBuilder.CreateIndex(
            name: "IX_ProblemComment_ProblemId",
            table: "ProblemComment",
            column: "ProblemId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ProblemComment");

        migrationBuilder.DropTable(
            name: "Problem");
    }
}
