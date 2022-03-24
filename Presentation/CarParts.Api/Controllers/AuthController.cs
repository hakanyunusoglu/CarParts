using CarParts.Domain.Entities;
using CarsParts.Application.Enums;
using CarsParts.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<AppUser> _repository;

        public AuthController(IRepository<AppUser> repository)
        {
            _repository = repository;
        }
       [HttpPost("[action]")]
       public  async Task<IActionResult> Register(AppUser user)
        {
         var data=  _repository.CreateAsync(new AppUser
            {
                AppRoleId = (int)RoleType.User,
               
            });
            return Created(string.Empty,data);

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppUser user)
        {
            var data = await _repository.GetByFilterAsync(x => x.Username == user.Username);
            if (data != null)
            {
                user.Email = data?.Email;
                var role = await _repository.GetByFilterAsync(x => x.Email == data.Email);    
                return Created(string.Empty, user);
            }
            else
            {
                return NotFound();
            }
      
        }

    }
}
