using Application.Features.Posts.Handler.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using Application.Profiles;
using Moq;
using Shouldly;
using Xunit;
using AutoMapper;
using Application.DTOs.Post;
using Application.Responses;


namespace test.Posts.Queries
{
    public class CreatePostCommandHandlerTests
    {
        private readonly Mock<IPostRepository> _mockRepo;
        private readonly IMapper _mapper;

        private readonly CreatePostDto _createPostDto;
        public CreatePostCommandHandlerTests()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            
            });
            _mapper = mapperConfig.CreateMapper();

            _createPostDto = new CreatePostDto
            {
                Content = "This is a test post",
                Title = "Test Post"
            };
        }

        [Fact]
        public async Task GetPostListTest()
        {
            var handler = new CreatePostRequestCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreatePostRequestCommand(){CreatePostDto = _createPostDto}, CancellationToken.None);

            var posts = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            posts.Count.ShouldBe(3);
        }
    }


}