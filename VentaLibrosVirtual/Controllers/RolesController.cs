using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace VentaLibrosVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManage)
        {
            _roleManager = roleManage;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(JObject data)
        {
            var nombre = data["role"].ToString();
            var exist = await _roleManager.RoleExistsAsync(nombre);
            if(exist) return BadRequest("Estas haciendo una pilleria!");

            var rol = new IdentityRole() { Name = nombre};
            var result = await _roleManager.CreateAsync(rol);
            return Ok(result);
        }

      
    }
}