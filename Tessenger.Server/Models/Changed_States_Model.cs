namespace Tessenger.Server.Models
{
    public class Changed_States_Model
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public bool Is_Changed { get; set; }
        public DateTime Created_At { get; set; } 
        public DateTime Updated_At { get; set; } 
        public bool Is_Deleted { get; set; } 
        public bool Is_Updated { get; set; } 
        public virtual User_Account_Model? User_Account_Model { get; set; }
    }
}
