using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseRegistration.Migrations
{
    public partial class UpdateInstructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "I_Id",
                keyValue: 1,
                column: "C_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "I_Id",
                keyValue: 2,
                column: "C_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "I_Id",
                keyValue: 3,
                column: "C_Id",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "I_Id",
                keyValue: 1,
                column: "C_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "I_Id",
                keyValue: 2,
                column: "C_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "I_Id",
                keyValue: 3,
                column: "C_Id",
                value: null);
        }
    }
}
