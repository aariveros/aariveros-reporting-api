using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using aariveros_reporting_api.Models;

namespace aariverosreportingapi.Migrations
{
    [DbContext(typeof(ReportingContext))]
    [Migration("20170226205445_004_Employee")]
    partial class _004_Employee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("aariveros_reporting_api.Models.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cellPhone");

                    b.Property<int>("enterpriseId");

                    b.Property<string>("firstName");

                    b.Property<string>("mail");

                    b.Property<string>("surName");

                    b.HasKey("employeeId");

                    b.HasIndex("enterpriseId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("aariveros_reporting_api.Models.Enterprise", b =>
                {
                    b.Property<int>("enterpriseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cellPhone");

                    b.Property<string>("mail");

                    b.Property<int>("managerId");

                    b.Property<string>("name");

                    b.Property<string>("officePhone");

                    b.HasKey("enterpriseId");

                    b.ToTable("Enterprises");
                });

            modelBuilder.Entity("aariveros_reporting_api.Models.Project", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cellPhone");

                    b.Property<int>("enterpriseId");

                    b.Property<string>("mail");

                    b.Property<int>("managerId");

                    b.Property<string>("name");

                    b.Property<string>("officePhone");

                    b.HasKey("projectId");

                    b.HasIndex("enterpriseId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("aariveros_reporting_api.Models.Employee", b =>
                {
                    b.HasOne("aariveros_reporting_api.Models.Enterprise", "enterprise")
                        .WithMany("employees")
                        .HasForeignKey("enterpriseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("aariveros_reporting_api.Models.Project", b =>
                {
                    b.HasOne("aariveros_reporting_api.Models.Enterprise", "enterprise")
                        .WithMany("projects")
                        .HasForeignKey("enterpriseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
