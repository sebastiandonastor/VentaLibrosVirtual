using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Entities.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VentaLibrosVirtual.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenerosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            try
            {
                return Ok(await _unitOfWork.Generos.GetAllAsync());
            }
            catch (Exception err)
            {

                return StatusCode(500, err);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            try
            {
                var genero = await _unitOfWork.Generos.GetAsync(id);

                if(genero == null) return NotFound($"El genero con el id: {id} no existe");

                return Ok(genero);
            }
            catch (Exception err)
            {

                return StatusCode(500, err);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

          
        [HttpPost]
        public async Task<ActionResult> Add([CustomizeValidator(RuleSet = "addGenero")] Genero genero)
        {
            try
            {

                await _unitOfWork.Generos.AddAsync(genero);
                return Ok(await _unitOfWork.CompleteAsync());
            }
            catch (Exception err)
            {

                return StatusCode(500, err);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

    }
}