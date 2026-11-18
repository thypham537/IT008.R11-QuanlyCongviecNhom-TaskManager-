using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace QuanlyCongviecNhom.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(150)]
        public string TenProject { get; set; } = string.Empty;

        // nvarchar(max), cho phép null
        public string? Mota { get; set; }

        [Required]
        public DateTime Ngaybatdau { get; set; } = DateTime.Today;

        public DateTime? Ngayketthuc { get; set; }

        // Khóa ngoại: Người tạo / đăng ký dự án
        public int UserIDdk { get; set; }

        [ForeignKey(nameof(UserIDdk))]
        public User? NguoiTao { get; set; }

        // ==================== NAVIGATION PROPERTIES (Quan hệ 1 - N) ====================
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}