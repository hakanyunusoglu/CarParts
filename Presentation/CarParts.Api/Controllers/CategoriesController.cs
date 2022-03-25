using CarParts.Domain.Entities;
using CarsParts.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
      

        public CategoriesController(IRepository<Category> repository)
        {
            _repository = repository;
            
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var addCategory= _repository.CreateAsync(category);
            return Created(string.Empty, addCategory);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(Category category)
        {
            var updateCategory=await _repository.GetByIdAsync(category.Id);
            if (updateCategory == null)
            {
                return NotFound();
            }
            await _repository.UpdateAsync(updateCategory);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCategory = await _repository.GetByIdAsync(id);
            if(deleteCategory == null)
            {
                return NotFound();
            }
            await _repository.RemoveAsync(deleteCategory);
            return NoContent();
        }
        
    }
}
