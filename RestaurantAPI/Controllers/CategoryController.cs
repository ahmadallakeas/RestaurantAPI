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
        [Authorize]
        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _service.CategoryService.GetAllCategories(trackChanges: false);

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
        [HttpGet("{id:int}",Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _service.CategoryService.GetCategoryById(id,trackChanges: false);

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
    }
}
