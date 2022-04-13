using AutoMapper;
using CarParts.Domain.Entities;
using CarParts.Infrastructure.Tools;
using CarsParts.Application.Dto;
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
        private readonly IRepository<AppRole> _repositorys;
        private readonly IMapper _mapper;



        public AuthController(IRepository<AppUser> repository, IRepository<AppRole> repositorys, IMapper mapper)
        {
            _repository = repository;
            _repositorys = repositorys;
            _mapper = mapper;
        }


        public List<CarsParts.Application.Dto.AppUserDto> AppUserDto { get; private set; }

     
        [HttpPost("[action]")]
       public  async Task<IActionResult> Register(AppUser user)
        {
         var data= _repository.CreateAsync(new AppUser
         {
                AppRoleId = (int)RoleType.User,
               
            });
            return Created(string.Empty,data);

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);



        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppUser user)
        {
            var data = await _repository.GetByFilterAsync(x => x.Username == user.Username);
            if (data != null)
            {
                if (data.Password==user.Password)
                {
                    user.Username = data?.Username;
                    var role = await _repositorys.GetByFilterAsync(x => x.ID == data.AppRoleId);


                    user.AppRole.ID = (int)data?.AppRoleId;

                    //Burada bir sıkıntı var agalarım
                    var token = JwtTokenGenerator.GenerateToken(data, role);

                    return Created(string.Empty, token);
                }
                return NotFound();

            }
            else
            {
                return NotFound();
            }
      
        }

    }
}
