using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Service.CategoryService;
using RepositoryDP.Validation;

namespace RepositoryDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [Authorize]
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory ([FromForm] CreateCategoryDTO dto)
        {
            //CategoryValidator validations = new CategoryValidator();
            //var res = validations.Validate(dto);
            //if (!res.IsValid)
            //{
            //    foreach (var item in res.Errors)
            //    {
            //        return BadRequest(item);
            //    }
            //}

            var cat = categoryService.CreateCategory(dto);
            return Ok(cat);
        }

        [Authorize]
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory([FromQuery] int id , UpdateCategoryDTO dTO)
        {
            var cat = categoryService.UpdateCategory(id, dTO);
            return Ok(cat);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory()
        {
            var res= categoryService.GetCategories();
            return Ok(res);
        }

        [Authorize]
        [HttpDelete("DeleteCategory{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var res = categoryService.DeleteCategory(id);
            return Ok(res);
        }
    }
}
