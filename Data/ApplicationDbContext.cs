using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_Online.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Assignment_Online.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment_Online.Models.Assignment> Assignment { get; set; } = default!;
        public DbSet<Assignment_Online.Models.AppUser> AppUser { get; set; }
    }
}
