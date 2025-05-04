using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tessenger.Server.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_190 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Education_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    school_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Friend_Request_Info_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_accepted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend_Request_Info_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Friend_Request_Send_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    members = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend_Request_Send_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Group_Account_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    members_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_usernames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Account_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Group_Information_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    group_last_activity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    group_isactive = table.Column<bool>(type: "bit", nullable: false),
                    group_isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    group_isprivate = table.Column<bool>(type: "bit", nullable: false),
                    group_isblocked = table.Column<bool>(type: "bit", nullable: false),
                    group_isarchived = table.Column<bool>(type: "bit", nullable: false),
                    group_ismuted = table.Column<bool>(type: "bit", nullable: false),
                    group_isreported = table.Column<bool>(type: "bit", nullable: false),
                    group_isdeletedbyadmin = table.Column<bool>(type: "bit", nullable: false),
                    group_isdeletedbyuser = table.Column<bool>(type: "bit", nullable: false),
                    group_isdeletedbybot = table.Column<bool>(type: "bit", nullable: false),
                    group_isdeletedbyowner = table.Column<bool>(type: "bit", nullable: false),
                    group_isdeletedbyother = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Information_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Social_Media_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    social_media_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    social_media_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    social_media_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social_Media_Model", x => x.id);
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
                name: "User_Account_Settings_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notification_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    privacy_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    security_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    backup_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sync_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    appearance_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accessibility_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    device_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customization_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_usage_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_export_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_import_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_deletion_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_backup_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_restore_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_sync_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_sharing_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_storage_settings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_encryption_settings = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Account_Settings_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Information_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile_picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    social_medias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    websites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    educations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    authentationemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationphonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationauthenticatorapp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationsecurityquestions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authentationsecuritykey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Information_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Website_Model",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Website_Model", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education_Model");

            migrationBuilder.DropTable(
                name: "Friend_Request_Info_Model");

            migrationBuilder.DropTable(
                name: "Friend_Request_Send_Model");

            migrationBuilder.DropTable(
                name: "Group_Account_Model");

            migrationBuilder.DropTable(
                name: "Group_Information_Model");

            migrationBuilder.DropTable(
                name: "Social_Media_Model");

            migrationBuilder.DropTable(
                name: "User_Account_Model");

            migrationBuilder.DropTable(
                name: "User_Account_Settings_Model");

            migrationBuilder.DropTable(
                name: "User_Information_Model");

            migrationBuilder.DropTable(
                name: "Website_Model");
        }
    }
}
