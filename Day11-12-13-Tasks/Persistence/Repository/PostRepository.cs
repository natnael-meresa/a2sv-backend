using Application.Persistance.Contracts;
using Domain;

namespace Persistance.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly BloggingContext _context;

        public PostRepository(BloggingContext context) : base(context)
        {
            _context = context;
        }
    }
}