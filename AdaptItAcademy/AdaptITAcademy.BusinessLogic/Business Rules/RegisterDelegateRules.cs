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

        private IMapper _registerDelegateMapper;

        public RegisterDelegateRules(IMapper mapper)
        {
            _delegateTrainingRegistrationAcademyRepository = new AdaptItAcademyRepository<UserTraining>();
            _userAcademyRepository = new AdaptItAcademyRepository<User>();
            _physicalAddressAcademyRepository = new AdaptItAcademyRepository<PhysicalAddress>();
            _postalAddressAcademyRepository = new AdaptItAcademyRepository<PostalAddress>();
            _trainingAcademyRepository = new AdaptItAcademyRepository<Training>();

            _registerDelegateMapper = mapper;
        }

        public void RegisterDelegate(RegisterDelegateDTO registerDelegateDTO)
        {
            // extract data for all entities of interest.
            UserTraining userTraining = _registerDelegateMapper.Map<UserTraining>(registerDelegateDTO);
            User user = _registerDelegateMapper.Map<User>(registerDelegateDTO);
            PostalAddress postalAddress = _registerDelegateMapper.Map<PostalAddress>(registerDelegateDTO);
            PhysicalAddress physicalAddress = _registerDelegateMapper.Map<PhysicalAddress>(registerDelegateDTO);

            _userAcademyRepository.Add(user);

            // assign user id to user relative tables.
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
