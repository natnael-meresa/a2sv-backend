using System.Collections.Generic;
using Domain;

namespace Application.DTOs.Post
{
    public class UpdatePostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public List<Comment> Comments { get; set; } = null!;
    }
}