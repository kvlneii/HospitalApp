using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalApp.Entitites;
using HospitalApp.Models;
using HospitalApp.Models.DTO;
using HospitalApp.SecurityPassword;

namespace HospitalApp.Services
{
    public class AccountDbService : IAccountDbService
    {

        private readonly IConfiguration _configuration;
        private readonly HospitalDbContext _hospitalDbContext;

        public AccountDbService(IConfiguration configuration, HospitalDbContext context)
        {
            this. _configuration = configuration;
            this._hospitalDbContext = context;
        }


        public async Task<LoginDTO> LoginAsync(UserDTO userDTO)
        {
            var user = await _hospitalDbContext.Users.FirstOrDefaultAsync(e => e.Login == userDTO.Login);
            if (user == null) 
            {
                return new LoginDTO { StatusResponse = StatusResponse.UserNotFound};
            }

            if (user.Password != PasswordSecurity.GetHashedSaltedPassword(userDTO.Password, user.Salt))
            {
                return new LoginDTO { StatusResponse = StatusResponse.BadPassword };
            }

            var token = GenerateToken();
            user.RefreshToken = Guid.NewGuid().ToString();
            user.RerfreshTokenExpiration = DateTime.Now.AddHours(12);
            await _hospitalDbContext.SaveChangesAsync();

            return new LoginDTO { StatusResponse = StatusResponse.OK, AccessToken = new JwtSecurityTokenHandler().WriteToken(token).ToString(), RefreshToken = user.RefreshToken };

        }

        private JwtSecurityToken GenerateToken()
        {

            Claim[] claims =
            {
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Klient"),
                new Claim(ClaimTypes.Role, "User")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials

            );

            return token;
        }


        public async Task<LoginDTO> RefreshTokenAsync(string refreshToken)
        {
            var user = await _hospitalDbContext.Users.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken);
            if (user == null)
            {
                return new LoginDTO { StatusResponse = StatusResponse.UserNotFound };
            }

            if (user.RerfreshTokenExpiration < DateTime.Now)
            {
                return new LoginDTO { StatusResponse = StatusResponse.RefreshTokenIsExpired };
            }

            var token = GenerateToken();
            user.RefreshToken = Guid.NewGuid().ToString();
            user.RerfreshTokenExpiration = DateTime.Now.AddHours(10);
            await _hospitalDbContext.SaveChangesAsync();

            return new LoginDTO { StatusResponse = StatusResponse.OK, AccessToken = new JwtSecurityTokenHandler().WriteToken(token).ToString(), RefreshToken = user.RefreshToken };

        }

        public async Task<LoginDTO> SignUpAsync(UserDTO userDTO)
        {
            var user = await _hospitalDbContext.Users.FirstOrDefaultAsync(e => e.Login == userDTO.Login);
            if (user != null)
            {
                return new LoginDTO { StatusResponse = StatusResponse.UserIsAlreadyRegistered };
            }

            var passwordAndSalt = PasswordSecurity.GetHashedPasswordAndSalt(userDTO.Password);

            User newUser = new User
            {
                Login = userDTO.Login,
                Password = passwordAndSalt.Item1,
                Salt = passwordAndSalt.Item2,
                RefreshToken = Guid.NewGuid().ToString(),
                RerfreshTokenExpiration = DateTime.Now.AddHours(10)
            };

            await _hospitalDbContext.Users.AddAsync(newUser);
            await _hospitalDbContext.SaveChangesAsync();

            return new LoginDTO { StatusResponse = StatusResponse.OK};

        }
    }
}
