using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class User_Account_Settings_Model
    {

        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("theme")]
        public string Theme { get; set; }
        [Column("language")]
        public string Language { get; set; }
        [Column("notification_settings")]
        public string Notification_Settings { get; set; }
        [Column("privacy_settings")]
        public string Privacy_Settings { get; set; }
        [Column("security_settings")]
        public string Security_Settings { get; set; }
        [Column("account_settings")]
        public string Account_Settings { get; set; }
        [Column("app_settings")]
        public string App_Settings { get; set; }
        [Column("location_settings")]
        public string Location_Settings { get; set; }
        [Column("data_settings")]
        public string Data_Settings { get; set; }
        [Column("backup_settings")]
        public string Backup_Settings { get; set; }
        [Column("sync_settings")]
        public string Sync_Settings { get; set; }
        [Column("appearance_settings")]
        public string Appearance_Settings { get; set; }
        [Column("accessibility_settings")]
        public string Accessibility_Settings { get; set; }
        [Column("device_settings")]
        public string Device_Settings { get; set; }
        [Column("customization_settings")]
        public string Customization_Settings { get; set; }
        [Column("data_usage_settings")]
        public string Data_Usage_Settings { get; set; }
        [Column("data_export_settings")]
        public string Data_Export_Settings { get; set; }
        [Column("data_import_settings")]
        public string Data_Import_Settings { get; set; }
        [Column("data_deletion_settings")]
        public string Data_Deletion_Settings { get; set; }
        [Column("data_backup_settings")]
        public string Data_Backup_Settings { get; set; }
        [Column("data_restore_settings")]
        public string Data_Restore_Settings { get; set; }
        [Column("data_sync_settings")]
        public string Data_Sync_Settings { get; set; }
        [Column("data_sharing_settings")]
        public string Data_Sharing_Settings { get; set; }
        [Column("data_storage_settings")]
        public string Data_Storage_Settings { get; set; }
        [Column("data_encryption_settings")]
        public string Data_Encryption_Settings { get; set; }
    }
}
