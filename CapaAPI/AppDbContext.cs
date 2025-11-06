using Microsoft.EntityFrameworkCore;
using CapaAPI.Models;

namespace CapaAPI
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Nota> Notas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiante>().ToTable("Estudiante");
            modelBuilder.Entity<Profesor>().ToTable("Profesor");
            modelBuilder.Entity<Nota>().ToTable("Nota");

            modelBuilder.Entity<Estudiante>().HasKey(e => e.Id);
            modelBuilder.Entity<Profesor>().HasKey(p => p.Id);
            modelBuilder.Entity<Nota>().HasKey(n => n.Id);
        }
    }
}
