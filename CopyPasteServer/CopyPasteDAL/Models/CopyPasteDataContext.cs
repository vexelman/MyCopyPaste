using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CopyPasteDAL.Models
{
    public partial class CopyPasteDataContext : DbContext
    {
        public CopyPasteDataContext()
        {
        }

        public CopyPasteDataContext(DbContextOptions<CopyPasteDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Data> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=P39\\SQL;Database=CopyPasteData;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>(entity =>
            {
                entity.ToTable("data");

                entity.Property(e => e.Body)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("body");

                entity.Property(e => e.Header)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("header");

                entity.Property(e => e.Pass)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Url)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
