using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Models;
using Vigant.ViewModels;

namespace Vigant.MappingConfiguration
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationRole, RoleViewModel>();
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<Blog, BlogViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Interest, InterestViewModel>();
            CreateMap<Link, LinkViewModel>();
            CreateMap<BlogInputViewModel, Blog>()
                .ForMember(m => m.Comments, opt => opt.MapFrom(src => new List<Comment>()))
                .ForMember(m => m.UploadDate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<CommentInputViewModel, Comment>();
            CreateMap<InterestInputViewModel, Interest>().ForMember(dest => dest.Participants, opt => opt.MapFrom(src => new List<ApplicationUser>()));
            CreateMap<LinkInputViewModel, Link>();
        }
    }
}
