using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSkillProfi.AuthApp;
using WebSkillProfi.Models;

namespace WebSkillProfi.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Request> Requests { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Service> Services { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
