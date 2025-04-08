using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Tessenger.Server.Models
{
    public class Friend_Request_Send_Model
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("send_time")]
        public DateTime Send_Time { get; set; }
        [Column("message")]
        public string Message { get; set; }

    }
}
