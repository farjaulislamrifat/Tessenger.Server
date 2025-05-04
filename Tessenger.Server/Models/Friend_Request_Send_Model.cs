using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Tessenger.Server.Models
{
    public class Friend_Request_Send_Model
    {   
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("members")]
        public List<ulong> Members_Info { get; set; }
    }
}
