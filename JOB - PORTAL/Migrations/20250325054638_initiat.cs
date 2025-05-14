using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JOB___PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class initiat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblJobApplication",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSeekerEmail = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobApplication", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "tblJobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillsRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    LastApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProviderEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "tblProvider",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProvider", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tblSeeker",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeekerProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeekerCVFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSeeker", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblJobApplication");

            migrationBuilder.DropTable(
                name: "tblJobs");

            migrationBuilder.DropTable(
                name: "tblProvider");

            migrationBuilder.DropTable(
                name: "tblSeeker");
        }
    }
}
