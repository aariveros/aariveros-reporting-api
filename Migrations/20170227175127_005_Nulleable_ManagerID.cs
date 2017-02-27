using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aariverosreportingapi.Migrations
{
    public partial class _005_Nulleable_ManagerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "managerId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "managerId",
                table: "Enterprises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "managerId",
                table: "Projects",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "managerId",
                table: "Enterprises",
                nullable: false);
        }
    }
}
