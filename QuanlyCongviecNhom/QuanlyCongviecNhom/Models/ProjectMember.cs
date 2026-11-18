using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanlyCongviecNhom.Models
{
    [Table("ProjectMembers")]
    public class ProjectMember
    {
        // Khóa chính phức hợp (ProjectID + UserID) -> cấu hình HasKey trong AppDbContext của Người A
        public int ProjectID { get; set; }

        [ForeignKey(nameof(ProjectID))]
        public Project? Project { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User? User { get; set; }

        // VD: "Trưởng nhóm", "Thành viên"
        [Required]
        [MaxLength(20)]
        public string Vaitro { get; set; } = "Thành viên";

        public DateTime? TgThamGia { get; set; } = DateTime.Now;
    }
}