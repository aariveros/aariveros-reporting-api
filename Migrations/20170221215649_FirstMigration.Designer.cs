using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using aariveros_reporting_api.Models;

namespace aariverosreportingapi.Migrations
{
    [DbContext(typeof(ReportingContext))]
    [Migration("20170221215649_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("aariveros_reporting_api.Models.Enterprise", b =>
                {
                    b.Property<int>("EnterpriseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("EnterpriseId");

                    b.ToTable("Enterprises");
                });

            modelBuilder.Entity("aariveros_reporting_api.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnterpriseId");

                    b.Property<string>("Name");

                    b.HasKey("ProjectId");

                    b.HasIndex("EnterpriseId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("aariveros_reporting_api.Models.Project", b =>
                {
                    b.HasOne("aariveros_reporting_api.Models.Enterprise", "Enterprise")
                        .WithMany("Projects")
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
