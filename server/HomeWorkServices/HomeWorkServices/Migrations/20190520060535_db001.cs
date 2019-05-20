using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWorkServices.Migrations
{
    public partial class db001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<double>(nullable: false, defaultValue: 0.0),
                    IsBillable = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");
            migrationBuilder.InsertData(
             table: "Projects",
             columns: new[] { "Name", "Description", "StartDate", "Priority", "Completed" },
             values: new object[] { "Progetto 1", "Primo progetto", new DateTime(2019, 5, 15), "Alta", false }
             );

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Name", "Description", "StartDate", "Priority", "Completed" },
                values: new object[] { "Progetto 2", "Secondo progetto", new DateTime(2019, 4, 15), "Media", false }
                );

            migrationBuilder.InsertData(
              table: "Projects",
              columns: new[] { "Name", "Description", "StartDate", "EndDate", "Priority", "Completed" },
              values: new object[] { "Progetto 3", "Terzo progetto", new DateTime(2019, 3, 15), new DateTime(2019, 5, 1), "Bassa", true }
              );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
