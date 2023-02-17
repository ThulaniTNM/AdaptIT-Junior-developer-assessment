using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Physical_address;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Postal_address;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.User;
using AdaptITAcademy.DataAccess.Repository;
using AdaptITAcademy.DataAccess.Repository.implementation;
using AdaptITAcademy.DataAccess.Repository.@interface;
using AdaptITAcademyAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business_Rules
{
    public class RegisterDelegateService : IRegisterDelegateService
    {
        private IMapper _registerDelegateMapper;
        private IUnitOfWork _registerDelegateRepository;
        private AdaptITAcademyContext _context;

        public RegisterDelegateService(IMapper mapper, IUnitOfWork registerDelegateRepository)
        {
            _registerDelegateMapper = mapper;
            _registerDelegateRepository = registerDelegateRepository;
            _context = registerDelegateRepository.GetContext();
        }

        public AdaptITAcademyContext GetContext()
        {
            return _context;
        }

        public void RegisterDelegate(RegisterDelegateDTO registerDelegateDTO)
        {
            // this is one big transaction involving adding user & relative tables data + registering user for a training.
            // transaction only passes after all operations passes.
            // start transaction directly inside method, not in controller



            UserTraining userTraining = _registerDelegateMapper.Map<UserTraining>(registerDelegateDTO);
            User user = _registerDelegateMapper.Map<User>(registerDelegateDTO);
            PostalAddress postalAddress = _registerDelegateMapper.Map<PostalAddress>(registerDelegateDTO);
            PhysicalAddress physicalAddress = _registerDelegateMapper.Map<PhysicalAddress>(registerDelegateDTO);

            _registerDelegateRepository.Users.Add(user);
            _registerDelegateRepository.CommitDbChanges(); // save to stage changes that might be rolledback.
            User lastEntryUser = _registerDelegateRepository.Users.GetAll().LastOrDefault();

            // assign user id to user relative tables.
            int userId = lastEntryUser.UserId;
            userTraining.UserId = userId;
            physicalAddress.UserId = userId;
            postalAddress.UserId = userId;

            _registerDelegateRepository.UsersTrainings.Add(userTraining);
            _registerDelegateRepository.PhysicalAddresses.Add(physicalAddress);
            _registerDelegateRepository.PostalAddresses.Add(postalAddress);

            // remove one seat after delegate is registered for training.
            int trainingId = registerDelegateDTO.TrainingId;
            Training training = _registerDelegateRepository.Trainings.GetById(trainingId);
            training.AvailableSeats--;
            _registerDelegateRepository.Trainings.Update(training);
            _registerDelegateRepository.CommitDbChanges();
        }
    }
}
