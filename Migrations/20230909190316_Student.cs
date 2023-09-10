using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Migrations
{
    /// <inheritdoc />
    public partial class Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_Details_no_Combined",
                columns: table => new
                {
                    Student_Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Student_Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    CourseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TeacherId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student___A2F4E98CF12B577D", x => x.Student_Id);
                });

            migrationBuilder.CreateTable(
                name: "Student_Grade",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CourseTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Unit = table.Column<short>(type: "smallint", nullable: true),
                    Grade = table.Column<decimal>(type: "decimal(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student___FC00E0017DC288D9", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "Student_Grade_no_Combined",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CourseTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Unit = table.Column<short>(type: "smallint", nullable: true),
                    Grade = table.Column<decimal>(type: "decimal(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student___FC00E001D6F365BD", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "('NA')"),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CourseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teacher__EDF259647932981E", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher_no_Combined",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CourseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teacher___EDF259641A57A0E5", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Student_Details",
                columns: table => new
                {
                    Student_Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false, defaultValueSql: "('Mr')"),
                    Student_Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    CourseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TeacherId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "('NA')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student___A2F4E98C270B7942", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK__Student_D__Cours__47DBAE45",
                        column: x => x.CourseCode,
                        principalTable: "Student_Grade",
                        principalColumn: "CourseCode");
                    table.ForeignKey(
                        name: "Fk_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Details_CourseCode",
                table: "Student_Details",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Details_TeacherId",
                table: "Student_Details",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Details");

            migrationBuilder.DropTable(
                name: "Student_Details_no_Combined");

            migrationBuilder.DropTable(
                name: "Student_Grade_no_Combined");

            migrationBuilder.DropTable(
                name: "Teacher_no_Combined");

            migrationBuilder.DropTable(
                name: "Student_Grade");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
