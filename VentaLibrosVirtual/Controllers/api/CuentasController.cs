﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using FluentValidation.AspNetCore;
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
        [Route("AllRoles")]
        public async Task<ActionResult> GetRoles()
        {
            try
            {
                var usuarios = await _userManager.Users.Include(s => s.UserRoles).ThenInclude(ur => ur.Roles).ToListAsync();

                return Ok(usuarios
                    .Select(s => new { s.UserName, s.Nombres, s.Apellidos, s.Id, s.Email, Roles = s.UserRoles
                    .Select(u => new { u.Roles.Name, u.RoleId}) }));
            }
            catch (Exception err)
            {

                return BadRequest(err);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
              
                var usuarios = await _userManager.Users.ToListAsync();
                return Ok(usuarios.Select(u => new { u.Nombres, u.Apellidos, u.Email, u.UserName, u.Id }));
            }
            catch (Exception err)
            {
           
                return BadRequest(err);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost("crear")]
        public async Task<ActionResult<UserToken>> CrearUsuario([FromBody] RegisterInfo model)
        {
            try
            {
             
            var usuario = new ApplicationUser() { UserName = model.Username, Email = model.Email, Apellidos = model.Apellidos, Nombres = model.Nombres };
            var result = await _userManager.CreateAsync(usuario, model.Password);
            if(result.Succeeded)
            {
                return await BuildToken(usuario);
            } else
            {
                return StatusCode(500,result.Errors);
            }

            }
            catch (Exception err)
            {

                return BadRequest(err);
            }
       
        }

        [HttpPost("logear")]
        public async Task<ActionResult<UserToken>> LogearUsuario([CustomizeValidator(RuleSet = "Logear")][FromBody] UserInfo model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                return await BuildToken(user);
            } else
            {
                return BadRequest("Usuario o contrasena incorrecta");
            }
        }

        [Authorize]
        [HttpGet("Me")]
        public async Task<ActionResult> Me()
        {
            try
            {
               
               var userName = User.Identity.Name;
     
                var user = await _userManager.FindByNameAsync(userName);
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
                 new Claim(ClaimTypes.Name,model.UserName),
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

        [Authorize(Roles = "admin")]
        [HttpPost("AddUserToRole")]
        public async Task<ActionResult> AddUserToRole(JObject data)
        {

            try
            {
                var nombre = data["role"].ToString();
                var usuario = data["usuario"].ToString();
                var user = await _userManager.FindByNameAsync(usuario);
                if (user == null) return NotFound($"Usuario con el nombre: {usuario} no existe");
                var result = await _userManager.AddToRoleAsync(user, nombre);
                return Ok(result);
            }
            catch (Exception err)
            {
                return StatusCode(500, err);
              
            }
        ;
            


         
        }

        
    }
}