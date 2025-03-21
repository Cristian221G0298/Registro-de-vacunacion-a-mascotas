using Registro_de_vacunación_a_mascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_vacunación_a_mascotas.Repositories
{
    public class MascotasRepository
    {
        VeterinariaContext context = new();
        public IEnumerable<Vwmascotasconmasvacunas> MascotasConMásVacunas()
        {
            return context.Vwmascotasconmasvacunas.ToList();
        }
        public IEnumerable<Vwmascotassinvacunas> MascotasSinVacunas()
        {
            return context.Vwmascotassinvacunas.ToList();
        }
        public IEnumerable<Vwmascotasvacunasfaltantes> MascotasVacunasFaltantes()
        {
            return context.Vwmascotasvacunasfaltantes.ToList();
        }
    }
}
