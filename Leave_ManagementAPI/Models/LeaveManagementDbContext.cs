using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leave_ManagementAPI.Models;

public partial class LeaveManagementDbContext : DbContext
{
    public LeaveManagementDbContext()
    {
    }

    public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<LeaveStatusHistory> LeaveStatusHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JH2LFHC\\SQLEXPRESS;Initial Catalog=LeaveManagementDB;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__LeaveReq__796DB95950AEA29B");

            entity.Property(e => e.AppliedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LeaveType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Reason)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.User).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveRequ__UserI__4E88ABD4");
        });

        modelBuilder.Entity<LeaveStatusHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__LeaveSta__4D7B4ABD2F921B0C");

            entity.ToTable("LeaveStatusHistory");

            entity.Property(e => e.NewStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OldStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Leave).WithMany(p => p.LeaveStatusHistories)
                .HasForeignKey(d => d.LeaveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveStat__Leave__5535A963");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.LeaveStatusHistories)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveStat__Updat__5629CD9C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CB11FE26F");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534034D81CC").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
