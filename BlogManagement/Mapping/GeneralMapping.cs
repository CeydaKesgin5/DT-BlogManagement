using AutoMapper;
using Entities.DTOs;
using Entities.DTOs.BlogDTOs;
using Entities.Models;

namespace BlogManagement.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() { 

            CreateMap<Category, CreateBlogDto>().ReverseMap();
            CreateMap<Category, UpdateBlogDto>().ReverseMap();
            CreateMap<UserDtoForCreation, UserDto>().ReverseMap();


        }
    }
}
