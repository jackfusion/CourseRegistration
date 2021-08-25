using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseRegistration.Migrations
{
    public partial class FixRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Instructors_I_Id",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_C_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_C_Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "C_Id",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CourseStudent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "I_Id",
                table: "CourseStudent",
                newName: "C_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_I_Id",
                table: "CourseStudent",
                newName: "IX_CourseStudent_C_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_C_Id",
                table: "CourseStudent",
                column: "C_Id",
                principalTable: "Courses",
                principalColumn: "C_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_C_Id",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CourseStudent",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "C_Id",
                table: "CourseStudent",
                newName: "I_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_C_Id",
                table: "CourseStudent",
                newName: "IX_CourseStudent_I_Id");

            migrationBuilder.AddColumn<int>(
                name: "C_Id",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 1,
                column: "C_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 2,
                column: "C_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 3,
                column: "C_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 4,
                column: "C_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 5,
                column: "C_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 6,
                column: "C_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "S_Id",
                keyValue: 7,
                column: "C_Id",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Students_C_Id",
                table: "Students",
                column: "C_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Instructors_I_Id",
                table: "CourseStudent",
                column: "I_Id",
                principalTable: "Instructors",
                principalColumn: "I_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_C_Id",
                table: "Students",
                column: "C_Id",
                principalTable: "Courses",
                principalColumn: "C_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
