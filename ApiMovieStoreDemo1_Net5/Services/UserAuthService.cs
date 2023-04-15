using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Dtos.UserAuthDtos;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserAuthRepository _iuaRepo;
        private readonly ICommonServiceHelpers _icsh;
        private readonly IMapper _imapper;
        private readonly IConfiguration _iconfig;
        public UserAuthService(IUserAuthRepository iuserAuthRepository, ICommonServiceHelpers iCommonServiceHelpers, IMapper imapper, IConfiguration iconfiguration)
        {
            _iuaRepo = iuserAuthRepository;
            _icsh = iCommonServiceHelpers;
            _imapper = imapper;
            _iconfig = iconfiguration;
        }

        public async Task<CommonServiceResponse> GetUsersAuthService()
        {
            try
            {
                var usersAuthListDto = new List<UserAuthDto>();
                var getUsersAuthListResponse = await _iuaRepo.GetUsersAuth();
                if (getUsersAuthListResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getUsersAuthListResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R700E!");
                }

                if (getUsersAuthListResponse.UsersAuthRepositoryResponse.Count == 0)
                {
                    return _icsh.CommonServiceResponseHelper(getUsersAuthListResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                foreach (var lista in getUsersAuthListResponse.UsersAuthRepositoryResponse)
                {
                    usersAuthListDto.Add(_imapper.Map<UserAuthDto>(lista));
                }

                return _icsh.CommonServiceResponseHelper(1, "Listado de usuarios!", usersAuthListDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S700E!");
            }
        }

        public async Task<CommonServiceResponse> UserAuthLogin(UserAuthLoginDto userAuthLoginDto)
        {
            try
            {
                //Get User data 
                var getUserAuthResponse = await _iuaRepo.GetUserAuthByAlias(userAuthLoginDto.UserAlias);
                if (getUserAuthResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getUserAuthResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo REUA707E!");
                }

                if (getUserAuthResponse.UserAuthDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(getUserAuthResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                if (!VerificPasswordHash(userAuthLoginDto.Password, getUserAuthResponse.UserAuthDataRepositoryResponse.PasswordHash, getUserAuthResponse.UserAuthDataRepositoryResponse.PasswordSalt))
                {
                    return _icsh.CommonServiceResponseHelper(getUserAuthResponse.OperationCodeRepositoryResponse, "BadCredentials");
                }

                var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,getUserAuthResponse.UserAuthDataRepositoryResponse.Id.ToString()),
                        new Claim(ClaimTypes.Name,getUserAuthResponse.UserAuthDataRepositoryResponse.AliasUser.ToString())
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfig.GetSection("AppSettings:Token").Value));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return _icsh.CommonServiceResponseHelper(1, "Login exitoso!", new { token = tokenHandler.WriteToken(token) });
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S707E!");
            }
        }

        public async Task<CommonServiceResponse> UserAuthRegister(UserAuthRegisterDto userAuthRegisterDto)
        {
            try
            {
                //Validate if exist the new user
                var existUserAuthResponse = await _iuaRepo.ExistUserAuth(userAuthRegisterDto.UserAlias);
                if (existUserAuthResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(existUserAuthResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo REC702E!");
                }

                if (existUserAuthResponse.OperationCodeRepositoryResponse == 1 && existUserAuthResponse.ExistUserAuthRepoResponse == true)
                {
                    return _icsh.CommonServiceResponseHelper(existUserAuthResponse.OperationCodeRepositoryResponse, "Exist");
                }

                //Using the password user its will create passwordHash and passwordSalt
                CrearPasswordHash(userAuthRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                //Mapping from userAuthRegisterDto model to UserAuth model
                var userAuthModelMapper = _imapper.Map<UserAuth>(userAuthRegisterDto);

                //Passing or adding the other values from UserAuth model
                userAuthModelMapper.PasswordHash = passwordHash;
                userAuthModelMapper.PasswordSalt = passwordSalt;
                userAuthModelMapper.CreatedDate = DateTime.Now;
                userAuthModelMapper.UpdateDate = DateTime.Now;

                //Register UserAuth section
                var registerUserAuthResponse = await _iuaRepo.RegisterUserAuth(userAuthModelMapper);
                if (registerUserAuthResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(registerUserAuthResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R702E!");
                }

                return _icsh.CommonServiceResponseHelper(1, "Se registro de manera exitosa el usuario!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S702E!");
            }
        }

        private static void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerificPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hashComputed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < hashComputed.Length; i++)
                {
                    if (hashComputed[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }
    }
}
