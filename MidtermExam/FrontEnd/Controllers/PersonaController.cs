using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Services;

namespace FrontEnd.Controllers;

public class PersonaController : Controller
{
    private readonly ILogger<PersonaController> _logger;
    private readonly PersonaService _PersonaService;

    public PersonaController(PersonaService PersonaService, ILogger<PersonaController> logger)
    {
        _PersonaService = PersonaService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        _logger.LogInformation("Retrieving all categories.");
        return View(_PersonaService.GetAll());
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        _logger.LogInformation($"Retrieving details for Persona with ID: {id}.");
        return View(_PersonaService.Get(id));
    }

    [HttpGet]
    public ActionResult Create()
    {
        _logger.LogInformation("Rendering Persona create form.");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PersonaViewModel Persona)
    {
        try
        {
            _logger.LogInformation("Attempting to create a new Persona.");
            PersonaViewModel createdPersona = _PersonaService.Create(Persona);
            _logger.LogInformation($"Created Persona with ID: {createdPersona.PersonaId}");
            return RedirectToAction("Details", new { id = createdPersona.PersonaId });
        }
        catch
        {
            _logger.LogError("An error occurred while creating a new Persona.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        _logger.LogInformation($"Rendering Persona edit form for Persona with ID: {id}.");
        return View(_PersonaService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(PersonaViewModel Persona)
    {
        try
        {
            _logger.LogInformation($"Attempting to update Persona with ID: {Persona.PersonaId}.");
            _PersonaService.Edit(Persona);
            _logger.LogInformation($"Updated Persona with ID: {Persona.PersonaId}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while updating Persona with ID: {Persona.PersonaId}.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        _logger.LogInformation($"Rendering Persona delete form for Persona with ID: {id}.");
        return View(_PersonaService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(PersonaViewModel Persona)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete Persona with ID: {Persona.PersonaId}.");
            _PersonaService.Delete(Persona.PersonaId);
            _logger.LogInformation($"Deleted Persona with ID: {Persona.PersonaId}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while deleting Persona with ID: {Persona.PersonaId}.");
            return View();
        }
    }
}