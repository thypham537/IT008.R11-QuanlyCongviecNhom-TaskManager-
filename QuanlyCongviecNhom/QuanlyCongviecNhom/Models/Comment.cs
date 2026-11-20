using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanlyCongviecNhom.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public int TaskID { get; set; }

        [ForeignKey(nameof(TaskID))]
        public TaskItem? Task { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User? User { get; set; }

        // nvarchar(max), bắt buộc (NN)
        [Required]
        public string Noidung { get; set; } = string.Empty;

        public DateTime? TgCmt { get; set; } = DateTime.Now;
    }
}