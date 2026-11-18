using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanlyCongviecNhom.Models
{
    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        public int TaskID { get; set; }

        // Khóa ngoại trỏ về Projects
        public int ProjectID { get; set; }

        [ForeignKey(nameof(ProjectID))]
        public Project? Project { get; set; }

        // Khóa ngoại trỏ về Users (Người đảm nhận - để int? phòng trường hợp task chưa giao cho ai)
        public int? AssigneeID { get; set; }

        [ForeignKey(nameof(AssigneeID))]
        public User? Assignee { get; set; }

        [Required]
        [MaxLength(200)]
        public string Tieude { get; set; } = string.Empty;

        // nvarchar(max), cho phép null
        public string? MotaChitiet { get; set; }

        // Mức độ ưu tiên (khớp giao diện): "Thấp", "Trung bình", "Cao", "Khẩn cấp"
        [Required]
        [MaxLength(20)]
        public string STTUutien { get; set; } = "Trung bình";

        // Trạng thái (khớp StatusComboBoxStyle): "Cần làm", "Đang làm", "Hoàn thành"
        [Required]
        [MaxLength(20)]
        public string Trangthai { get; set; } = "Cần làm";

        public DateTime? Hanchot { get; set; }

        public DateTime? Tgtaotask { get; set; } = DateTime.Now;

        // ==================== NAVIGATION PROPERTIES ====================
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}