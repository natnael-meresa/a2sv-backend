using Application.Features.Posts.Handler.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using Application.Profiles;
using Moq;
using Shouldly;
using Xunit;
using AutoMapper;


namespace test.Posts.Queries
{
    public class GetPostRequestHandlerTests
    {
        private readonly Mock<IPostRepository> _mockRepo;
        private readonly IMapper _mapper;
        public GetPostRequestHandlerTests()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPostListTest()
        {
            var handler = new GetPostRequestListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetPostRequestListRequest(), CancellationToken.None);

            result.Count.ShouldBe(2);
        }
    }


}