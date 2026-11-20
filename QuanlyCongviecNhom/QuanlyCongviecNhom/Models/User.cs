using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace QuanlyCongviecNhom.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required] // notnull
        [MaxLength(50)]
        public string TenUser { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string HovaTen { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        // VD: "Admin", "TruongNhom", "ThanhVien"
        [Required]
        [MaxLength(20)]
        public string Nhiemvu { get; set; } = "ThanhVien";

        public DateTime? TgTao { get; set; } = DateTime.Now; // ?: notnull, datatime.now lấy mặc định là thời điểm hiện tại user tạo 

        // ==================== NAVIGATION PROPERTIES (Quan hệ 1 - N) ====================
        public ICollection<Project> CreatedProjects { get; set; } = new List<Project>();
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}