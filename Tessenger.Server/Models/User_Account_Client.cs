namespace Tessenger.Server.Models
{
    public class User_Show_Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ImagePath { get; set; }
        public uint MutualFriends { get; set; }
    }
}
