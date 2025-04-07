using AutoMapper;
using BlogManagement.DTOs.BlogDTOs;
using BlogManagement.Models;

namespace BlogManagement.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() { 

            CreateMap<Category, CreateBlogDto>().ReverseMap();
            CreateMap<Category, UpdateBlogDto>().ReverseMap();
        }
    }
}
