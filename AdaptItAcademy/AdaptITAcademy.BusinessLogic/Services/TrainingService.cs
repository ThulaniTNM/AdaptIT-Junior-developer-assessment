using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using AdaptITAcademy.BusinessLogic.Errors;
using AdaptITAcademy.DataAccess.Repository.implementation;
using AdaptITAcademy.DataAccess.Repository.@interface;
using AdaptITAcademyAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business_Rules
{
    public class TrainingService : ICourseTrainingService<TrainingReadDTO, TrainingWriteDTO>
    {
        private IUnitOfWork _trainingRepositories;
        private readonly ICourseTrainingService<CourseReadDTO, CourseWriteDTO> _courseService;
        private IMapper _trainingMapper;

        public TrainingService(IMapper mapper, 
            IUnitOfWork trainingRepositories,
             ICourseTrainingService<CourseReadDTO, CourseWriteDTO> courseService)
        {
            _trainingRepositories = trainingRepositories;
            _courseService = courseService;
            _trainingMapper = mapper;
        }

        public List<TrainingReadDTO> GetAll()
        {
            List<Training> trainings = _trainingRepositories.Trainings.GetAll();
            List<TrainingReadDTO> trainingsDTO = _trainingMapper.Map<List<TrainingReadDTO>>(trainings);
            return trainingsDTO;
        }

        public TrainingReadDTO GetById(object id)
        {
            Training training = _trainingRepositories.Trainings.GetById(id);

            if (training == null)
                throw new NotFoundItemException($"Training {id} not found");

            TrainingReadDTO trainingDTO = _trainingMapper.Map<TrainingReadDTO>(training);
            return trainingDTO;
        }

        public void Add(TrainingWriteDTO trainingDTO)
        {
            CourseReadDTO course= _courseService.GetById(trainingDTO.CourseId); // throw error for course not available.
            Training training = _trainingMapper.Map<Training>(trainingDTO);

            // compute end date from starting date & number of days training will take + 5 hours assuming each training takes 5 hours
            training.TrainingEndDate = training.TrainingStartDate.AddDays(training.TrainingPeriod).AddHours(5);
            Training savedTraining = _trainingRepositories.Trainings.Add(training);
            _trainingRepositories.CommitDbChanges();
        }

        public void Update(object id, TrainingWriteDTO trainingDTO)
        {
            CourseReadDTO course = _courseService.GetById(trainingDTO.CourseId); // throw error for course not available.
            Training training = _trainingRepositories.Trainings.GetById(id);

            if (training == null)
                throw new NotFoundItemException($"Training {id} not found");

            training = _trainingMapper.Map<Training>(trainingDTO);
            training.TrainingID = (int)id;

            _trainingRepositories.Trainings.Update(training);
            _trainingRepositories.CommitDbChanges();
        }

        public void Delete(object id)
        {
            Training training = _trainingRepositories.Trainings.GetById(id);

            if (training == null)
                throw new NotFoundItemException($"Training {id} not found");

            _trainingRepositories.Trainings.Delete(id);
            _trainingRepositories.CommitDbChanges();
        }
    }
}
