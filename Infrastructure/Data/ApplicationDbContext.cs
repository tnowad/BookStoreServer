using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartDetail> CartDetails { get; set; } = null!;
        public DbSet<Catalogue> Catalogues { get; set; } = null!;
        public DbSet<BookCatalogue> BookCatalogues { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartDetail>()
                .HasKey(cd => new { cd.CartId, cd.BookId });

            modelBuilder.Entity<BookCatalogue>()
                .HasKey(bc => new { bc.BookId, bc.CatalogueId });

            modelBuilder.Entity<CartDetail>()
                .HasOne(cd => cd.Cart)
                .WithMany(c => c.CartDetails)
                .HasForeignKey(cd => cd.CartId);

            modelBuilder.Entity<CartDetail>()
                .HasOne(cd => cd.Book)
                .WithMany(b => b.CartDetails)
                .HasForeignKey(cd => cd.BookId);

            modelBuilder.Entity<BookCatalogue>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCatalogues)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCatalogue>()
                .HasOne(bc => bc.Catalogue)
                .WithMany(c => c.BookCatalogues)
                .HasForeignKey(bc => bc.CatalogueId);

            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Cart>().ToTable("Carts");
            modelBuilder.Entity<CartDetail>().ToTable("CartDetails");
            modelBuilder.Entity<Catalogue>().ToTable("Catalogues");
            modelBuilder.Entity<BookCatalogue>().ToTable("BookCatalogues");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<CartDetail>()
                .HasIndex(cd => new { cd.CartId, cd.BookId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Book>()
                .Property(b => b.RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }
    }
}

