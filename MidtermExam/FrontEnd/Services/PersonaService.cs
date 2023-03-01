using FrontEnd.Models;

namespace FrontEnd.Services;

public class PersonaService : GenericServices<PersonaViewModel>
{
    public PersonaService(ILogger<PersonaService> logger, IConfiguration configuration)
        : base(configuration.GetSection("BackendURLs")["PersonaPath"], logger)
    {
    }
}