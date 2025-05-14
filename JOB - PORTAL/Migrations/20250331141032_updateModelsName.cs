using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JOB___PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class updateModelsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationID",
                table: "tblJobApplication",
                newName: "ApplyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplyID",
                table: "tblJobApplication",
                newName: "ApplicationID");
        }
    }
}
