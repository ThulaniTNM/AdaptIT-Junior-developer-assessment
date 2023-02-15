using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Physical_address;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Postal_address;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.User;
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
            CreateMap<Course, CourseReadDTO>().ReverseMap();
            CreateMap<Course, CourseWriteDTO>().ReverseMap();
            CreateMap<Training, TrainingReadDTO>().ReverseMap();
            CreateMap<Training, TrainingWriteDTO>().ReverseMap();
            CreateMap<RegisterDelegateDTO, UserTraining>().ReverseMap();
            CreateMap<RegisterDelegateDTO, User>().ReverseMap();
            CreateMap<RegisterDelegateDTO, PhysicalAddress>().ReverseMap();
            CreateMap<RegisterDelegateDTO, PostalAddress>().ReverseMap();
        }
    }
}
