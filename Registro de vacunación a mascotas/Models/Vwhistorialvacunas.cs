using System;
using System.Collections.Generic;

namespace Registro_de_vacunación_a_mascotas.Models;

public partial class Vwhistorialvacunas
{
    public string NombreMascota { get; set; } = null!;

    public string NombreTipo { get; set; } = null!;

    public string NombreVacuna { get; set; } = null!;

    public DateTime? FechaAplicacion { get; set; }
}
