using Application.Persistance.Contracts;
using Domain;

namespace Application.Persistance.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly BloggingContext context;

        public CommentRepository(BloggingContext context) : base(context)
        {
            this.context = context;
        }
    }
}