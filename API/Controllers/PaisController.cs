
using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PaisController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var paises = await unitofwork.Paises.GetAllAsync();
            return mapper.Map<List<PaisDto>>(paises);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pager<PaisxDepaDto>>> Get11([FromQuery] Params paisParams)
        {
            var pais = await unitofwork.Paises.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
            var lstPaisesDto = mapper.Map<List<PaisxDepaDto>>(pais.registros);
            return new Pager<PaisxDepaDto>(lstPaisesDto, pais.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await unitofwork.Paises.GetByIdAsync(id);
            if (pais == null){
                return NotFound();
            }
            return this.mapper.Map<PaisDto>(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais = this.mapper.Map<Pais>(paisDto);
            this.unitofwork.Paises.Add(pais);
            await unitofwork.SaveAsync();
            if(pais == null)
            {
                return BadRequest();
            }
            paisDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post), new {id = pais.Id}, pais);
        }
    }
