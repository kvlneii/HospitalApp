using Microsoft.AspNetCore.Mvc;
using HospitalApp.Models.DTO;

namespace HospitalApp.Services
{
    public interface IAccountDbService
    {
        Task<LoginDTO> LoginAsync(UserDTO userDTO);
        Task<LoginDTO> RefreshTokenAsync(string refreshToken);
        Task<LoginDTO> SignUpAsync(UserDTO userDTO);
    }
}
