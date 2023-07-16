using System;
using System.Collections.Generic;
using Assigment_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Assigment_Book.Context;

public partial class BookDBContext : DbContext
{
    public BookDBContext()
    {
    }

    public BookDBContext(DbContextOptions<BookDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=APC;Persist Security Info=True;User ID=sa;Password=Pdhung92@;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC27379256F5");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Auth_Name");
            entity.Property(e => e.Biography).HasColumnType("text");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC275F68D581");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthId).HasColumnName("Auth_ID");
            entity.Property(e => e.BookName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Book_Name");
            entity.Property(e => e.CatId).HasColumnName("Cat_ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.PublishYear).HasColumnName("Publish_year");

            entity.HasOne(d => d.Auth).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthId)
                .HasConstraintName("FK__Books__Auth_ID__787EE5A0");

            entity.HasOne(d => d.Cat).WithMany(p => p.Books)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Books__Cat_ID__778AC167");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC272D7E58A3");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CatName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Cat_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
