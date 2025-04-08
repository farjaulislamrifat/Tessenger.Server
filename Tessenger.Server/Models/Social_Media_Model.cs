using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Social_Media_Model
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("social_media_name")]
        public string Social_Media_Name { get; set; }

        [Column("social_media_link")]
        public string Social_Media_Link { get; set; }
    }
}
