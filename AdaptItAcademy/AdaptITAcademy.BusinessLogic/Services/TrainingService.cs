using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using AdaptITAcademy.DataAccess.Repository;
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
        private IMapper _trainingMapper;

        public TrainingService(IMapper mapper, IUnitOfWork trainingRepositories)
        {
            _trainingRepositories = _trainingRepositories;
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
            TrainingReadDTO trainingDTO = _trainingMapper.Map<TrainingReadDTO>(training);
            return trainingDTO;
        }

        public void Add(TrainingWriteDTO trainingDTO)
        {
            Training training = _trainingMapper.Map<Training>(trainingDTO);

            // compute end date from starting date & number of days training will take + 5 hours assuming each training takes 5 hours
            training.TrainingEndDate = training.TrainingStartDate.AddDays(training.TrainingPeriod).AddHours(5);
          Training savedTraining =  _trainingRepositories.Trainings.Add(training);
        }

        public void Update(object id, TrainingReadDTO trainingDTO)
        {
            Training training = _trainingMapper.Map<Training>(trainingDTO);
            _trainingRepositories.Trainings.Update(training);
        }

        public void Delete(object id)
        {
            _trainingRepositories.Trainings.Delete(id);
        }

        public void SaveChanges()
        {
            _trainingRepositories.CommitDbChanges();
        }
    }
}
