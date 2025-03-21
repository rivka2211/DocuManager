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
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<File, FileDTO>();
            CreateMap<FileCreateDTO, File>();

            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
