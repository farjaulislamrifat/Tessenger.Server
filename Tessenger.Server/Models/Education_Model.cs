using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Education_Model
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("school_name")]
        public string School_Name { get; set; }
        [Column("degree")]
        public string Degree { get; set; }
        [Column("start_date")]
        public string Start_Date { get; set; }
        [Column("end_date")]
        public string End_Date { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
