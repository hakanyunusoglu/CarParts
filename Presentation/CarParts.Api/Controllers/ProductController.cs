using AutoMapper;
using CarParts.Domain.Entities;
using CarsParts.Application.Dto;
using CarsParts.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }
        [HttpPost]
        public  async Task<IActionResult> Create(Product model)
        {

                var data = _repository.CreateAsync(model);
                return Created("",data);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(Product model)
        {
           if(_repository.GetByIdAsync(model.Id)!= null)
            {
                 _repository.UpdateAsync(model);
                return Ok();
                //asdadadadadada
            }
            return BadRequest(ModelState);
        }
    }
}
