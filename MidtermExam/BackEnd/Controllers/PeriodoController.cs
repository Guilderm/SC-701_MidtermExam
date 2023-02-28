using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class PeriodoController : GenericControllers<Periodo, PeriodoDTO>
{
    private readonly ILogger<PeriodoController> _logger;

    public PeriodoController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PeriodoController> logger) : base(
        unitOfWork, mapper)
    {
        _logger = logger;
    }

    #region POST|Create - Used to create a new resource.

    [HttpPost]
    public override IActionResult Post([FromBody] PeriodoDTO requestDto)
    {
        _logger.LogInformation($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
            return BadRequest(ModelState);
        }

        Periodo mappedResult = Mapper.Map<Periodo>(requestDto);

        Repository.Insert(mappedResult);
        UnitOfWork.SaveChanges();

        _logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.PeriodoId} .");

        return CreatedAtAction(nameof(Get), new { id = mappedResult.PeriodoId }, mappedResult);
    }

    #endregion
}