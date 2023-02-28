using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models;

public class PeriodoViewModel
{
    public int PeriodoId { get; set; }
    public int TipoConceptoId { get; set; }

    [Display(Name = "Period")] public string Periodo1 { get; set; }

    public DateTime FechaVencimiento { get; set; }
    public DateTime FechaGeneracion { get; set; }
}