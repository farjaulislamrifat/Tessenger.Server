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
        public DbSet<Tessenger.Server.Models.SocialMedia> SocialMedia { get; set; } = default!;
        public DbSet<Tessenger.Server.Models.User_Information> User_Information { get; set; } = default!;
    }
}
