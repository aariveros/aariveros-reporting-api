using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aariverosreportingapi.Migrations
{
    public partial class _004_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cellPhone = table.Column<string>(nullable: true),
                    enterpriseId = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    surName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Enterprises_enterpriseId",
                        column: x => x.enterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "enterpriseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_enterpriseId",
                table: "Employees",
                column: "enterpriseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
