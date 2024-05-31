using System.Data.Entity;

namespace InterviewExam.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<RecyclableType> RecyclableTypes { get; set; }
        public DbSet<RecyclableItem> RecyclableItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecyclableType>()
                .HasIndex(rt => rt.Type)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}
