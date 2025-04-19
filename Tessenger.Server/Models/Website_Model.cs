using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Website_Model
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("date_added")]
        public DateTime Date_Added { get; set; }
    }
}
