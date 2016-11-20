using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoExploration.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int? PhotoId { get; set; }
        [ForeignKey(name: "PhotoId")]
        public virtual Photo Photo { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(name: "UserId")]
        public virtual User User { get; set; }
    }
}