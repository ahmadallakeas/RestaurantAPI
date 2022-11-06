using Application.DataTransfer;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
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
        public CategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreation)
        {
            var category = _mapper.Map<Category>(categoryForCreation);
            _repository.Category.CreateCategory(category);
            await _repository.SaveAsync();
            var result = _mapper.Map<CategoryDto>(category);
            return result;

        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _repository.Category.GetAllCategories(trackChanges);
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return result;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryById(categoryId, trackChanges);
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }

        public async Task UpdateCategoryAsync(int categoryId, CategoryForUpdateDto categoryForUpdate, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryById(categoryId, trackChanges);
            _mapper.Map(categoryForUpdate, category);
            await _repository.SaveAsync();

        }
        public async Task DeleteCategoryAsync(int categoryId, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryById(categoryId, trackChanges);
            if (category != null)
            {
                _repository.Category.DeleteCategory(category);
                await _repository.SaveAsync();
            }
        }
    }
}
