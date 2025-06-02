#nullable disable

namespace TerraAssistance.ProblemManagement.Blazor.Data.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddProblemSpentTime : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "SpentTimeHours",
            table: "Problem",
            type: "INTEGER",
            nullable: true);

        migrationBuilder.Sql("UPDATE Problem SET SpentTimeHours = 0 WHERE SpentTimeHours IS NULL;");

        migrationBuilder.AlterColumn<int>(
            name: "SpentTimeHours",
            table: "Problem",
            type: "INTEGER",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "INTEGER",
            oldNullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "SpentTimeHours",
            table: "Problem");
    }
}