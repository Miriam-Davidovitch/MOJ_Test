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

    public virtual DbSet<Request> RequestsTbl { get; set; }

    // Connection string is now configured in Program.cs

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("RequestsTbl");
            entity.HasKey(e => e.RequestID);

            entity.Property(e => e.RequestCreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RequestorName).HasMaxLength(255).IsRequired();
            entity.Property(e => e.RequestDescription).HasMaxLength(255);
            entity.Property(e => e.RequestTopic).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
