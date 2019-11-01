using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemOfTestKnowledge.Migrations
{
    public partial class ChangeTypeUserIdInUsersAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersAnswers",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersAnswers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
