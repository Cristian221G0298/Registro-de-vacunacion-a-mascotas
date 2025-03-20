using System;
using System.Collections.Generic;

namespace Registro_de_vacunación_a_mascotas.Models;

public partial class Aplicacionesvacunas
{
    public int Id { get; set; }

    public int? IdMascota { get; set; }

    public int? IdVacuna { get; set; }

    public DateTime? FechaAplicacion { get; set; }

    public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Vacunas? IdVacunaNavigation { get; set; }
}
