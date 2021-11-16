using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vk.Mod;

namespace vk.Context
{
    public class UserRtoContext : DbContext
    {
        public UserRtoContext(DbContextOptions<UserRtoContext> options) : base(options)
        {

        }
        public DbSet<UserRto> UserRtos { get; set; }
    }
}
