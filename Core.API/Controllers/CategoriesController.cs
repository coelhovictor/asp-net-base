using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if(categories == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDTO = await _categoryService.GetByIdAsync(id);
            if(categoryDTO == null)
            {
                return NotFound("Category not found");
            }
            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if(categoryDTO == null)
            {
                return BadRequest("Invalid data");
            }
            await _categoryService.AddAsync(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.Id)
            {
                return BadRequest();
            }
            if(categoryDTO == null)
            {
                return BadRequest();
            }
            await _categoryService.UpdateAsync(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDTO = await _categoryService.GetByIdAsync(id);
            if(categoryDTO == null)
            {
                return NotFound("Category not found");
            }
            await _categoryService.RemoveAsync(id);
            return Ok(categoryDTO);
        }
    }
}
