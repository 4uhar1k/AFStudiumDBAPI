using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AFStudiumDBAPI.Domain.Entities;
using AFStudiumDBAPI.Domains.Entitites;

namespace AFStudiumDBAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Userstable { get; set; }
        public DbSet<Subject> Subjectstable { get; set; }
        public DbSet<Event> Eventstable { get; set; }
        public DbSet<Connections> ConnectionsTable { get; set; }
        public DbSet<Message> Messagestable { get; set; }
    }
    
}
