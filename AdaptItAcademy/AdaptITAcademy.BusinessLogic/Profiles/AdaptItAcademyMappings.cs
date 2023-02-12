using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademyAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Profiles
{
    // reusable mapping class
    public class AdaptItAcademyMappings : Profile
    {
        public AdaptItAcademyMappings()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Training, TrainingDTO>().ReverseMap();
            CreateMap<RegisterDelegateDTO, UserTraining>().ReverseMap();
            CreateMap<RegisterDelegateDTO, User>().ReverseMap();
            CreateMap<RegisterDelegateDTO, PhysicalAddress>().ReverseMap();
            CreateMap<RegisterDelegateDTO, PostalAddress>().ReverseMap();
        }
    }
}
