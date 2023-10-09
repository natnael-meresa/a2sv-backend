using System;
using System.Collections.Generic;
using Domain;

namespace Application.DTOs.Post
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public List<Comment> Comments { get; set; } = null!;
    }
}