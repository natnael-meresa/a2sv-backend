using Application.Persistance.Contracts;
using Domain;
using Moq;

namespace test.Posts
{
    public static class MockPostRepository
    {
        public static Mock<IPostRepository> GetPostRepository()
        {

            var posts = new List<Post>{
                new Post
                {
                    Content = "some contet",
                    PostId = 1,
                    Title = "some title"
                },
                new Post
                {
                    Content = "some contet",
                    PostId = 2,
                    Title = "some title"
                }
            };

            var mockRepo = new Mock<IPostRepository>();

            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(posts);

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).ReturnsAsync((Post post) => 
            {
                posts.Add(post);
                return post;
            
            });
            
            return mockRepo;
            
        } 
    }
}