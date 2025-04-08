using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tessenger.Server.Models;

namespace Tessenger.Server.Data
{
    public class TessengerServerContext : DbContext
    {
        public TessengerServerContext (DbContextOptions<TessengerServerContext> options)
            : base(options)
        {
        }

        public DbSet<Tessenger.Server.Models.User_Account_Model> User_Account_Model { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.Social_Media_Model> Social_Media_Model { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.User_Information_Model> User_Information_Model { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.Friend_Request_Send_Model> Friend_Request_Send_Model { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.Group_Account_Model> Group_Account_Model { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.Group_Information_Model> Group_Information_Model { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.User_Account_Settings_Model> User_Account_Settings_Model { get; set; } = default!;
 
       

    }
}
