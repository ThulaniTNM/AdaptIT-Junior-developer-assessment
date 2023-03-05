using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Errors;
using AdaptITAcademy.DataAccess.Repository.@interface;
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
    public class CourseService : ICourseTrainingService<CourseReadDTO, CourseWriteDTO>
    {
        private IUnitOfWork _courseRepository;
        private IMapper _courseMapper;

        public CourseService(IMapper mapper, IUnitOfWork courseRepositories)
        {
            _courseRepository = courseRepositories;
            _courseMapper = mapper;
        }

        public void Add(CourseWriteDTO courseDTO)
        {
            Course course = _courseMapper.Map<Course>(courseDTO);

            _courseRepository.Courses.Add(course);
            _courseRepository.CommitDbChanges();
        }

        public List<CourseReadDTO> GetAll()
        {
            List<Course> courses = _courseRepository.Courses.GetAll();
            List<CourseReadDTO> coursesDTO = _courseMapper.Map<List<CourseReadDTO>>(courses);

            return coursesDTO;
        }

        public CourseReadDTO GetById(object id)
        {
            Course course = _courseRepository.Courses.GetById(id);

            if (course == null)
                throw new NotFoundItemException($"Course {id} not found");

            CourseReadDTO courseDTO = _courseMapper.Map<CourseReadDTO>(course);
            return courseDTO;
        }

        public void Update(object id, CourseWriteDTO courseDTO)
        {
            Course course = _courseRepository.Courses.GetById(id);

            if (course == null)
                throw new NotFoundItemException($"Course {id} not found");

            course = _courseMapper.Map<Course>(courseDTO);
            course.CourseId = (int)id;

            _courseRepository.Courses.Update(course);
            _courseRepository.CommitDbChanges();
        }

        public void Delete(object id)
        {
            Course course = _courseRepository.Courses.GetById(id);

            if (course == null)
                throw new NotFoundItemException($"Course {id} not found");

            _courseRepository.Courses.Delete(id);
            _courseRepository.CommitDbChanges();
        }
    }
}
