﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QME.Basic.API.Models
{
    public partial class QMEContext : DbContext
    {
        public QMEContext()
        {
        }

        public QMEContext(DbContextOptions<QMEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<QueueDatum> QueueData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CTC18KI\\SQLEXPRESS;Initial Catalog=QME;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<QueueDatum>(entity =>
            {
                entity.HasKey(e => e.Qguid)
                    .HasName("PK__QueueDat__E0EF35A19165F0E6");

                entity.Property(e => e.Qguid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QGuid");

                entity.Property(e => e.Qdesc).HasColumnName("QDesc");

                entity.Property(e => e.Qid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("QId");

                entity.Property(e => e.Qname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
