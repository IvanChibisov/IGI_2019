using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SystemOfTestKnowledge.Models
{
    public class SystemContext: IdentityDbContext<User>
    {
        public DbSet<Test> TestTable { get; set; }
        public DbSet<TestingQuestion> Questions { get; set; }
        public DbSet<UsersAnswer> UsersAnswers { get; set; }

        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
