using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tessenger.Server.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_894 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    social_media_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    social_media_link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Account_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Account_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Information",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile_picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    social_medias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    authentationemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationphonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationauthenticatorapp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationsecurityquestions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationsecuritykey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Information", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "User_Account_Model");

            migrationBuilder.DropTable(
                name: "User_Information");
        }
    }
}
