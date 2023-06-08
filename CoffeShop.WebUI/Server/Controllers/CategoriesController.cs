using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.WebUI.Server.Data.Entities;
using CoffeShop.WebUI.Server.Infrastructure.Abstract;
using CoffeShop.WebUI.Shared.Commands;
using CoffeShop.WebUI.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IRepository _repository;
        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Categories
        [HttpGet]
        public async IAsyncEnumerable<CategoryDto> GetAsync()
        {
            var items = _repository.Categories
                .Select(x => new CategoryDto() { Id = x.Id, CategoryName = x.CategoryName })
                .OrderBy(x => x.Id)
                .AsAsyncEnumerable();

            await foreach (var item in items)
            {
                yield return item;
            }
        }

        // GET api/Categories/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var item = await _repository.Categories
                .Where(x => x.Id == id)
                .Select(x => new CategoryDto() { Id = x.Id, CategoryName = x.CategoryName })
                .FirstOrDefaultAsync();

            return item == null ? NotFound() : Ok(item);
        }

        // POST api/Categories
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var category = new Category()
            {
                CategoryName = command.CategoryName.Trim()
            };

            _repository.Add(category);

            var result = await _repository.SaveEntitiesAsync();

            if (result)
            {
                return new ObjectResult(category) { StatusCode = StatusCodes.Status201Created };
            }

            return BadRequest();
        }

        // PUT api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            var category = await _repository.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(category is null)
            {
                return NotFound();
            }

            category.CategoryName = command.CategoryName.Trim();

            _repository.Update(category);

            var result = await _repository.SaveEntitiesAsync();

            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _repository.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null)
            {
                return NotFound();
            }

            var isExistProduct = await _repository.Products.AnyAsync(x => x.CategoryId == id);

            if (isExistProduct)
            {
                return BadRequest(new { message = "Before deleting the category, please remove all of its products" });
            }

            _repository.Delete(category);

            var result = await _repository.SaveEntitiesAsync();

            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}

