using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class PersonaController : GenericControllers<Persona, PersonaDTO>
{
    private readonly ILogger<PersonaController> _logger;

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PersonaController> logger) : base(
        unitOfWork, mapper)
    {
        _logger = logger;
    }

    #region POST|Create - Used to create a new resource.

    [HttpPost]
    public override IActionResult Post([FromBody] PersonaDTO requestDto)
    {
        _logger.LogInformation($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
            return BadRequest(ModelState);
        }

        Persona mappedResult = Mapper.Map<Persona>(requestDto);

        // Check if PersonaId already exists
        if (Repository.Get(mappedResult.PersonaId) != null)
        {
            _logger.LogError(
                $"Invalid POST attempt in {nameof(requestDto)}. {nameof(Persona.PersonaId)} already exists");
            return BadRequest($"{nameof(Persona.PersonaId)} already exists");
        }

        Repository.Insert(mappedResult);
        UnitOfWork.SaveChanges();

        _logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.PersonaId} .");

        return CreatedAtAction(nameof(Get), new { id = mappedResult.PersonaId }, mappedResult);
    }

    #endregion
}