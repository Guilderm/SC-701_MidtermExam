﻿namespace Entities;

public class Periodo
{
    public int PeriodoId { get; set; }
    public int? TipoConceptoId { get; set; }
    public string? Periodo1 { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public DateTime? FechaGeneracion { get; set; }
}