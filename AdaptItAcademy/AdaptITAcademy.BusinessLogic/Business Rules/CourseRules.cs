﻿using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
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
    public class CourseRules
    {
        private AdaptItAcademyRepository<Course> _courseAcademyRepository;
        private Mapper _courseMapper;

        public CourseRules()
        {
            _courseAcademyRepository = new AdaptItAcademyRepository<Course>();
            _courseMapper = new Mapper(new MapperConfiguration(config => config.CreateMap<Course, CourseDTO>().ReverseMap()));
        }

        public void AddCourse(CourseDTO courseDTO)
        {
            // ignore courseDTO id when mapping during post
            var courseMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>()
                    .ForMember(course => course.CourseId, act => act.Ignore());
            });

            _courseMapper = new Mapper(courseMapperConfig);

            Course course = _courseMapper.Map<CourseDTO, Course>(courseDTO);
            _courseAcademyRepository.Add(course);
        }

        public List<CourseDTO> GetAllCourses()
        {
            List<Course> courses = _courseAcademyRepository.GetAll();
            List<CourseDTO> coursesDTO = _courseMapper.Map<List<Course>, List<CourseDTO>>(courses);
            return coursesDTO;
        }

        public CourseDTO GetCourseById(object id)
        {
            Course course = _courseAcademyRepository.GetById(id);
            CourseDTO courseDTO = _courseMapper.Map<Course, CourseDTO>(course);
            return courseDTO;
        }

        public void UpdateCourse(object id, CourseDTO courseDTO)
        {
            Course course = _courseMapper.Map<CourseDTO, Course>(courseDTO);
            _courseAcademyRepository.Update(course);
        }

        public void DeleteCourse(object id)
        {
            _courseAcademyRepository.Delete(id);
        }
    }
}
