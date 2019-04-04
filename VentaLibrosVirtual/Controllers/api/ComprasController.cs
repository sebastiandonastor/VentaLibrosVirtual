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
    public class ComprasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComprasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Compra>> Get()
        {
            try
            {
                return Ok(await _unitOfWork.Compras.GetAllAsync());
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
        public async Task<ActionResult<Compra>> Get(int id)
        {
            try

            { 
                var compra = await _unitOfWork.Compras.GetAsync(id);
                if (compra == null) return NotFound($"Id : {id} no encontrada en compra");

                return Ok(compra);
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
        public async Task<ActionResult<Compra>> Add([CustomizeValidator(RuleSet = "addCompra")] Compra compra)
        {
            try

            {
                await _unitOfWork.Compras.AddAsync(compra);
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