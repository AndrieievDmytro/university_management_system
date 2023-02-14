using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProjectServer.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendanse_User_StudentId",
                table: "Attendanse");

            migrationBuilder.DropForeignKey(
                name: "FK_Position_User_TutorId",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_User_StudentId",
                table: "Theses");

            migrationBuilder.DropColumn(
                name: "ContractEndDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ContractStartDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CurrentSemester",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdStudent",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SalaryCoefficient",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SalaryInContract",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SalaryPerHour",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Scholarship",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ScientificTitle",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ThesisId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TutoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    IdStudent = table.Column<string>(type: "text", nullable: true),
                    CurrentSemester = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Scholarship = table.Column<long>(type: "bigint", nullable: true),
                    ThesisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TutoId = table.Column<int>(type: "integer", nullable: false),
                    ScientificTitle = table.Column<string>(type: "text", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Tutor_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractEmp",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SalaryInContract = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEmp", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ContractEmp_Tutor_UserId",
                        column: x => x.UserId,
                        principalTable: "Tutor",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullTimeEmp",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SalaryCoefficient = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeEmp", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_FullTimeEmp_Tutor_UserId",
                        column: x => x.UserId,
                        principalTable: "Tutor",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartTimeEmp",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WorkingHours = table.Column<int>(type: "integer", nullable: false),
                    SalaryPerHour = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTimeEmp", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PartTimeEmp_Tutor_UserId",
                        column: x => x.UserId,
                        principalTable: "Tutor",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendanse_Student_StudentId",
                table: "Attendanse",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Tutor_TutorId",
                table: "Position",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Student_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendanse_Student_StudentId",
                table: "Attendanse");

            migrationBuilder.DropForeignKey(
                name: "FK_Position_Tutor_TutorId",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Student_StudentId",
                table: "Theses");

            migrationBuilder.DropTable(
                name: "ContractEmp");

            migrationBuilder.DropTable(
                name: "FullTimeEmp");

            migrationBuilder.DropTable(
                name: "PartTimeEmp");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractEndDate",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractStartDate",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSemester",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdStudent",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryCoefficient",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalaryInContract",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalaryPerHour",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Scholarship",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScientificTitle",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThesisId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TutoId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkingHours",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendanse_User_StudentId",
                table: "Attendanse",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_User_TutorId",
                table: "Position",
                column: "TutorId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_User_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
