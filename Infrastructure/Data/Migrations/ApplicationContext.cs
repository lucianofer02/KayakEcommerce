using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KayaksEcommerce.Infrastructure.Data.Migrations
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Kayak> Kayaks { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes configurar las entidades y relaciones si es necesario
            modelBuilder.Entity<Kayak>().ToTable("Kayaks");
            modelBuilder.Entity<User>().ToTable("Users");

            // Puedes añadir configuraciones adicionales aquí
        }
    }
}
