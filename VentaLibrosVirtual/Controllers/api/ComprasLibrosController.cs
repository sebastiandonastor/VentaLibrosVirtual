using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
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
    }
}