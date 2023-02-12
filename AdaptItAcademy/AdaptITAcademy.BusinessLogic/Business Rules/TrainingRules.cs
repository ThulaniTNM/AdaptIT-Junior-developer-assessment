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
        private IMapper _trainingMapper;

        public TrainingRules(IMapper mapper)
        {
            _trainingAcademyRepository = new AdaptItAcademyRepository<Training>();
            _trainingMapper = mapper;
        }

        public List<TrainingDTO> GetAll()
        {
            List<Training> trainings = _trainingAcademyRepository.GetAll();
            List<TrainingDTO> trainingsDTO = _trainingMapper.Map< List<TrainingDTO>>(trainings);
            return trainingsDTO;
        }

        public TrainingDTO GetById(object id)
        {
            Training training = _trainingAcademyRepository.GetById(id);
            TrainingDTO trainingDTO = _trainingMapper.Map<TrainingDTO>(training);
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

            var tempMapper = new Mapper(courseMapperConfig);

            Training training = tempMapper.Map<Training>(trainingDTO);

            // compute end date from starting date & number of days training will take + 5 hours assuming each training takes 5 hours
            training.TrainingEndDate = training.TrainingStartDate.AddDays(training.TrainingPeriod).AddHours(5);
            _trainingAcademyRepository.Add(training);
        }

        public void Update(object id, TrainingDTO trainingDTO)
        {
            Training training = _trainingMapper.Map<Training>(trainingDTO);
            _trainingAcademyRepository.Update(training);
        }

        public void Delete(object id)
        {
            _trainingAcademyRepository.Delete(id);
        }
    }
}
