using System;
using System.Collections.Generic;

namespace Registro_de_vacunación_a_mascotas.Models;

public partial class Vwregistro
{
    public DateTime? FechaAplicacion { get; set; }

    public string Mascota { get; set; } = null!;

    public string Vacuna { get; set; } = null!;
}
