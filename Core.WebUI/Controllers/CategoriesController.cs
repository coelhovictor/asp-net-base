using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Core.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryService.GetByIdAsync(id);
            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }
    
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _categoryService.UpdateAsync(categoryDTO);
                } catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryService.GetByIdAsync(id);
            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Delete), id);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryService.GetByIdAsync(id);
            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }
    }
}
