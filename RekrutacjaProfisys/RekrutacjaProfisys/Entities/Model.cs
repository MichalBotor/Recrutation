using Microsoft.EntityFrameworkCore;
namespace RekrutacjaProfisys.Entities
{
    public class Model : DbContext
    {
        public Model()
        {
        }

        public Model(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dokuments> Dokuments { get; set; }
        public DbSet<DocumentItems> DocumentItems { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<Dokuments>()
       .HasKey(d => d.Id);
      
          modelBuilder.Entity<DocumentItems>()
            .HasKey(di => di.ID);

        
       }
    }
}

