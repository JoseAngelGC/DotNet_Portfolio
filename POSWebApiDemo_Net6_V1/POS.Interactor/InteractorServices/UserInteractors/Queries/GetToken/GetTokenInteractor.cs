using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.UserInteractor.Hubs;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Queries.GetToken;

namespace POS.Interactor.InteractorServices.UserInteractors.Queries.GetToken
{
    public class GetTokenInteractor : InteractorCreateTokenHelpers, IGetTokenInteractor
    {
        private readonly IUserQueriesUnitOfWork<User> _userQueriesUnitOfWork;
        private readonly IConfiguration _configuration;
        public GetTokenInteractor(IUserQueriesUnitOfWork<User> userQueriesUnitOfWork, IConfiguration configuration)
        {
            _userQueriesUnitOfWork = userQueriesUnitOfWork;
            _configuration = configuration;
        }

        public async Task<InteractorCreateTokenResponseDto> TokenResponseAsync(TokenRequestDto tokenRequestDto)
        {
            try
            {
                var userAccountResponse = await _userQueriesUnitOfWork.AccountByUserName.GetUserAccountAsync(tokenRequestDto.UserName);
                if (userAccountResponse is null)
                {
                    var invalidUserCollectorResponse = await InteractorInvalidUserOrPasswordCollectorAsync();
                    return await InteractorCreateTokenServiceResponseAsync(invalidUserCollectorResponse);
                }

                if (!BC.Verify(tokenRequestDto.Password, userAccountResponse.Password))
                {
                    var invalidPasswordCollectorResponse = await InteractorInvalidUserOrPasswordCollectorAsync();
                    return await InteractorCreateTokenServiceResponseAsync(invalidPasswordCollectorResponse);
                }

                var currentToken = await GenerateTokenAsync(userAccountResponse);
                var currentTokenCollectorResponse = await InteractorTokenSuccessfulCollectorAsync(currentToken);
                return await InteractorCreateTokenServiceResponseAsync(currentTokenCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await InteractorTokenExceptionCollectorAsync(8000, e.HResult, e.Source);
                return await InteractorCreateTokenServiceResponseAsync(exceptionCollectorResponse);
            }


        }

        private async Task<string> GenerateTokenAsync(User userItem)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, userItem.Email!),
                new Claim(JwtRegisteredClaimNames.FamilyName, userItem.UserName!),
                new Claim(JwtRegisteredClaimNames.GivenName, userItem.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, userItem.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(),ClaimValueTypes.Integer64),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                signingCredentials: credentials
                );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
