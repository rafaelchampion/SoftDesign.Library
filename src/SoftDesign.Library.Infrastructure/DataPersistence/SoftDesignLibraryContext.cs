using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.Infrastructure.DataPersistence
{
    public class SoftDesignLibraryContext : DbContext
    {
        public SoftDesignLibraryContext() 
            : base("name=SoftDesignLibrary")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region === BOOKS ===

            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id)
                .ToTable("Books");

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Isbn)
                .IsUnique();
            
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(255);
            
            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);
            
            #endregion
            #region === RENTALS ===

            modelBuilder.Entity<Rental>()
                .HasKey(r => r.Id)
                .ToTable("Rentals");

            #endregion
            #region === USERS ===

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .ToTable("Users");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);
            
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
            
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(100);

            #endregion
            
            modelBuilder.Entity<Rental>()
                .HasRequired(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rental>()
                .HasRequired(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}