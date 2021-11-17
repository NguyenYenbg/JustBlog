using AutoMapper;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.App_Start
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreatePostViewModel, Post>()
                .ForMember(des => des.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(des => des.UrlSlug, opt => opt.MapFrom(src => src.UrlSlug))
                .ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
        }
    }
}