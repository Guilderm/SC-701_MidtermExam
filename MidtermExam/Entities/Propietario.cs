namespace Entities;

public class Propietario
{
    public int PropietarioId { get; set; }
    public decimal Porcentaje { get; set; }
    public int FincaId { get; set; }
    public int PersonaId { get; set; }

    public virtual Finca Finca { get; set; } = null!;
    public virtual Persona Persona { get; set; } = null!;
}