using AutoMapper;
using EzjobApi.Core.Contracts;
using EzjobApi.DTOs;
using EzjobApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CliverApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthController(ILogger<AuthController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            var user = await _unitOfWork.Users.FindUserByEmailAndPassword(loginUser.Email, loginUser.Password);

            if (user == null)
            {
                //throw new HttpResponseException("Not found", 404);
                return NotFound(
                    new HttpResponseException("Email or password is wrong")
                    { StatusCode = 404 })
                    ;
            }

            string token = _unitOfWork.Auth.GenerateToken(user);
            UserDto userDto = _mapper.Map<UserDto>(user);

            return Ok(new
            {
                data = userDto,
                token = token
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            var item = await _unitOfWork.Users.FindByEmail(user.Email);

            if (item != null)
            {

                return BadRequest(new HttpResponseException("Email have already existed!!!")
                {
                    StatusCode = 400
                });
            };

            User newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            await _unitOfWork.Users.Add(newUser);
            await _unitOfWork.CompleteAsync();

            UserDto returnUser = _mapper.Map<UserDto>(newUser);

            return new CreatedResult("data", new
            {
                data = returnUser
            });
        }
    }
}