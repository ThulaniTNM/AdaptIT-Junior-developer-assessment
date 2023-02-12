using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.DataAccess.Models;
using AdaptITAcademyAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business
{
    public class CourseRules : IRules<CourseDTO>
    {
        private AdaptItAcademyRepository<Course> _courseAcademyRepository;
        private IMapper _courseMapper;

        public CourseRules(IMapper mapper)
        {
            _courseAcademyRepository = new AdaptItAcademyRepository<Course>();
            _courseMapper = mapper;
        }

        public void Add(CourseDTO courseDTO)
        {
            // ignore courseDTO id when mapping during post
            // courseDTO read & write creation can resolve this.
            var courseMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>()
                    .ForMember(course => course.CourseId, act => act.Ignore());
            });

            var tempMapper = new Mapper(courseMapperConfig);
            Course course = tempMapper.Map<Course>(courseDTO);

            _courseAcademyRepository.Add(course);
        }

        public List<CourseDTO> GetAll()
        {
            List<Course> courses = _courseAcademyRepository.GetAll();
            List<CourseDTO> coursesDTO = _courseMapper.Map<List<CourseDTO>>(courses);

            return coursesDTO;
        }

        public CourseDTO GetById(object id)
        {
            Course course = _courseAcademyRepository.GetById(id);
            CourseDTO courseDTO = _courseMapper.Map< CourseDTO>(course);

            return courseDTO;
        }

        public void Update(object id, CourseDTO courseDTO)
        {
            Course course = _courseMapper.Map<Course>(courseDTO);
            _courseAcademyRepository.Update(course);
        }

        public void Delete(object id)
        {
            _courseAcademyRepository.Delete(id);
        }
    }
}
