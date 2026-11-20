using Microsoft.EntityFrameworkCore;
using QuanlyCongviecNhom.Models;

namespace QuanlyCongviecNhom.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=MSI;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;")
                    .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectMember>()
        .HasKey(pm => new { pm.ProjectID, pm.UserID });
            // Tránh lỗi vòng lặp Multiple Cascade Paths trên SQL Server
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Chuẩn bị dữ liệu mẫu (Seed Data - Dòng 7)
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, TenUser="Acom", HovaTen = "Nguyễn Văn A", Email = "admin@uit.edu.vn", Password = "123456", Nhiemvu = "Admin", TgTao= new DateTime(2026,11,1) },
                new User { UserID = 2, TenUser = "Bcom", HovaTen = "Trần Thị B", Email = "member@uit.edu.vn", Password = "123456", Nhiemvu = "Member", TgTao = new DateTime(2026, 11, 1) }
            );
        }
    }
}