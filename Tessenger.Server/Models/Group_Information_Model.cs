using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Group_Information_Model
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("group_name")]
        public string Group_Name { get; set; }
        [Column("group_description")]
        public string Group_Description { get; set; }
        [Column("Owner_username")]
        public string Owner_Username { get; set; }
     
        [Column("group_picture")]
        public string Group_Picture { get; set; }
        [Column("group_creation_date")]
        public DateTime Group_Creation_Date { get; set; }
        [Column("group_last_activity")]
        public DateTime Group_Last_Activity { get; set; }
        [Column("group_isactive")]
        public bool Group_Isactive { get; set; }
        [Column("group_isdeleted")]
        public bool Group_Isdeleted { get; set; }
        [Column("group_isprivate")]
        public bool Group_Isprivate { get; set; }
        [Column("group_isblocked")]
        public bool Group_Isblocked { get; set; }
        [Column("group_isarchived")]
        public bool Group_Isarchived { get; set; }
        [Column("group_ismuted")]
        public bool Group_Ismuted { get; set; }
        [Column("group_isreported")]
        public bool Group_Isreported { get; set; }
        [Column("group_isdeletedbyadmin")]
        public bool Group_Isdeletedbyadmin { get; set; }
        [Column("group_isdeletedbyuser")]
        public bool Group_Isdeletedbyuser { get; set; }
        [Column("group_isdeletedbybot")]
        public bool Group_Isdeletedbybot { get; set; }
        [Column("group_isdeletedbyowner")]
        public bool Group_Isdeletedbyowner { get; set; }
        [Column("group_isdeletedbyother")]
        public bool Group_Isdeletedbyother { get; set; }
       
   
    }
}
