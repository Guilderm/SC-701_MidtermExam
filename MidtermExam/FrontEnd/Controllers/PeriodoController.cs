using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Services;

namespace FrontEnd.Controllers;

public class PeriodoController : Controller
{
    private readonly ILogger<PeriodoController> _logger;
    private readonly PeriodoService _PeriodoService;

    public PeriodoController(PeriodoService periodoService, ILogger<PeriodoController> logger)
    {
        _PeriodoService = periodoService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        _logger.LogInformation("Retrieving all categories.");
        return View(_PeriodoService.GetAll());
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        _logger.LogInformation($"Retrieving details for Periodo with ID: {id}.");
        return View(_PeriodoService.Get(id));
    }

    [HttpGet]
    public ActionResult Create()
    {
        _logger.LogInformation("Rendering Periodo create form.");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PeriodoViewModel Periodo)
    {
        try
        {
            _logger.LogInformation("Attempting to create a new Periodo.");
            PeriodoViewModel createdPeriodo = _PeriodoService.Create(Periodo);
            _logger.LogInformation($"Created Periodo with ID: {createdPeriodo.PeriodoId}");
            return RedirectToAction("Details", new { id = createdPeriodo.PeriodoId });
        }
        catch
        {
            _logger.LogError("An error occurred while creating a new Periodo.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        _logger.LogInformation($"Rendering Periodo edit form for Periodo with ID: {id}.");
        return View(_PeriodoService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(PeriodoViewModel Periodo)
    {
        try
        {
            _logger.LogInformation($"Attempting to update Periodo with ID: {Periodo.PeriodoId}.");
            _PeriodoService.Edit(Periodo);
            _logger.LogInformation($"Updated Periodo with ID: {Periodo.PeriodoId}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while updating Periodo with ID: {Periodo.PeriodoId}.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        _logger.LogInformation($"Rendering Periodo delete form for Periodo with ID: {id}.");
        return View(_PeriodoService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(PeriodoViewModel Periodo)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete Periodo with ID: {Periodo.PeriodoId}.");
            _PeriodoService.Delete(Periodo.PeriodoId);
            _logger.LogInformation($"Deleted Periodo with ID: {Periodo.PeriodoId}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while deleting Periodo with ID: {Periodo.PeriodoId}.");
            return View();
        }
    }
}