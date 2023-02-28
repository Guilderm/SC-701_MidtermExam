using FrontEnd.Models;

namespace FrontEnd.Services;

public class PeriodoService : GenericServices<PeriodoViewModel>
{
    public PeriodoService(ILogger<PeriodoService> logger, IConfiguration configuration)
        : base(configuration.GetSection("BackendURLs")["PeriodoPath"], logger)
    {
    }
}