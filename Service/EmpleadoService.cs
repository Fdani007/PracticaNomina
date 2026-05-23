using PracticaNomina.Models;

namespace PracticaNomina.Service
{
    public class EmpleadoService
    {
        private List<Empleado> Empleados = new List<Empleado>();

        public EmpleadoService()
        {
            Empleados = DatosDePrueba.ObtenerEmpleados();
        }
        public void AgregarEmpleado(Empleado empleado)
        {
            Empleados.Add(empleado);
        }

        public string VerEmpleados()
        {
            string EmpleadosLista = "";
            int i=0;
            foreach (Empleado e in Empleados)
            {
                i++;
                EmpleadosLista += $"""

                {i}- Nombre: {e.PrimerNombre} {e.ApellidoPaterno}
                Tipo: {e.Tipo}

                Pago final: {e.CalcularPago()}
                -----------------------------
                """;

            }
            return EmpleadosLista;
        }

        public string ReporteSemanal()
        {
            string Reporte = "";
            foreach(Empleado e in Empleados)
            {
                Reporte += $"""

                Empleado: {e.PrimerNombre} {e.ApellidoPaterno}
                Tipo: {e.Tipo}
                Seguridad Social: {e.NumeroSeguroSocial}

                {e.AtributosExtra}

                {e.Calculo}

                Pago final: {e.CalcularPago()}
                =============================================
                """;
            }
            Reporte += "\n";
            return Reporte;
        }

        public Empleado ObtenerEmpleadoPorIndice(int Indice)
        {
            return Empleados[Indice - 1];
        }

        public string MostrarEmpleadoPorIndice(int Indice)
        {
            Empleado emp = Empleados[Indice - 1];
            return $"""
                {Indice}- Nombre: {emp.PrimerNombre} {emp.ApellidoPaterno}
                Tipo: {emp.Tipo}

                Pago final: {emp.CalcularPago()}
                -----------------------------
                """;
        }

        public int CantidadEmpleados()
        {
            return Empleados.Count();
        }

        public bool VerificarYAsignarTarifa(EmpleadoPorComision empleado, decimal tarifa)
        {
            try
            {
                empleado.TarifaComision = tarifa;
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}
