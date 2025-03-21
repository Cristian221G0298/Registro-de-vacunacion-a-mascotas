using Registro_de_vacunación_a_mascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_vacunación_a_mascotas.Repositories
{
    public class VacunasRepository
    {
        VeterinariaContext context = new();

        public IEnumerable<Vwhistorialvacunas> HistorialVacunas()
        {
            return context.Vwhistorialvacunas.ToList();
        }
        public IEnumerable<Vwvacunassinaplicar> VacunasSinAplicar()
        {
            return context.Vwvacunassinaplicar.ToList();
        }
        public IEnumerable<Vwregistro> VacunasAplicadasHaceDias()
        {
            return context.Vwregistro.ToList();
        }
    }
}
