

using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepaController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public DepaController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        // [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var departamentos = await unitofwork.Departamentos.GetAllAsync();
            return mapper.Map<List<DepartamentoDto>>(departamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var departamento = await unitofwork.Departamentos.GetByIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            return this.mapper.Map<DepartamentoDto>(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Departamento>> Post(DepartamentoDto departamentoDto)
        {
            var departamento = this.mapper.Map<Departamento>(departamentoDto);
            this.unitofwork.Departamentos.Add(departamento);
            await unitofwork.SaveAsync();
            if(departamento == null)
            {
                return BadRequest();
            }
            departamentoDto.Id = departamento.Id;
            return CreatedAtAction(nameof(Post), new {id = departamento.Id}, departamentoDto);
        }
    }
}