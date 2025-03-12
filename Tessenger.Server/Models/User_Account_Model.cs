using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class User_Account_Model
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("username")]
        [Required]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Column("password")]
        [Required]
        public string Password { get; set; }
        
    }
}
