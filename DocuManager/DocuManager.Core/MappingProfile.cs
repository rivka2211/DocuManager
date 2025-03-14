﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocuManager.Core.DTOs;
using DocuManager.Core.Entities;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Core
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();

            CreateMap<File, FileDTO>();
            CreateMap<FileCreateDTO, File>();
        }
    }


}
