using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aariverosreportingapi.Migrations
{
    public partial class _003_Enterprise_Project_Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Enterprises_EnterpriseId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "cellPhone",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "managerId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "officePhone",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cellPhone",
                table: "Enterprises",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "Enterprises",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "managerId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "officePhone",
                table: "Enterprises",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Enterprises_enterpriseId",
                table: "Projects",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "EnterpriseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EnterpriseId",
                table: "Projects",
                newName: "enterpriseId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "projectId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Enterprises",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EnterpriseId",
                table: "Enterprises",
                newName: "enterpriseId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_EnterpriseId",
                table: "Projects",
                newName: "IX_Projects_enterpriseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Enterprises_enterpriseId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "cellPhone",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "mail",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "managerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "officePhone",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "cellPhone",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "mail",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "managerId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "officePhone",
                table: "Enterprises");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Enterprises_EnterpriseId",
                table: "Projects",
                column: "enterpriseId",
                principalTable: "Enterprises",
                principalColumn: "enterpriseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "enterpriseId",
                table: "Projects",
                newName: "EnterpriseId");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Enterprises",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "enterpriseId",
                table: "Enterprises",
                newName: "EnterpriseId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_enterpriseId",
                table: "Projects",
                newName: "IX_Projects_EnterpriseId");
        }
    }
}
