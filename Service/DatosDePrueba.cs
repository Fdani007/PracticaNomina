using PracticaNomina.Models;
using PracticaNomina.Service;

namespace PracticaNomina.Service
{
    public class DatosDePrueba
    {
        public static List<Empleado> ObtenerEmpleados()
        {
            return new List<Empleado>
            {
                new EmpleadoAsalariado("Juan", "Perez", "001-0000001-1", 15000m),
                new EmpleadoAsalariado("Maria", "Gomez", "001-0000002-2", 22000m),

                new EmpleadoPorHoras("Ana", "Lopez", "001-0000003-3", 200m, 35m),
                new EmpleadoPorHoras("Carlos", "Martinez", "001-0000004-4", 300m, 45m),
                new EmpleadoPorHoras("Luis", "Fernandez", "001-0000005-5", 180m, 50m),

                new EmpleadoPorComision("Sofia", "Ramirez", "001-0000006-6", 100000m, 0.10m),
                new EmpleadoPorComision("Pedro", "Diaz", "001-0000007-7", 75000m, 0.08m),
                
                new EmpleadoAsalariadoPorComision("Laura", "Hernandez", "001-0000008-8", 120000m, 0.12m, 8000m),
                new EmpleadoAsalariadoPorComision("Miguel", "Castillo", "001-0000009-9", 95000m, 0.09m, 10000m),

                new EmpleadoAsalariado("Elena", "Torres", "001-0000010-0", 18000m)
            };
        }
    }
}
