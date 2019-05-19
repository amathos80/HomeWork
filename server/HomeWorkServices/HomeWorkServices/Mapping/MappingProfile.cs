using AutoMapper;
using HomeWorkServices.Models;
using HomeWorkServices.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Project, ProjectDTO>();
            CreateMap<Project, ProjectDTO>().ReverseMap().ForMember(c=>c.ProjectTasks, opt => opt.Ignore());
            CreateMap<ProjectTask, ProjectTaskDTO>();

        }
    }
}