using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class User_Information
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [Required]
        public string Username { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("phone_number")]
        public string Phone_Number { get; set; }

        [Column("first_name")]
        public string First_Name { get; set; }

        [Column("last_name")]
        public string Last_Name { get; set; }

        [Column("profile_picture")]
        public string Profile_Picture { get; set; }

        [Column("bio")]
        public string Bio { get; set; }

        [Column("date_of_birth")]
        [DataType(DataType.Date)]
        public DateTime Date_Of_Birth { get; set; }

        [Column("social_medias")]
        public List<int> Social_Medias { get; set; }

        [Column("nationality")]
        [DataType(DataType.Text)]
        public string Nationality { get; set; }

        [Column("isactive")]
        public bool Isactive { get; set; }

        [Column("authentationemail")]
        [DataType(DataType.EmailAddress)]
        public string Authentation_Email { get; set; }

        [Column("authentationphonenumber")]
        [DataType(DataType.PhoneNumber)]
        public string Authentation_Phone_Number { get; set; }

        [Column("authentationauthenticatorapp")]
        [DataType(DataType.Text)]
        public string Authentation_Authenticator_App { get; set; }

        [Column("authentationsecurityquestions")]
        [DataType(DataType.Text)]
        public string Authentation_Security_Questions { get; set; }

        [Column("authentationsecuritykey")]
        [DataType(DataType.Text)]
        public string Authentation_Security_Key { get; set; }
    }
  
}
