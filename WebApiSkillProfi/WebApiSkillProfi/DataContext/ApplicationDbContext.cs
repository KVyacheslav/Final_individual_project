using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiSkillProfi.Model;
using WebApiSkillProfi.Models;

namespace WebApiSkillProfi.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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
