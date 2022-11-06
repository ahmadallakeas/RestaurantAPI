using Application.DataTransfer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateTokenAsync();
    }
}
