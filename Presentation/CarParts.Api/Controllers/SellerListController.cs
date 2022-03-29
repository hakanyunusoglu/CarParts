using CarParts.Domain.Entities;
using CarsParts.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq.Expressions;

namespace CarParts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerListController : ControllerBase
    {
        private readonly IRepository<SellerList> _repository;


        public SellerListController(IRepository<SellerList> repository)
        {
            _repository = repository;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Filter(Guid id)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id==id);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SellerList sellerList)
        {
            var addSeller = _repository.CreateAsync(sellerList);
            return Created(string.Empty, addSeller);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(SellerList sellerList)
        {
            var updateSeller = await _repository.GetByIdAsync(sellerList.Id);
            if (updateSeller == null)
            {
                return NotFound();
            }
            await _repository.UpdateAsync(updateSeller);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteSellerList = await _repository.GetByIdAsync(id);
            if (deleteSellerList == null)
            {
                return NotFound();
            }
            await _repository.RemoveAsync(deleteSellerList);
            return NoContent();
        }
    }
}
