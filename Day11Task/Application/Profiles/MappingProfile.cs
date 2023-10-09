using Application.DTOs.Post;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, ListPostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
        }
    }    
}