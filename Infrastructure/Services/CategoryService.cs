using Application.DataTransfer;
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
    internal sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories(bool trackChanges)
        {
            var categories = await _repository.Category.GetAllCategories(trackChanges);
            var result= _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return result;
        }

        public async Task<CategoryDto> GetCategoryById(int id, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryById(id,trackChanges);
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
    }
}
