using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.DataAccess.Models;
using AdaptITAcademyAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business_Rules
{
    public class TrainingRules : IRules<TrainingDTO>
    {
        private AdaptItAcademyRepository<Training> _trainingAcademyRepository;
        private Mapper _courseMapper;

        public TrainingRules()
        {
            _trainingAcademyRepository = new AdaptItAcademyRepository<Training>();
            _courseMapper = new Mapper(new MapperConfiguration(config => config.CreateMap<Training, TrainingDTO>().ReverseMap()));
        }

        public List<TrainingDTO> GetAll()
        {
            List<Training> trainings = _trainingAcademyRepository.GetAll();
            List<TrainingDTO> trainingsDTO = _courseMapper.Map<List<Training>, List<TrainingDTO>>(trainings);
            return trainingsDTO;
        }

        public TrainingDTO GetById(object id)
        {
            Training training = _trainingAcademyRepository.GetById(id);
            TrainingDTO trainingDTO = _courseMapper.Map<Training, TrainingDTO>(training);
            return trainingDTO;
        }

        public void Add(TrainingDTO trainingDTO)
        {
            // ignore trainingDTO id when mapping during post
            var courseMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainingDTO, Training>()
                    .ForMember(training => training.TrainingID, act => act.Ignore());
            });

            _courseMapper = new Mapper(courseMapperConfig);

            Training training = _courseMapper.Map<TrainingDTO, Training>(trainingDTO);

            // compute end date from starting date & number of days training will take + 5 hours assuming each training takes 5 hours
            training.TrainingEndDate = training.TrainingStartDate.AddDays(training.TrainingPeriod).AddHours(5);
            _trainingAcademyRepository.Add(training);
        }

        public void Update(object id, TrainingDTO trainingDTO)
        {
            Training training = _courseMapper.Map<TrainingDTO, Training>(trainingDTO);
            _trainingAcademyRepository.Update(training);
        }

        public void Delete(object id)
        {
            _trainingAcademyRepository.Delete(id);
        }
    }
}
