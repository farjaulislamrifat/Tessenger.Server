using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Friend_Request_Info_Model
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("message")]
        public string Message { get; set; }
        [Column("is_accepted")]
        public bool Is_Accepted { get; set; }
        [Column("created_at")]
        public DateTime Created_At { get; set; }
        [Column("requesttype")]
        public Algorithoms.RequestType RequestType { get; set; } 

    }
}
