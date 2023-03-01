namespace Entities;

public class Persona
{
    public Persona()
    {
        Propietarios = new HashSet<Propietario>();
    }

    public int PersonaId { get; set; }
    public string? Cedula { get; set; }
    public string? Nombre { get; set; }

    public virtual ICollection<Propietario> Propietarios { get; set; }
}