using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseRegistration.Migrations
{
    public partial class FirstInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.C_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    S_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.S_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    I_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    C_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.I_Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_C_Id",
                        column: x => x.C_Id,
                        principalTable: "Courses",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CS_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    S_Id = table.Column<int>(type: "int", nullable: false),
                    C_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => x.CS_Id);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_C_Id",
                        column: x => x.C_Id,
                        principalTable: "Courses",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_S_Id",
                        column: x => x.S_Id,
                        principalTable: "Students",
                        principalColumn: "S_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "C_Id", "Description", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Math", "Math", 1 },
                    { 2, "Teach Web Development", "Computers", 2 },
                    { 3, "Gym", "Gym", 3 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "I_Id", "C_Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, "jacksmith@mail.com", "Jack", "Smith" },
                    { 2, null, "luckhairy@mail.com", "Luck", "Hairy" },
                    { 3, null, "darrickdark@mail.com", "Darrick", "Dark" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "S_Id", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "jimblack@mail.com", "Jim", "Black", "2045553344" },
                    { 2, "jackwhite@mail.com", "Jack", "White", "2045552244" },
                    { 3, "georgegrey@mail.com", "George", "Grey", "2045553322" },
                    { 4, "jillfusion@mail.com", "Jill", "Fusion", "2045554444" },
                    { 5, "jamblur@mail.com", "Jam", "blur", "2045555544" },
                    { 6, "johnbutt@mail.com", "John", "Butt", "2045556644" },
                    { 7, "maryjo@mail.com", "Mary", "Jo", "2045557744" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_C_Id",
                table: "CourseStudent",
                column: "C_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_S_Id",
                table: "CourseStudent",
                column: "S_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_C_Id",
                table: "Instructors",
                column: "C_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
