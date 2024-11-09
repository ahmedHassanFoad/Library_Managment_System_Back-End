using LMS_1.Entity;
using Microsoft.EntityFrameworkCore;

namespace LMS_1.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) 
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BookIssuer> bookIssuers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.IsAvilable).HasDefaultValue(true);
                entity.Property(e=>e.catagoryId).IsRequired();

                entity.HasOne(e => e.Catagory)
                  .WithMany(c => c.Books)
                  .HasForeignKey(c=>c.catagoryId)
                  .IsRequired();
            });
            modelBuilder.Entity<Catagory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.IssuerName).IsRequired();
                
                entity.Property(e => e.IssueDate).IsRequired();
                entity.Property(e => e.IssuePeriod).IsRequired();

            });
            modelBuilder.Entity<BookIssuer>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.EventId }); // Composite key using BookId and EventId

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100);

                // Foreign key relationship with Book
                entity.HasOne(bi => bi.Book)
                    .WithMany()
                    .HasForeignKey(bi => bi.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Foreign key relationship with Event
                entity.HasOne(bi => bi.Event)
                    .WithMany()
                    .HasForeignKey(bi => bi.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
