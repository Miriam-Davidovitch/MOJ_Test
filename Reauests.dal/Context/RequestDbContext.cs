using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Requests.dal.Models;

namespace Reauests.dal;

public partial class RequestDbContext : DbContext
{
    public RequestDbContext()
    {
    }

    public RequestDbContext(DbContextOptions<RequestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Request> Requests { get; set; }

    // Connection string is now configured in Program.cs

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Requests__A25C5AA62876B17D");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
