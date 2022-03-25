using CarParts.Domain.Entities;
using CarParts.Infrastructure.Tools;
using CarsParts.Application.Enums;
using CarsParts.Application.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;

namespace CarParts.Api.Controllers
{
    [EnableCors]
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

                user.Username = data?.Username;
                var role = await _repository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId);
                //user.AppRole=data?.AppRole;
                //Burada bir sıkıntı var agalarım
                var token = JwtTokenGenerator.GenerateToken(data, data.AppRole);

                return Created(string.Empty, token);
            }
            else
            {
                return NotFound();
            }
      
        }

    }
}
