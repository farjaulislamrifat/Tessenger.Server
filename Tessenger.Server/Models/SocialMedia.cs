using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class SocialMedia
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("social_media_name")]
        public string Social_Media_Name { get; set; }

        [Column("social_media_link")]
        public string Social_Media_Link { get; set; }
    }
}
