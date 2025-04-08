using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Group_Account_Model
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("members_username")]
        public List<string> Members_Username { get; set; }
        [Column("admin_usernames")]
        public List<string> Admin_Usernames { get; set; }
    }
}
