using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Server.REST.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OGrade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Values = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PESEL = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Born = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OSubject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RStudentSubject",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RStudentSubject", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_RStudentSubject_OStudent_StudentId",
                        column: x => x.StudentId,
                        principalTable: "OStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RStudentSubject_OSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "OSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RStudentSubject_SubjectId",
                table: "RStudentSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OGrade");

            migrationBuilder.DropTable(
                name: "RStudentSubject");

            migrationBuilder.DropTable(
                name: "OStudent");

            migrationBuilder.DropTable(
                name: "OSubject");
        }
    }
}
