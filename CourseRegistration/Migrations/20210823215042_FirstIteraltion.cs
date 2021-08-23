using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseRegistration.Migrations
{
    public partial class FirstIteraltion : Migration
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    C_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.S_Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_C_Id",
                        column: x => x.C_Id,
                        principalTable: "Courses",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "C_Id", "Description", "Name", "Number" },
                values: new object[] { 1, "Math", "Math", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "C_Id", "Description", "Name", "Number" },
                values: new object[] { 2, "Teach Web Development", "Computers", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "C_Id", "Description", "Name", "Number" },
                values: new object[] { 3, "Gym", "Gym", 3 });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "I_Id", "C_Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "jacksmith@mail.com", "Jack", "Smith" },
                    { 2, 2, "luckhairy@mail.com", "Luck", "Hairy" },
                    { 3, 3, "darrickdark@mail.com", "Darrick", "Dark" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "S_Id", "C_Id", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "jimblack@mail.com", "Jim", "Black", "2045553344" },
                    { 4, 1, "jillfusion@mail.com", "Jill", "Fusion", "2045554444" },
                    { 5, 1, "jamblur@mail.com", "Jam", "blur", "2045555544" },
                    { 2, 2, "jackwhite@mail.com", "Jack", "White", "2045552244" },
                    { 7, 2, "maryjo@mail.com", "Mary", "Jo", "2045557744" },
                    { 3, 3, "georgegrey@mail.com", "George", "Grey", "2045553322" },
                    { 6, 3, "johnbutt@mail.com", "John", "Butt", "2045556644" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_C_Id",
                table: "Instructors",
                column: "C_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_C_Id",
                table: "Students",
                column: "C_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
