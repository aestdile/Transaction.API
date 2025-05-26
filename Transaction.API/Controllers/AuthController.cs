using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Transaction.API.DataAccess.Entities;
using Transaction.API.Models;

namespace Transaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var foundUser = await _userManager.FindByNameAsync(model.UserName);

            if (foundUser != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseModel
                    {
                        Status = "Error",
                        Message = "User already exists."
                    });
            }

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseModel
                    {
                        Status = "Error",
                        Message = "User creation failed. Please check user details and try again."
                    });
            }

            return Ok(new ResponseModel
            {
                Status = "Success",
                Message = "User created successfully."
            });
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var foundUser =
                await _userManager.FindByNameAsync(
                    loginModel.UserName);

            if (foundUser != null
                && await _userManager.CheckPasswordAsync(foundUser, loginModel.Password))
            {
                var roles = await _userManager.GetRolesAsync(foundUser);

                List<Claim> claims = new List<Claim>();
                Claim claim1 =
                    new Claim(ClaimTypes.Name, foundUser.UserName);

                Claim claim2 =
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString());

                claims.Add(claim1);
                claims.Add(claim2);

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var symmetricSecurityKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        _configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    _configuration["JWT:ValidIssuer"],
                    _configuration["JWT:ValidAudience"],
                    claims, expires: DateTime.Now.AddHours(1),

                    signingCredentials:
                    new SigningCredentials(symmetricSecurityKey,
                    SecurityAlgorithms.HmacSha256));

                return Ok(new
                {
                    token =
                    new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized(new ResponseModel
            {
                Status = "Error",
                Message = "Invalid username or password."
            });
        }
    }
}
