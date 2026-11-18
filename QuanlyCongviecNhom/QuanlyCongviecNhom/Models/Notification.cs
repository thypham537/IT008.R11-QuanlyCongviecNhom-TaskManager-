using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanlyCongviecNhom.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User? User { get; set; }

        public int? ProjectID { get; set; }

        [ForeignKey(nameof(ProjectID))]
        public Project? Project { get; set; }

        [Required]
        [MaxLength(500)]
        public string Thongbao { get; set; } = string.Empty;

        // bit trong SQL Server (false = chưa đọc, true = đã đọc)
        public bool Trangthaidoc { get; set; } = false;

        public DateTime? TgNote { get; set; } = DateTime.Now;
    }
}