using Application.Configurations;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repository, IMapper mapper,UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, mapper));
            _authenticationService=new Lazy<IAuthenticationService>(() => new AuthenticationService(repository, mapper, userManager,configuration));
        }
       
        public ICategoryService CategoryService => _categoryService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
