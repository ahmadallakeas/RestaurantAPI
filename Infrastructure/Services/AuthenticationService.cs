using Application.Configurations;
using Application.DataTransfer;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _manager;
        private readonly JwtConfiguration _jwtConfiguration;
        private User? _user;

        public AuthenticationService(IRepositoryManager repository, IMapper mapper, UserManager<User> manager, IOptions<JwtConfiguration> configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _manager = manager;
            _jwtConfiguration = configuration.Value;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _manager.CreateAsync(user, userForRegistration.Password);
            if (result.Succeeded)
            {
                await _manager.AddToRolesAsync(user, userForRegistration.Roles);
            }
            return result;
        }
        public async Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuthentication)
        {
            _user = await _manager.FindByNameAsync(userForAuthentication.UserName);
            return (_user != null && await _manager.CheckPasswordAsync(_user, userForAuthentication.Password));
        }
        public async Task<TokenDto> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken);

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
                (
                    issuer: _jwtConfiguration.ValidIssuer,
                    claims: claims,
                    audience: _jwtConfiguration.ValidAudience,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
                    signingCredentials: signingCredentials
                );
            return tokenOptions;
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("KEY"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _manager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
