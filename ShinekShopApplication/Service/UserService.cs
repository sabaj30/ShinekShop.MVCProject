using ShinekShopInfrastructure.DTOs.Account;
using ShinekShopInfrastructure.Enums;
using ShinekShopInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository
        public Task<bool> CheckUser()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EdditUserInformationDTO> EditUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task EditUserDetail(EdditUserInformationDTO edditUserInformationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterOrLoginResult> RegisterOrLogin(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterOrLoginResult> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SenSMS(string mobileNumber)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailDTO> UserDetail(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
