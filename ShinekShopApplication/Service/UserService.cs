using ShinekShopInfrastructure.DTOs.Account;
using ShinekShopInfrastructure.Entities.Account;
using ShinekShopInfrastructure.Enums;
using ShinekShopInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async ValueTask DisposeAsync()
        {
            await _userRepository.DisposeAsync();
        }
        public async Task<RegisterOrLoginResult> RegisterOrLogin(RegisterUserDTO registerUserDTO)
        {
            var checkUser = await CheckUser(registerUserDTO.PhoneNumber);

            if (checkUser)
            {
                var user = await _userRepository.GetAll().FirstAsync(u => u.PhoneNumber == registerUserDTO.PhoneNumber);
                _userRepository.EditEntity(user);
                await _userRepository.SaveChangeRepo();
                return RegisterOrLoginResult.MobileIsUse;
            }
            else
                return RegisterOrLoginResult.Success;

            //بعدا باید درستش کنم

        }

        public async Task<bool> CheckUser(string mobile)
        {
            return await _userRepository.GetAll().AnyAsync(x => x.PhoneNumber == mobile);
        }

        public async Task EditUserDetail(EdditUserInformationDTO edditUserInformationDTO)
        {
            var user = await _userRepository.GetEntityById(edditUserInformationDTO.UserId);
            user.FullName = edditUserInformationDTO.FullName;
            user.EmailAddress = edditUserInformationDTO.EmailAddress;
            user.Address = edditUserInformationDTO.Address;
            user.PhoneNumber = edditUserInformationDTO.PhoneNumber;
            user.PostCode = edditUserInformationDTO.PostCode;

            _userRepository.EditEntity(user);
            await _userRepository.SaveChangeRepo();
        }

        public async Task<EdditUserInformationDTO> GetEditUser(int id)
        {
            var user = await _userRepository.GetEntityById(id);
            return new EdditUserInformationDTO
            {
                UserId = id,
                FullName = user.FullName,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                PostCode = user.PostCode,
                Address = user.Address
            };
        }


        public Task<bool> SenSMS(string mobileNumber)
        {
            throw new NotImplementedException();
            // fix later
        }

        public async Task<UserDetailDTO> UserDetail(int userId)
        {
            var user = await _userRepository.GetEntityById(userId);
            return new UserDetailDTO
            {
                Id = userId,
                FullName = user.FullName,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                PostCode = user.PostCode,
                Address = user.Address,
                CreateDate = user.CreateDate,
                LastUpdateDate = user.LastUpdateDate,
                
            };
        }
    }
}
