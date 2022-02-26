using API.Dtos;
using API.Exceptions;
using API.Extensions;
using API.Services;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalInformationsController : BaseController
    {
        private readonly IMedicalInformationService _medicalInfoService;
        private readonly IBaseService<Account> _acountService;

        public MedicalInformationsController(
            IMedicalInformationService medicalInfoService,
            IBaseService<Account> accountService
            )
        {
            _medicalInfoService = medicalInfoService;
            _acountService = accountService;
        }

        [HttpPost()]
        public async Task<ActionResult<MedicalInformation>> AddAsync(MedicalInformation model)
        {
            // logica de validare (ce nu se poate verifica prin adnotarile din DTO) ...
            // ...

            // logica metodei
            var med = await _medicalInfoService.AddAsync(new MedicalInformation() { Title = model.Title, Description = DateTime.Now.ToString() });
          
            // returnare 400, daca serviciul a returnat null
            if(med == null)
            {
                return BadRequest((new ApiErrorResponse<object>(400)).Serialize());
            }

            // return 200 si entitatea
            return Ok(med.Serialize());
        }

        [HttpGet()]
        public async Task<ActionResult<IList<MedicalInformation>>> GetListAsync()
        {
            return Ok(await _medicalInfoService.GetListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<MedicalInformation>>> FindAsync(long id)
        {
            return Ok(await _medicalInfoService.FindAsync(id));
        }
    }
}
