using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace VentaLibrosVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public CuentasController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _userManager.Users.ToListAsync());
            }
            catch (Exception err)
            {
           
                return BadRequest(err);
            }
        }
        
        [HttpPost("crear")]
        public async Task<ActionResult<UserToken>> CrearUsuario([FromBody] UserInfo model)
        {
            try
            {
                     var usuario = new ApplicationUser() { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(usuario, model.Password);
            if(result.Succeeded)
            {
                return await BuildToken(usuario);
            } else
            {
                return BadRequest(result.Errors);
            }

            }
            catch (Exception err)
            {

                return BadRequest(err);
            }
       
        }

        [HttpPost("logear")]
        public async Task<ActionResult<UserToken>> LogearUsuario([FromBody] UserInfo model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                return await BuildToken(user);
            } else
            {
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpGet("Me")]
        public async Task<ActionResult> Me()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new { Usuario = new { user.Id,user.Email }, Roles = roles });
            }
            catch (Exception err)
            {

                return BadRequest(err);
            }
        }

        private async Task<UserToken> BuildToken(ApplicationUser model)
        {
            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Sub, model.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Name,model.Email),
                new Claim(ClaimTypes.NameIdentifier,model.Id)
                    };

             var roles = await _userManager.GetRolesAsync(model);
              claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:secret"]));
            var creds = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                signingCredentials: creds,
                expires: expiration
                );

            
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expire = expiration
            };

        }


          [HttpPost("AddUserToRole")]
        public async Task<ActionResult> AddUserToRole(JObject data)
        {
            var nombre = data["role"].ToString();
            var id = data["id"].ToString();
            


            var user = await _userManager.FindByIdAsync(id);
            if(user == null) return NotFound($"Usuario con el id: {id} no existe");
            var result = await _userManager.AddToRoleAsync(user,nombre);
            return Ok(result);
        }
    }
}