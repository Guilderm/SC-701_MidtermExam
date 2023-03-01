using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Propietario
    {
        public int PropietarioId { get; set; }
        public decimal Porcentaje { get; set; }
        public int FincaId { get; set; }
        public int PersonaId { get; set; }

        public virtual Finca Finca { get; set; } = null!;
        public virtual Persona Persona { get; set; } = null!;
    }
}
