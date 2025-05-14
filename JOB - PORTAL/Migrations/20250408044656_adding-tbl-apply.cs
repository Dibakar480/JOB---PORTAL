using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JOB___PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class addingtblapply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblJobApplication",
                table: "tblJobApplication");

            migrationBuilder.RenameTable(
                name: "tblJobApplication",
                newName: "tblApply");

            migrationBuilder.AlterColumn<string>(
                name: "JobSeekerEmail",
                table: "tblApply",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblApply",
                table: "tblApply",
                column: "ApplyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblApply",
                table: "tblApply");

            migrationBuilder.RenameTable(
                name: "tblApply",
                newName: "tblJobApplication");

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerEmail",
                table: "tblJobApplication",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblJobApplication",
                table: "tblJobApplication",
                column: "ApplyID");
        }
    }
}
