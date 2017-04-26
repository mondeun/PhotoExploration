using System;
using PhotoExploration.Domain.Models;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public static class CommentHelper
    {
        public static Comment MapComment(this CommentViewModel viewComment)
        {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                PhotoId = viewComment.PhotoId,
                Date = DateTime.UtcNow,
                Text = viewComment.Comment,
                UserId = UserRepository.GetUserId(viewComment.Commenter)
            };

            return comment;
        }
    }
}