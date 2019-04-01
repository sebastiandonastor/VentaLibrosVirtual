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
    public class LibrosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibrosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> Get()
        {
            try
            {
                return Ok(await _unitOfWork.Libros.GetAllAsync());
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
        public async Task<ActionResult> Post([CustomizeValidator(RuleSet = "addLibro")] Libro libro)
        {
            try
            {


                await _unitOfWork.Libros.AddAsync(libro);
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