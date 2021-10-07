using Microsoft.EntityFrameworkCore.Migrations;

namespace Examich.Entity.Migrations
{
    public partial class AddExamUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exams_Name",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_UserId",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_UserId_Name",
                table: "Exams",
                columns: new[] { "UserId", "Name" },
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exams_UserId_Name",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Name",
                table: "Exams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_UserId",
                table: "Exams",
                column: "UserId");
        }
    }
}
