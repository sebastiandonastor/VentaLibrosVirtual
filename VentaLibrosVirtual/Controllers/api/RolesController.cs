using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using FluentValidation.AspNetCore;
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
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManage)
        {
            _roleManager = roleManage;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post([CustomizeValidator(RuleSet = "addRole")]ApplicationRole role)
        {


            var nombre = role.Name;
           
            var exist = await _roleManager.RoleExistsAsync(nombre);
            if(exist) return BadRequest("Estas haciendo una pilleria!");

           
            var result = await _roleManager.CreateAsync(role);
            return Ok(result);
        }

      
    }
}