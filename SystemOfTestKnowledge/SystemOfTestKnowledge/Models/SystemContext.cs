using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SystemOfTestKnowledge.Models
{
    public class SystemContext: DbContext
    {
        public DbSet<User> Users { get; set; }
//        public DbSet<Test> Tests { get; set; }
        public DbSet<TestingQuestion> Questions { get; set; }

        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
