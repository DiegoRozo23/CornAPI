using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Crop> Crop { get; set; }
        public DbSet<EvolutionCrop> EvolutionCrop { get; set; }
        public DbSet<Extermination> Extermination { get; set; }
        public DbSet<Pesticide> Pesticide { get; set; }
        public DbSet<Plague> Plague { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<TypeCrop> TypeCrop { get; set; }
        public DbSet<TypePlague> TypePlague { get; set; }
        public DbSet<TypeUser> TypeUser { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Crop>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<EvolutionCrop>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Extermination>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Pesticide>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Plague>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Supplier>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<TypeCrop>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<TypePlague>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<TypeUser>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => p.IsDeleted);

        }



    }
}
