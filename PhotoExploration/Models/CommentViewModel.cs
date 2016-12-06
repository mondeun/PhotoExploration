using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoExploration.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Commenter { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Guid PhotoId { get; set; }
        
    }
}