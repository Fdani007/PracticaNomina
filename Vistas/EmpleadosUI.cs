using PracticaNomina.Models;
using PracticaNomina.Service;

namespace PracticaNomina.Vistas
{
    public class EmpleadosUI
    {
        public static EmpleadoAsalariado CapturarEmpleadoAsalariado()
        {
            Console.WriteLine("\n--- Ingresar Datos Personales ---");
            string nombre = LeerTextoObligatorio("Nombre").Trim();
            string apellido = LeerTextoObligatorio("Apellido").Trim();
            string seguro = LeerTextoObligatorio("Seguro Social").Trim();

            Console.WriteLine("\n--- Ingresar Datos Financieros ---");
            decimal salaraio = LeerDecimalNoNegativo("Salario semanal");     

            return new EmpleadoAsalariado(nombre, apellido, seguro, salaraio);
        }

        public static EmpleadoPorHoras CapturarEmpleadoPorHoras()
        {
            Console.WriteLine("\n--- Ingresar Datos Personales ---");
            string nombre = LeerTextoObligatorio("Nombre").Trim();
            string apellido = LeerTextoObligatorio("Apellido").Trim();
            string seguro = LeerTextoObligatorio("Seguro Social").Trim();

            Console.WriteLine("\n--- Ingresar Datos Financieros ---");
            decimal sueldo = LeerDecimalNoNegativo("Sueldo por hora");
            decimal horas = LeerDecimalNoNegativo("Horas trabajadas");
            
            return new EmpleadoPorHoras(nombre, apellido, seguro, sueldo, horas);
        }

        public static EmpleadoPorComision CapturarEmpleadoPorComision()
        {
            Console.WriteLine("\n--- Ingresar Datos Personales ---");
            string nombre = LeerTextoObligatorio("Nombre").Trim();
            string apellido = LeerTextoObligatorio("Apellido").Trim();
            string seguro = LeerTextoObligatorio("Seguro Social").Trim();

            Console.WriteLine("\n--- Ingresar Datos Financieros ---");
            decimal ventas = LeerDecimalNoNegativo("Ventas brutas");
            decimal tarifa = LeerTarifaComision();

            return new EmpleadoPorComision(nombre, apellido, seguro, ventas, tarifa);
        }

        public static EmpleadoAsalariadoPorComision CapturarEmpleadoAsalariadoPorComision()
        {
            Console.WriteLine("\n--- Ingresar Datos Personales ---");
            string nombre = LeerTextoObligatorio("Nombre").Trim();
            string apellido = LeerTextoObligatorio("Apellido").Trim();
            string seguro = LeerTextoObligatorio("Seguro Social").Trim();

            Console.WriteLine("\n--- Ingresar Datos Financieros ---");
            decimal salarioBase = LeerDecimalNoNegativo("Salario base");
            decimal ventas = LeerDecimalNoNegativo("Ventas brutas");
            decimal tarifa = LeerTarifaComision();

            return new EmpleadoAsalariadoPorComision(nombre, apellido, seguro, ventas, tarifa, salarioBase);
        }

        public static void EditarEmpleado(Empleado empleado, EmpleadoService servicio)
        {            
            switch (empleado)
            {
                case EmpleadoAsalariadoPorComision emp:
                    EditarEmpleadoAsalariadoPorComision(emp, servicio);
                    break;
                case EmpleadoPorComision emp:
                    EditarEmpleadoPorComision(emp, servicio);
                    break;
                case EmpleadoPorHoras emp:
                    EditarEmpleadoPorHoras(emp);
                    break;
                case EmpleadoAsalariado emp:
                    EditarEmpleadoAsalariado(emp);
                    break;
                default:
                    Console.WriteLine("No existe editor para este tipo de empleado.");
                    break;
            }
        }

        private static void EditarDatosBase(Empleado empleado)
        {
            Console.WriteLine("\n--- Editar Datos Personales (Presione Enter para no cambiar) ---");
            empleado.PrimerNombre = LeerTextoOpcional("Nombre", empleado.PrimerNombre).Trim();
            empleado.ApellidoPaterno = LeerTextoOpcional("Apellido", empleado.ApellidoPaterno).Trim();
            empleado.NumeroSeguroSocial = LeerTextoOpcional("Seguro Social", empleado.NumeroSeguroSocial).Trim();
        }

        private static void EditarEmpleadoAsalariado(EmpleadoAsalariado emp)
        {
            EditarDatosBase(emp);
            Console.WriteLine("\n--- Editar Datos Financieros ---");
            emp.SalarioSemanal = LeerDecimalNoNegativoOpcional("Salario semanal", emp.SalarioSemanal);
        }

        private static void EditarEmpleadoPorHoras(EmpleadoPorHoras emp)
        {
            EditarDatosBase(emp);
            Console.WriteLine("\n--- Editar Datos Financieros ---");
            emp.SueldoPorHora = LeerDecimalNoNegativoOpcional("Sueldo por hora", emp.SueldoPorHora);
            emp.HorasTrabajadas = LeerDecimalNoNegativoOpcional("Horas trabajadas", emp.HorasTrabajadas);
        }

        private static void EditarEmpleadoPorComision(EmpleadoPorComision emp, EmpleadoService servicio)
        {
            EditarDatosBase(emp);
            Console.WriteLine("\n--- Editar Datos Financieros ---");
            emp.VentasBrutas = LeerDecimalNoNegativoOpcional("Ventas brutas", emp.VentasBrutas);
            emp.TarifaComision = LeerTarifaComisionOpcional(servicio, emp, emp.TarifaComision);
        }

        private static void EditarEmpleadoAsalariadoPorComision(EmpleadoAsalariadoPorComision emp, EmpleadoService servicio)
        {
            EditarDatosBase(emp);
            Console.WriteLine("\n--- Editar Datos Financieros ---");
            emp.SalarioBase = LeerDecimalNoNegativoOpcional("Salario base", emp.SalarioBase);
            emp.VentasBrutas = LeerDecimalNoNegativoOpcional("Ventas brutas", emp.VentasBrutas);
            emp.TarifaComision = LeerTarifaComisionOpcional(servicio, emp, emp.TarifaComision);
        }

        private static string LeerTextoObligatorio(string mensaje)
        {
            while (true)
            {
                Console.Write($"{mensaje}: ");
                string? entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada.Trim();
                }

                Console.WriteLine("Error: este campo no puede estar vacio.");
            }
        }

        private static string LeerTextoOpcional(string mensaje, string valorActual)
        {
            Console.Write($"{mensaje} [{valorActual}]: ");
            string? entrada = Console.ReadLine();

            return string.IsNullOrWhiteSpace(entrada) ? valorActual : entrada.Trim();
        }

        private static decimal LeerDecimalNoNegativo(string mensaje)
        {
            while (true)
            {
                Console.Write($"{mensaje}: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine("Error: ingrese un numero mayor o igual a 0.");
            }
        }

        private static decimal LeerDecimalNoNegativoOpcional(string mensaje, decimal valorActual)
        {
            while (true)
            {
                Console.Write($"{mensaje} [{valorActual}]: ");
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    return valorActual;
                }

                if (decimal.TryParse(entrada, out decimal valor) && valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine("Error: ingrese un numero mayor o igual a 0.");
            }
        }

        private static decimal LeerTarifaComision()
        {
            Console.WriteLine("Tarifa de la comision");
            Console.WriteLine("Use un numero entre 0.01 y 0.99 - Ejemplo: 24% = 0.24");

            while (true)
            {
                Console.Write("Ingrese la tarifa: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal tarifa)
                    && tarifa >= 0.01m
                    && tarifa <= 0.99m)
                {
                    return tarifa;
                }

                Console.WriteLine("Error: la tarifa debe estar entre 0.01 y 0.99.");
            }
        }

        private static decimal LeerTarifaComisionOpcional(EmpleadoService servicio, EmpleadoPorComision empleado, decimal valorActual)
        {
            Console.WriteLine("Tarifa de la comision");
            Console.WriteLine("Use un numero entre 0.01 y 0.99 - Ejemplo: 24% = 0.24");

            while (true)
            {
                Console.Write($"Tarifa de la comision [{valorActual}]: ");
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    return valorActual;
                }

                if (decimal.TryParse(entrada, out decimal tarifa)
                    && servicio.VerificarYAsignarTarifa(empleado, tarifa))
                {
                    return tarifa;
                }

                Console.WriteLine("Error: la tarifa debe estar entre 0.01 y 0.99.");
            }
        }
    }
}
