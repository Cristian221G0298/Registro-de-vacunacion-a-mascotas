using System;
using System.Collections.Generic;

namespace Registro_de_vacunación_a_mascotas.Models;

public partial class Vwmascotassinvacunas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdTipo { get; set; }
}
