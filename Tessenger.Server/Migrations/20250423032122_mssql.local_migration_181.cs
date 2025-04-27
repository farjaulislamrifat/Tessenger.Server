using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tessenger.Server.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_181 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "User_Information_Model",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "User_Information_Model",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "User_Information_Model");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "User_Information_Model");
        }
    }
}
