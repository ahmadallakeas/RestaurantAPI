using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, mapper));
        }
       
        public ICategoryService CategoryService => _categoryService.Value;
    }
}
