using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JOB___PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class updateA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "tblJobs",
                newName: "Company_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company_Name",
                table: "tblJobs",
                newName: "CompanyName");
        }
    }
}
