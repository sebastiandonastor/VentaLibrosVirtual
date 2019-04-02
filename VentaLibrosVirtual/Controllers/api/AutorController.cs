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
    public class AutorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get()
        {
            try
            {
                return Ok(await _unitOfWork.Autores.GetAllAsync());
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
        public async Task<ActionResult> Post([CustomizeValidator(RuleSet = "addAutor")] Autor autor)
        {
            try
            {


                await _unitOfWork.Autores.AddAsync(autor);
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