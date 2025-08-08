using ShinekShopInfrastructure.DTOs.Account;
using ShinekShopInfrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopApplication.Service
{
    public interface IUserService : IAsyncDisposable
    {
        Task<RegisterOrLoginResult> RegisterOrLogin(RegisterUserDTO registerUserDTO);
        Task<bool> CheckUser();
        Task<EdditUserInformationDTO> EditUser(long id);
        Task EditUserDetail(EdditUserInformationDTO edditUserInformationDTO);
        Task<UserDetailDTO> UserDetail(int userId);
        Task<bool> SenSMS(string mobileNumber);

    }
}
