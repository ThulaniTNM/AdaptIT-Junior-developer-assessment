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
    public class RegisterDelegateRules : IRegisterDelegateRules
    {
        private AdaptItAcademyRepository<UserTraining> _delegateTrainingRegistrationAcademyRepository;
        private AdaptItAcademyRepository<User> _userAcademyRepository;
        private AdaptItAcademyRepository<PhysicalAddress> _physicalAddressAcademyRepository;
        private AdaptItAcademyRepository<PostalAddress> _postalAddressAcademyRepository;
        private AdaptItAcademyRepository<Training> _trainingAcademyRepository;

        private Mapper _userTrainingMapper;
        private Mapper _userMapper;
        private Mapper _physicalAddressMapper;
        private Mapper _postalAddressMapper;

        public RegisterDelegateRules()
        {
            _delegateTrainingRegistrationAcademyRepository = new AdaptItAcademyRepository<UserTraining>();
            _userAcademyRepository = new AdaptItAcademyRepository<User>();
            _physicalAddressAcademyRepository = new AdaptItAcademyRepository<PhysicalAddress>();
            _postalAddressAcademyRepository = new AdaptItAcademyRepository<PostalAddress>();
            _trainingAcademyRepository = new AdaptItAcademyRepository<Training>();

            _userTrainingMapper = new Mapper(new MapperConfiguration(config => config.CreateMap<RegisterDelegateDTO, UserTraining>().ReverseMap()));
            _userMapper = new Mapper(new MapperConfiguration(config => config.CreateMap<RegisterDelegateDTO, User>().ReverseMap()));
            _physicalAddressMapper = new Mapper(new MapperConfiguration(config => config.CreateMap<RegisterDelegateDTO, PhysicalAddress>().ReverseMap()));
            _postalAddressMapper = new Mapper(new MapperConfiguration(config => config.CreateMap<RegisterDelegateDTO, PostalAddress>().ReverseMap()));
        }

        public void RegisterDelegate(RegisterDelegateDTO registerDelegateDTO)
        {
            // we saving a lot of entities here and will need a lot of extraction.
            UserTraining userTraining = _userTrainingMapper.Map<RegisterDelegateDTO, UserTraining>(registerDelegateDTO);
            User user = _userMapper.Map<RegisterDelegateDTO, User>(registerDelegateDTO);
            PostalAddress postalAddress = _postalAddressMapper.Map<RegisterDelegateDTO, PostalAddress>(registerDelegateDTO);
            PhysicalAddress physicalAddress = _physicalAddressMapper.Map<RegisterDelegateDTO, PhysicalAddress>(registerDelegateDTO);



            _userAcademyRepository.Add(user);

            // assign user id to their postal & physical address table.
            int userId = user.UserId;
            userTraining.UserId = userId;
            physicalAddress.UserId = userId;
            postalAddress.UserId = userId;

            _delegateTrainingRegistrationAcademyRepository.Add(userTraining);
            _physicalAddressAcademyRepository.Add(physicalAddress);
            _postalAddressAcademyRepository.Add(postalAddress);

            // remove one seat after delegate is registered for training.
            int trainingId = registerDelegateDTO.TrainingId;
            Training training = _trainingAcademyRepository.GetById(trainingId);
            training.AvailableSeats--;
            _trainingAcademyRepository.Update(training);
        }
    }
}
