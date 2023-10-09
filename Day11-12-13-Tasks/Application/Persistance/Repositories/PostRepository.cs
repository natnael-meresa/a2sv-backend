using Application.Persistance.Contracts;
using Domain;

namespace Application.Persistance.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly BloggingContext context;

        public PostRepository(BloggingContext context) : base(context)
        {
            this.context = context;
        }
    }
}