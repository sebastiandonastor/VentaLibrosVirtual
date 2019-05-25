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
    public class ComprasLibrosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComprasLibrosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprasLibros>>> Get()
        {
            try
            {
                return Ok(await _unitOfWork.ComprasLibros.GetAllAsync());
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
        public async Task<ActionResult<IEnumerable<ComprasLibros>>> Get(int id)
        {
            try
            {
                var compraLibro = await _unitOfWork.ComprasLibros.GetAsync(id);
                if (compraLibro == null) return NotFound($"La compra de libro con el id de {id} no existe");
                return Ok(compraLibro);
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
        public async Task<ActionResult<IEnumerable<ComprasLibros>>> Add([CustomizeValidator(RuleSet = "addComprasLibros")]ComprasLibros comprasLibros)
        {
            try
            {

                await _unitOfWork.ComprasLibros.AddAsync(comprasLibros);
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