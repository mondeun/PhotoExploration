using System;

namespace PhotoExploration.Domain.Models
{
    public sealed class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Guid? PhotoId { get; set; }
        public Guid UserId { get; set; }

        public Photo Photo { get; set; }
        public User User { get; set; }
    }
}
