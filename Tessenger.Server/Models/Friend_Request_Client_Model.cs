using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tessenger.Server.Models
{
    public class Friend_Request_Client_Model
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Created_At { get; set; }
        public string ImagePath { get; set; }
        public string RequestType { get; set; } 
        public string RequestUsername { get; set; }
    }
}
