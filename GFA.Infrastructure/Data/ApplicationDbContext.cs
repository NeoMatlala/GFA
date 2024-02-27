using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFA.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GFA.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // DB Sets
        public DbSet<Tag> Tags { get; set; }
    }
}
