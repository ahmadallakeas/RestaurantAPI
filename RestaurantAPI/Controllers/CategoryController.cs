using Application.DataTransfer;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILogger _logger;

        public CategoryController(IServiceManager serviceManager, ILogger<CategoryController> logger)
        {
            _service = serviceManager;
            _logger = logger;
        }
       // [Authorize]
        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);

            try
            {
                return Ok(categories);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(GetCategoriesAsync)}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _service.CategoryService.GetCategoryByIdAsync(id, trackChanges: false);

            try
            {
                return Ok(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(GetCategoryByIdAsync)}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryForCreationDto categoryForCreation)
        {
            var category = await _service.CategoryService.CreateCategoryAsync(categoryForCreation);
            try
            {
                return CreatedAtRoute("GetCategoryById", new { id = category.CategoryId }, category);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(CreateCategoryAsync)}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            await _service.CategoryService.DeleteCategoryAsync(id, trackChanges: false);
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(DeleteCompanyAsync)}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id:int}", Name = "UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryForUpdateDto categoryForUpdate)
        {
            await _service.CategoryService.UpdateCategoryAsync(id, categoryForUpdate, trackChanges: true);
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(UpdateCategoryAsync)}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
