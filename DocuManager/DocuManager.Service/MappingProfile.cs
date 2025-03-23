using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocuManager.Core.DTOs;
using DocuManager.Core.Entities;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateDTO>().ReverseMap();

            CreateMap<File, FileDTO>().ReverseMap();
            CreateMap<File, FileCreateDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<ActivityHistory, ActivityHisotiryDTO>().ReverseMap();
        }
    }
}
